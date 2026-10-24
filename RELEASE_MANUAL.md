# AYUTTHAYA SIMULATOR PHASE 18 — Release Manual / คู่มือ Release

## English game-development manual

Create a `BuildProfile` asset and set product name, semantic version, bundle code, scenes, target, and development flags. Run `Ayutthaya/Build/Validate Selected Profile` before building. Client and dedicated-server builds must use the same content revision and compatible network protocol.

Run EditMode tests, then PlayMode smoke tests. Build Windows x64 from a clean checkout using a pinned Unity 6 editor. Archive the build manifest, commit hash, Unity version, package lock, configuration revision, test report, and checksums. Sign installers/artifacts using the organization’s release signing process.

Copy `BUILD_CONFIG.example.json` to `StreamingAssets/BuildConfig.json` and replace deployment values. Never commit secrets, tokens, private keys, or production credentials. `CrashLogService` stores exception/error reports under `Application.persistentDataPath/CrashReports`.

### Installation guide

Install the signed client artifact, keep the executable and data folder together, place the approved `BuildConfig.json` in `StreamingAssets`, and launch the executable. Verify version, content revision, language preference, save path, and server connectivity. Windows Defender/firewall rules must be approved by the operator.

### Dedicated server administration

Use the headless server build with an environment-specific configuration file. Register the instance with the load balancer, verify health/readiness, then admit sessions. Monitor logs, crash reports, rejected requests, save conflicts, memory, CPU, network, and active sessions. Drain before shutdown: stop new sessions, finish bounded persistence writes, unregister from the balancer, then stop the process.

### Rollback

Keep immutable, signed artifacts and manifests for every release. To rollback, drain the current server, deploy the previous matching client/server artifacts and configuration, verify schema compatibility, restore from the approved persistence backup if needed, and reopen traffic. Do not mix content revisions or apply an untested migration backwards.

## คู่มือพัฒนาเกมภาษาไทย

สร้าง `BuildProfile` แล้วกำหนดชื่อเกม, semantic version, bundle code, scene, target และ development flags รัน `Ayutthaya/Build/Validate Selected Profile` ก่อน build client/server ต้องใช้ content revision และ network protocol ที่เข้ากันได้

รัน EditMode และ PlayMode smoke tests จากนั้น build Windows x64 ด้วย Unity 6 ที่ pin version เดียวกัน เก็บ manifest, commit hash, Unity version, package lock, configuration revision, test report และ checksum ให้ครบ ห้ามใส่ secret/token/private key ใน repository

### คู่มือติดตั้ง

ติดตั้ง artifact ที่เซ็นแล้ว ให้อยู่คู่กับ data folder ใส่ `BuildConfig.json` ใน `StreamingAssets` ตรวจ version, content revision, ภาษา, save path และการเชื่อมต่อ server รวมถึงสิทธิ์ Windows Firewall/Defender

### คู่มือดูแล dedicated server

ใช้ headless server build กับ config ของ environment นั้น ๆ register กับ load balancer ตรวจ health/readiness แล้วจึงรับผู้เล่น monitor log, crash report, request reject, save conflict, CPU, memory, network และ active sessions ก่อน shutdown ให้ drain session ใหม่, เขียน persistence ที่ค้างให้เสร็จ, unregister และหยุด process

### การ rollback

เก็บ artifact และ manifest ที่เซ็นแล้วแบบ immutable ทุก release เมื่อ rollback ให้ drain server ปัจจุบัน deploy client/server และ config ชุดก่อนหน้าที่ตรงกัน ตรวจ schema/backup แล้วเปิด traffic ใหม่ ห้ามผสม content revision หรือย้อน migration ที่ยังไม่ทดสอบ

## Architecture documentation / เอกสารสถาปัตยกรรม

Runtime gameplay remains separate from build/deployment configuration. `BuildProfile` is Editor build intent; `RuntimeConfiguration` is non-secret deployment input; `CrashLogService` is local evidence collection; server authority, persistence, networking, and operations adapters remain external integration boundaries.

## Known limitations / ข้อจำกัด

This repository does not contain a signed installer, production certificate, CI/CD credentials, Windows build output, crash upload service, database backup service, or verified dedicated-server deployment. The build menu and validation scripts require Unity Editor. Actual Windows build, installer, firewall, signing, server health checks, crash upload, rollback drill, and release acceptance require manual or CI verification.
