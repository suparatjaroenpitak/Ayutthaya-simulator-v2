"""Read OSM as data only. Export projected, building-free prototype surfaces."""
import argparse, hashlib, json, math, pathlib, xml.etree.ElementTree as ET

def utm(lat, lon):
    # WGS84 / UTM zone 47N, EPSG:32647. Snyder transverse Mercator series.
    a, e2, k = 6378137.0, 0.0066943799901413165, 0.9996
    p, l = math.radians(lat), math.radians(lon - 99)
    ep = e2/(1-e2); n = a/math.sqrt(1-e2*math.sin(p)**2)
    t = math.tan(p)**2; c = ep*math.cos(p)**2; A = math.cos(p)*l
    m = a*((1-e2/4-3*e2**2/64-5*e2**3/256)*p-(3*e2/8+3*e2**2/32+45*e2**3/1024)*math.sin(2*p)+(15*e2**2/256+45*e2**3/1024)*math.sin(4*p)-35*e2**3/3072*math.sin(6*p))
    return (500000+k*n*(A+(1-t+c)*A**3/6+(5-18*t+t*t+72*c-58*ep)*A**5/120),
            k*(m+n*math.tan(p)*(A*A/2+(5-t+9*c+4*c*c)*A**4/24+(61-58*t+t*t+600*c-330*ep)*A**6/720)))

def main():
    p=argparse.ArgumentParser(); p.add_argument('sources',nargs='+'); p.add_argument('--output',required=True); args=p.parse_args()
    nodes={}; ways={}; bounds=[]; sources=[]; relations=0
    for name in args.sources:
        path=pathlib.Path(name); root=ET.parse(path).getroot()
        b=root.find('bounds'); bounds.append({k:float(v) for k,v in b.attrib.items()})
        sources.append({'file':path.name,'sha256':hashlib.sha256(path.read_bytes()).hexdigest(),'attribution':root.get('copyright'),'license':root.get('license')})
        for node in root.findall('node'): nodes[node.get('id')]=utm(float(node.get('lat')),float(node.get('lon')))
        for way in root.findall('way'):
            key=way.get('id'); version=int(way.get('version','0'))
            if key not in ways or version>ways[key][0]: ways[key]=(version,[n.get('ref') for n in way.findall('nd')],{t.get('k'):t.get('v') for t in way.findall('tag')})
        relations+=len(root.findall('relation'))
    corners=[utm(b[lat],b[lon]) for b in bounds for lat in ('minlat','maxlat') for lon in ('minlon','maxlon')]
    ox=math.floor(min(x for x,z in corners)/512)*512; oz=math.floor(min(z for x,z in corners)/512)*512
    roads=[]; surfaces=[]; excluded=missing=grade=0
    widths={'motorway':12,'trunk':10,'primary':8,'secondary':7,'tertiary':6,'residential':5,'unclassified':5,'service':3.5,'track':3,'footway':1.5,'path':1.5,'pedestrian':3,'living_street':4,'cycleway':2,'steps':1.5}
    for key,(_,refs,tags) in ways.items():
        if 'building' in tags or 'building:part' in tags: excluded+=1; continue
        if any(r not in nodes for r in refs): missing+=1; continue
        pts=[{'x':nodes[r][0]-ox,'z':nodes[r][1]-oz} for r in refs]
        if tags.get('highway') in widths:
            if tags.get('bridge','no')!='no' or tags.get('tunnel','no')!='no': grade+=1; continue
            width=widths[tags['highway']]; assumed=True
            try: width=float(tags['width']); assumed=False
            except (KeyError,ValueError): pass
            roads.append({'id':key,'points':pts,'width':max(1,min(30,width)),'assumedWidth':assumed})
        kind=tags.get('landuse',tags.get('natural',''))
        if len(pts)>=4 and refs[0]==refs[-1] and kind in ('farmland','farmyard','grass','meadow','forest','wood','water','scrub','sand'):
            surfaces.append({'id':key,'kind':kind,'points':pts})
    result={'originEasting':ox,'originNorthing':oz,'width':math.ceil((max(x for x,z in corners)-ox)/512)*512,'length':math.ceil((max(z for x,z in corners)-oz)/512)*512,'roads':roads,'surfaces':surfaces}
    out=pathlib.Path(args.output); out.parent.mkdir(parents=True,exist_ok=True); out.write_text(json.dumps(result),encoding='utf8')
    report={'crs':'EPSG:32647','scale':'1 Unity unit = 1 projected metre','elevation':'FLAT PROTOTYPE ONLY: no DEM supplied','origin':[ox,oz],'sources':sources,'bounds':bounds,'roads':len(roads),'surfacePolygons':len(surfaces),'excludedBuildings':excluded,'missingNodeWays':missing,'omittedBridgesTunnels':grade,'unprocessedRelations':relations,'limitations':['Relations/multipolygon holes not imported; closed-way surfaces only.','Widths without numeric OSM width are gameplay estimates.','Road joins are ribbon segments, not engineered intersections.','No height or water depth accuracy claimed.','Source bounding boxes have a gap; no missing roads are invented.']}
    out.with_suffix('.report.json').write_text(json.dumps(report,ensure_ascii=False,indent=2),encoding='utf8'); print(json.dumps(report,ensure_ascii=False,indent=2))
if __name__=='__main__': main()
