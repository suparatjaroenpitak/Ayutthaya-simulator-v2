# PHASE 17 QA Manual / คู่มือ QA เฟส 17

## English

Run EditMode tests in Unity Test Runner first. Then run PlayMode tests with the same scene, fixed seed, fixed clock/weather, and declared build. For multiplayer, use Multiplayer Play Mode or two standalone clients: start one host/server, connect two clients, verify distinct ownership, movement interpolation, interaction rejection, disconnect, reconnect, and persistence recovery. Do not mark a test passed from source inspection alone.

Record all bug reports with build hash, scene/seed, account/shard, reproduction rate, logs, telemetry, and expected/actual results. Economy, property, quest, farm, inventory, and persistence failures are high priority because they can affect durable player state.

## ภาษาไทย

รัน EditMode ใน Unity Test Runner ก่อน จากนั้นรัน PlayMode ด้วย scene, seed, clock, weather และ build ที่ระบุเหมือนกัน สำหรับ multiplayer ให้ใช้ Multiplayer Play Mode หรือ standalone 2 clients: เปิด host/server, ต่อ client สองคน, ตรวจ ownership, movement interpolation, การปฏิเสธ interaction, disconnect, reconnect และ persistence recovery ห้ามสรุปว่า test ผ่านจากการอ่าน source อย่างเดียว

รายงานบั๊กต้องมี build hash, scene/seed, account/shard, อัตราการเกิดซ้ำ, log, telemetry และ expected/actual โดยปัญหา economy, property, quest, farm, inventory และ persistence ให้ความสำคัญสูงเพราะกระทบข้อมูลถาวรของผู้เล่น

## Test gates

- EditMode source contracts pass.
- PlayMode player/terrain/save flows pass in Unity.
- Two-client tests pass in Multiplayer Play Mode or standalone builds.
- Latency/loss tests use a declared adapter and measured telemetry.
- Every failure has a reproducible report; no invented performance or network result.
