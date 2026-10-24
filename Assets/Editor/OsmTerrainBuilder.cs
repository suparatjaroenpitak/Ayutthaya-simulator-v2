using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using AyutthayaSimulator.WorldPrototype;

public static class OsmTerrainBuilder
{
    [Serializable] public class Point { public float x, z; }
    [Serializable] public class Road { public string id; public Point[] points; public float width; }
    [Serializable] public class Surface { public string kind; public Point[] points; }
    [Serializable] public class Map { public float width, length; public Road[] roads; public Surface[] surfaces; }
    [MenuItem("Ayutthaya/OSM/Build building-free terrain")]
    public static void Build()
    {
        if (!Application.isBatchMode && !EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo()) return;
        var map = JsonUtility.FromJson<Map>(File.ReadAllText("Assets/WorldPrototype/Data/ayutthaya.json"));
        string folder = AssetDatabase.GenerateUniqueAssetPath("Assets/GeneratedOsm");
        AssetDatabase.CreateFolder("Assets", Path.GetFileName(folder));
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var colors = new[] { new Color(.35f,.44f,.23f), new Color(.48f,.39f,.20f), new Color(.18f,.29f,.13f), new Color(.17f,.35f,.43f), new Color(.65f,.58f,.38f) };
        var layers = new TerrainLayer[colors.Length];
        for (int i=0;i<layers.Length;i++) {
            var texture = new Texture2D(2,2); texture.SetPixels(new[]{colors[i],colors[i],colors[i],colors[i]}); texture.Apply();
            AssetDatabase.CreateAsset(texture, folder+"/Surface"+i+".asset");
            layers[i] = new TerrainLayer { diffuseTexture=texture, tileSize=new Vector2(8,8) };
            AssetDatabase.CreateAsset(layers[i],folder+"/Layer"+i+".terrainlayer");
        }
        var terrains = new List<Terrain>();
        for(int z=0;z<map.length;z+=512) for(int x=0;x<map.width;x+=512) {
            var data = new TerrainData { heightmapResolution=65, alphamapResolution=64, size=new Vector3(512,50,512), terrainLayers=layers };
            var weights = new float[64,64,layers.Length];
            for(int j=0;j<64;j++) for(int i=0;i<64;i++) {
                int layer=0; float px=x+(i+.5f)*8, pz=z+(j+.5f)*8;
                foreach(var s in map.surfaces) if(Inside(s.points,px,pz)) layer=s.kind=="water"?3:s.kind=="sand"?4:(s.kind=="forest"||s.kind=="wood")?2:(s.kind=="farmland"||s.kind=="farmyard")?1:0;
                weights[j,i,layer]=1;
            }
            data.SetAlphamaps(0,0,weights);
            AssetDatabase.CreateAsset(data,folder+"/Terrain_"+x+"_"+z+".asset");
            var go=Terrain.CreateTerrainGameObject(data); go.name="Terrain_"+x+"_"+z; go.transform.position=new Vector3(x,0,z);
            var terrain=go.GetComponent<Terrain>(); terrain.heightmapPixelError=8; terrain.drawInstanced=true; terrains.Add(terrain);
        }
        var roadMaterial = new Material(Shader.Find("Standard")) { color=new Color(.19f,.19f,.18f) };
        AssetDatabase.CreateAsset(roadMaterial,folder+"/Road.mat");
        var roadRoot = new GameObject("OSM roads - no buildings");
        foreach(var road in map.roads) {
            var vertices=new List<Vector3>(); var triangles=new List<int>();
            for(int i=1;i<road.points.Length;i++) {
                Vector3 a=new Vector3(road.points[i-1].x,.04f,road.points[i-1].z), b=new Vector3(road.points[i].x,.04f,road.points[i].z);
                if((a-b).sqrMagnitude<.001f) continue;
                Vector3 side=Vector3.Cross(Vector3.up,(b-a).normalized)*road.width*.5f; int n=vertices.Count;
                vertices.Add(a-side); vertices.Add(a+side); vertices.Add(b-side); vertices.Add(b+side);
                triangles.AddRange(new[]{n,n+2,n+1,n+1,n+2,n+3});
            }
            if(vertices.Count==0) continue;
            var mesh=new Mesh { indexFormat=UnityEngine.Rendering.IndexFormat.UInt32 }; mesh.SetVertices(vertices); mesh.SetTriangles(triangles,0); mesh.RecalculateNormals(); mesh.RecalculateBounds();
            AssetDatabase.CreateAsset(mesh,folder+"/Road_"+road.id+".asset");
            var go=new GameObject("Road_"+road.id,typeof(MeshFilter),typeof(MeshRenderer)); go.transform.SetParent(roadRoot.transform);
            go.GetComponent<MeshFilter>().sharedMesh=mesh; go.GetComponent<MeshRenderer>().sharedMaterial=roadMaterial;
            var lod=go.AddComponent<LODGroup>(); lod.SetLODs(new[]{new LOD(.002f,new Renderer[]{go.GetComponent<MeshRenderer>()})}); lod.RecalculateBounds();
        }
        var light=new GameObject("Sun").AddComponent<Light>(); light.type=LightType.Directional; light.intensity=1.2f; light.transform.rotation=Quaternion.Euler(45,-30,0);
        RenderSettings.ambientLight=new Color(.6f,.65f,.7f); RenderSettings.fog=true; RenderSettings.fogColor=new Color(.65f,.75f,.8f); RenderSettings.fogMode=FogMode.Linear; RenderSettings.fogStartDistance=900; RenderSettings.fogEndDistance=1800;
        var camera=new GameObject("Main Camera",typeof(Camera),typeof(AudioListener)).GetComponent<Camera>(); camera.tag="MainCamera"; camera.farClipPlane=1800; camera.backgroundColor=RenderSettings.fogColor; camera.clearFlags=CameraClearFlags.SolidColor;
        var player=new GameObject("Somchai prototype",typeof(CharacterController),typeof(PrototypeExplorer)); player.layer=2;
        var p=map.roads.Length>0?map.roads[0].points[0]:new Point{x=256,z=256}; player.transform.position=new Vector3(Mathf.Clamp(p.x,2,map.width-2),2,Mathf.Clamp(p.z,2,map.length-2));
        var controller=player.GetComponent<CharacterController>(); controller.height=2; controller.center=Vector3.up; controller.radius=.35f; controller.stepOffset=.3f; controller.skinWidth=.05f;
        var body=GameObject.CreatePrimitive(PrimitiveType.Capsule); body.name="Placeholder visual - replace with model"; UnityEngine.Object.DestroyImmediate(body.GetComponent<Collider>()); body.layer=2; body.transform.SetParent(player.transform,false); body.transform.localPosition=Vector3.up;
        player.GetComponent<PrototypeExplorer>().view=camera;
        PrefabUtility.SaveAsPrefabAsset(player,folder+"/SomchaiPrototype.prefab");
        var visibility=new GameObject("Terrain visibility").AddComponent<TerrainVisibility>(); visibility.viewer=player.transform; visibility.tiles=terrains.ToArray();
        Physics.SyncTransforms();
        if(!Physics.Raycast(player.transform.position,Vector3.down,10,1)) throw new Exception("Spawn has no ground collider");
        EditorSceneManager.SaveScene(scene,folder+"/AyutthayaTerrain.unity"); AssetDatabase.SaveAssets();
        Debug.Log("OSM_BUILD_OK scene="+folder+"/AyutthayaTerrain.unity terrains="+terrains.Count+" roads="+map.roads.Length+" buildings=0");
    }
    static bool Inside(Point[] polygon,float x,float z) {
        bool inside=false;
        for(int i=0,j=polygon.Length-1;i<polygon.Length;j=i++) { var a=polygon[i]; var b=polygon[j]; if((a.z>z)!=(b.z>z) && x<(b.x-a.x)*(z-a.z)/(b.z-a.z)+a.x) inside=!inside; }
        return inside;
    }
}
