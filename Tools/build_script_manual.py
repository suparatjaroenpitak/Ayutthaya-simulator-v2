"""Generate a source-derived inventory, not a claim of functional certification."""
import pathlib,re
root=pathlib.Path('.')
groups={'Runtime':'01–02','GIS':'03','Animation':'04','NPC':'05','Vehicles':'06','Farming':'07','Life':'08','Economy':'09','Property':'10','Narrative':'11','Multiplayer':'12','Persistence':'13','Security':'14','Operations':'14','UI':'15','Performance':'16','Build':'18'}
lines=['# Script inventory / รายการสคริปต์จริง Phase 1–18','','Generated from source. Field declarations below are exact source defaults, not recommended production tuning.','รายการนี้แสดงชนิดข้อมูลและค่าเริ่มต้นจากซอร์ส ไม่ใช่การรับรองว่าระบบครบหรือพร้อม production','', 'MonoBehaviour: attach to a GameObject only when its class matches the filename. ScriptableObject: create a data asset, do not attach to a model. Plain classes/interfaces: construct or use from code.','MonoBehaviour ใส่ GameObject; ScriptableObject สร้างเป็น asset แล้วลากลงช่องอ้างอิง; class/interface ธรรมดาห้ามลากใส่โมเดล','']
for file in sorted((root/'Assets').rglob('*.cs')):
    if 'Generated' in str(file): continue
    code=file.read_text(encoding='utf-8-sig'); group=file.parent.name
    phase='17' if 'Tests' in file.parts else groups.get(group,'Editor / prototype')
    lines += [f'## {file.as_posix()} — Phase {phase}','']
    classes=re.findall(r'\bclass\s+(\w+)(?:\s*:\s*([^\{\n]+))?',code)
    for name,bases in classes:
        kind='Component / ใส่ GameObject' if 'MonoBehaviour' in bases or 'NetworkBehaviour' in bases else 'Data asset / สร้าง asset' if 'ScriptableObject' in bases else 'Code only / เรียกจากโค้ด'
        lines += [f'- `{name}`: {kind}; base: `{bases.strip() or "none"}`.']
        if ('MonoBehaviour' in bases or 'ScriptableObject' in bases or 'NetworkBehaviour' in bases) and name!=file.stem:
            lines += ['  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.']
    requires=re.findall(r'\[RequireComponent\((.*?)\)\]',code)
    if requires: lines+=['','Required components / ต้องมี: '+', '.join(requires)]
    fields=re.findall(r'(?:\[SerializeField\]\s*(?:private|protected|public)|\bpublic)\s+(?:readonly\s+)?[\w<>,\.\[\]]+\s+\w+\s*(?:=\s*[^;\n]+)?;',code)
    lines+=['','Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):','','```csharp',*fields,'```',''] if fields else ['','No simple serialized fields detected; inspect source for properties/methods.','']
out=root/'Documentation'/'SCRIPT_CATALOG_TH_EN.md'; out.parent.mkdir(exist_ok=True)
out.write_text('\n'.join(lines),encoding='utf8')
print(f'{out}: {len(lines)} lines')
