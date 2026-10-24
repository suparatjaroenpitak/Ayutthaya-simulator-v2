# AYUTTHAYA SIMULATOR — PHASE 01 + PHASE 02 + PHASE 03 + PHASE 04 + PHASE 05 + PHASE 06 + PHASE 07

## Phase 07 scope / ขอบเขตเฟส 07

Phase 07 adds an accessible, data-driven rice-farming layer: land plots, soil preparation, planting, crop stages, irrigation, weather modifiers, abstract fertilizer resources, harvesting, machinery, crop quality, storage, selling, progression, interaction animation hooks, UI state snapshots, local farm persistence, and a server-authority boundary for transactions.

เฟส 07 เพิ่มระบบ farming ข้าวที่เข้าถึงง่ายและใช้ข้อมูลเป็นหลัก: แปลงนา, เตรียมดิน, ปลูก, stages, น้ำ, weather modifier, fertilizer resource แบบ abstract, เก็บเกี่ยว, เครื่องจักร, คุณภาพ, storage, ขาย, progression, animation interaction, UI snapshot, persistence และ server authority สำหรับธุรกรรม

## Phase 06 scope / ขอบเขตเฟส 06

Phase 06 adds original vehicle and traffic foundations: modular vehicle interfaces, car and motorcycle definitions, WheelCollider driving, steering, acceleration, braking, entry/exit, fuel, collisions, lane graphs, intersections, traffic signals, NPC drivers, parking, and an authority boundary for online mode.

เฟส 06 เพิ่มรากฐานระบบรถและจราจรที่เป็นต้นฉบับ: interface แบบ modular, definition สำหรับรถยนต์และมอเตอร์ไซค์, WheelCollider driving, steering, acceleration, braking, ขึ้น/ลงรถ, fuel, collision, lane graph, intersection, traffic light, NPC driver, parking และขอบเขต server authority สำหรับ online mode

## Phase 05 scope / ขอบเขตเฟส 05

Phase 05 adds scalable civilian simulation: ScriptableObject NPC profiles, occupations, schedules, NavMesh movement, activity handlers for shops and farms, conversations, bounded relationships, crowd spawning, pooled NPC instances, vehicle-aware pedestrian pausing, AI LOD, per-frame simulation budgets, and a Unity Profiler marker.

เฟส 05 เพิ่มระบบจำลองพลเรือนที่ขยายได้: NPC profile แบบ ScriptableObject, อาชีพ, ตารางเวลา, NavMesh movement, activity ของร้านค้าและฟาร์ม, conversation, relationship ที่จำกัดค่า, crowd spawning, pooling, pedestrian ที่หยุดเมื่อมีรถ, AI LOD, budget ต่อเฟรม และ Profiler marker ของ Unity

## Phase 04 scope / ขอบเขตเฟส 04

Phase 04 adds a modular animation presentation layer for Somchai: a generated Humanoid Animator Controller, placeholder idle/walk/run/jump/interact/sit/sleep/farm states, animation parameters, IK target interfaces, clothing material customization, animation-event relaying, and reusable interaction points.

เฟส 04 เพิ่มชั้นระบบ animation แบบแยกส่วนของสมชาย: สร้าง Humanoid Animator Controller, state placeholder สำหรับ idle/walk/run/jump/interact/sit/sleep/farm, parameters, interface สำหรับ IK, เปลี่ยนเสื้อผ้าด้วย material, relay ของ animation events และ interaction points ที่นำกลับมาใช้ซ้ำได้

## Phase 03 scope / ขอบเขตเฟส 03

Phase 03 adds a GIS-safe prototype foundation for a small, user-selected Ayutthaya demo tile. It preserves a WGS84 geographic reference into a local east-up-north coordinate frame, supports source manifests, tile definitions, additive scene loading, origin shifting, validation, and spawn-point data. It deliberately does not ship geographic data or claim 1:1 accuracy without licensed source files and a selected area of interest.

เฟส 03 เพิ่มรากฐาน prototype GIS สำหรับ demo tile ขนาดเล็กที่ผู้ใช้เลือกเอง โดยรักษา reference ของ WGS84 แล้วแปลงเป็น local east-up-north, รองรับ source manifest, tile definition, additive scene loading, origin shifting, validation และ spawn points ทั้งนี้ repository นี้ไม่มีข้อมูลภูมิศาสตร์จริงและไม่อ้างความแม่นยำ 1:1 จนกว่าจะมี source ที่ได้รับอนุญาตและกำหนดพื้นที่จริง

## Phase 02 scope / ขอบเขตเฟส 02

Phase 02 adds a robust Somchai controller: Input System actions, CharacterController locomotion, walk/run/jump, gravity, extra grounded probes, mesh/terrain collider compatibility through Unity Physics queries, orbit camera collision avoidance, Animator parameters, interaction raycasts, and spawn recovery.

เฟส 02 เพิ่ม controller ของสมชาย: Input System, CharacterController, เดิน/วิ่ง/กระโดด, gravity, grounded probe สำรอง, รองรับ Terrain และ MeshCollider ผ่าน Physics queries, กล้อง orbit ที่หลบสิ่งกีดขวาง, Animator parameters, interaction raycast และระบบกู้ตำแหน่งเกิด

Phase 01 is the Foundation Vertical Slice. It establishes a clean Unity 6.3 LTS project baseline, data-driven configuration, a CharacterController player, Input System movement, basic hunger/energy simulation, and local JSON save/load. It does not claim to implement the open world, traffic, multiplayer, farming, NPC schedules, or GIS data yet.

เฟสนี้เป็นรากฐานสำหรับ vertical slice: ตั้งค่า Unity 6.3 LTS, config ด้วย ScriptableObject, ผู้เล่นแบบ CharacterController, การเคลื่อนที่ด้วย Input System, hunger/energy และ save/load แบบ local JSON ระบบ open world, รถ, multiplayer, farming, NPC และ GIS ยังไม่อยู่ในเฟสนี้

## Prerequisites / สิ่งที่ต้องมี

1. Install Unity 6000.3 LTS and create/open this folder.
2. Let Package Manager resolve `Packages/manifest.json`.
3. Create a URP scene named `Assets/Scenes/Phase02_PlayerVerticalSlice.unity`.

## Editor setup / การตั้งค่าใน Editor

1. Create `Assets/Config/GameConfig.asset` from `Ayutthaya/Config/Game Config`.
2. Create an Input Actions asset with `Move` (Value/Vector2), `Look` (Value/Vector2), `Run` (Button), `Jump` (Button), and `Interact` (Button). Suggested bindings: WASD, mouse delta, Left Shift, Space, and E.
3. Create a Player GameObject with `CharacterController`, `ThirdPersonPlayer`, `PlayerNeeds`, `PlayerInteraction`, and `SpawnRecovery`.
4. Set CharacterController: Center `(0,1,0)`, Radius `0.35`, Height `2`, Slope Limit `45`, Step Offset `0.3`, Skin Width `0.08`, Min Move Distance `0`.
5. Assign config, camera transform, action references, Animator, and interaction component on `ThirdPersonPlayer`.
6. Add a camera with `OrbitCamera`; assign Somchai as target, the Look action, and exclude the Player layer from its collision mask.
7. Create a fallback spawn Transform above a Plane/Terrain and assign it to `SpawnRecovery`.
8. Add TerrainCollider or MeshCollider surfaces. Ensure their layers are included in the default physics layer mask and do not use trigger-only ground.
9. Animator parameters must be `Speed` float, `Grounded` bool, `Running` bool, and `VerticalVelocity` float.

## Acceptance criteria / เกณฑ์ผ่าน

- Play mode starts without `GameBootstrap` configuration errors.
- Somchai moves relative to the camera, rotates toward movement, and can run.
- Hunger and energy decrease over time.
- Exiting or pausing writes a JSON save under `Application.persistentDataPath`; reopening restores position and needs.
- EditMode test `SaveData_RoundTripsJson` passes.
- Jump lands without falling through Plane, TerrainCollider, or MeshCollider surfaces.
- Camera stops before walls and does not clip through them.
- Pressing E invokes an `IInteractable` in the center ray; distant objects are ignored.
- A player below `minimumY` or without a valid ground probe is returned to a safe fallback spawn.
- Placeholder controller generation creates all required states and parameters.
- Interaction points align only actors inside their configured radius.
- Invalid clothing slots/variants fail safely without throwing.
- NPC LOD rules select full, medium, and abstract behavior at configured ranges.
- Schedule windows work across midnight and do not require a per-NPC Update loop.
- NPC simulation processes no more than `updatesPerFrame` agents per frame.
- NPC pool reuses disabled instances and crowd spawning skips points outside the NavMesh.
- Pedestrians stop for colliders on the configured vehicle mask and resume when clear.
- Vehicle input is clamped and rejected when the sender lacks authority.
- Driver entry/exit, fuel consumption, braking, collision damage, parking occupancy, and traffic-light stopping are testable in the vehicle scene.
- Cars and motorcycles use separate prefab dimensions and WheelCollider layouts without shared assumptions.

## Validation status

The repository did not contain a Unity project when Phase 01 started, so Unity Editor compilation and scene validation cannot be run in this environment. The C# source is structured for Unity 6.3 LTS and the package versions are pinned, but the Inspector and package-resolution steps above require a local Unity Editor run.

## Performance and security notes

Ground safety uses CharacterController collision resolution plus a non-trigger SphereCast ground probe, and spawn recovery uses a downward Raycast before re-enabling the controller. TerrainCollider and MeshCollider compatibility depends on correct collider layers and enabled colliders in the scene. Save data is local and not authoritative; it must not be reused for multiplayer economy or inventory.

## Phase 03 GIS setup / การตั้งค่า GIS

1. Create `GISProjectConfig` from `Ayutthaya/GIS/Project Config`.
2. Enter the selected demo tile bounds and a documented WGS84 origin. Do not use a guessed origin.
3. Put a manually prepared `source-manifest.json` at `Assets/GIS/Sources/` and record one manifest entry per roads, rivers, building footprints, land use, elevation, and spawn-point source.
4. Create `GISTileDefinition` assets for each additive scene. Assign source paths, tile bounds, scene path, and LOD.
5. Add `OriginShifter` to the persistent world root, assign the player and streamed world root, and keep the shift threshold larger than the largest gameplay interaction radius.
6. Add `AdditiveTileLoader` to the persistent scene, assign the project reference, player, and tile definitions. The loader converts tile centers through the geographic reference; it does not compare latitude/longitude as meters.
7. Run `Ayutthaya/GIS/Validate Project Config` before importing or committing tile scenes.

## Phase 04 animation setup / การตั้งค่า animation

1. In Unity, run `Ayutthaya/Animation/Create Somchai Placeholder Controller`. This creates `Assets/Animation/Somchai/Somchai.controller` and placeholder clips.
2. Assign the generated controller to a Humanoid `Animator` on Somchai. Set Avatar to a valid licensed/owned Humanoid Avatar and enable IK Pass on the gameplay layer when IK is required.
3. Add `SomchaiAnimatorDriver`, `SomchaiIKController`, and optionally `ClothingCustomization` to the character root. Assign the Animator and `ThirdPersonPlayer` references.
4. Replace placeholder clips only with animation assets that the project is licensed to use. The builder intentionally creates no copied or third-party animation data.
5. Use these Animator parameters: `Speed` float, `Grounded` bool, `Running` bool, `VerticalVelocity` float, `Interact` trigger, `Sit` bool, `Sleep` bool, `Farm` bool.
6. Add `AnimationEventRelay` to the animated character and add clip events calling `Relay(string eventName)` for events such as `Footstep`, `HandContact`, `ToolImpact`, or `InteractionComplete`.
7. Add `InteractionPoint` to chairs, beds, farming spots, and workstations. Assign an alignment Transform and select the point type. Call `Align(actor)` before requesting `Sit`, `Sleep`, or `Farm`.
8. Implement `ISomchaiIKTarget` on a scene component that exposes hand/foot targets. Assign that component to `SomchaiIKController.targetProvider`.
9. Configure clothing slots with stable IDs and material variants. Use `Apply(slotId, variantIndex)` from save/load or customization UI.

### Animation contract / สัญญาของระบบ

`ThirdPersonPlayer` remains responsible for movement physics. `SomchaiAnimatorDriver` is presentation-only and must not author movement or save data. Animation events are notifications, not authority for money, inventory, or multiplayer transactions. In multiplayer, animation requests must be validated by the server-side gameplay state.

## Phase 05 NPC setup / การตั้งค่า NPC

1. Resolve `com.unity.ai.navigation` `2.0.9`, add a `NavMeshSurface` to each streamed world tile, and bake the walkable surface after roads/sidewalks/terrain are present. Unity documents AI Navigation 2.0.9 for Unity 6.0 and its NavMeshSurface/NavMeshAgent workflow.
2. Create `NPCProfile` assets with bilingual names, occupation, walk/run speeds, and schedule entries. Use scene transforms for home, shop, farm, eat, and talk destinations.
3. Create a civilian prefab with `NavMeshAgent`, `CivilianNPC`, optional `Animator`, `NPCRelationshipStore`, `NPCConversation`, and an activity handler (`ShopkeeperActivity` or `FarmerActivity`).
4. Set the NavMeshAgent radius/height to match the prefab capsule. Keep pedestrian agents on a pedestrian NavMesh area; do not bake vehicle lanes as pedestrian walkable unless crossings are explicitly designed.
5. Add `NPCSimulationManager` to a persistent simulation scene. Assign player transforms, NPC instances, full distance, medium distance, and `updatesPerFrame`.
6. Add `NPCPool` and `CrowdSpawner`. Assign the same prefab and spawn points sampled onto the NavMesh. Spawning never fabricates a valid position when NavMesh sampling fails.
7. Add `TrafficSafePedestrian` and set `vehicleMask` to vehicle colliders. This is a local safety pause, not a traffic simulation or a replacement for road rules.
8. Use `Full` LOD near players for NavMesh movement and animation, `Medium` LOD for lower-frequency schedule decisions, and `Abstract` LOD for schedule-only simulation with the NavMeshAgent disabled.

### NPC budget contract / สัญญา budget

`NPCSimulationManager` updates at most `updatesPerFrame` NPCs and uses a rotating cursor. The `Ayutthaya.NPC.SimulationBudget` Profiler marker measures that work. Do not add per-NPC `Update()` loops for schedule logic; expensive path requests must remain within the manager budget.

## Phase 06 vehicle setup / การตั้งค่าระบบรถ

1. Create `VehicleDefinition` assets for each original car and motorcycle. Set mass, engine force, braking force, maximum speed, fuel capacity, burn rate, and steering limit.
2. Create a vehicle prefab with `Rigidbody`, `VehicleController`, `VehicleFuel`, `VehicleCollisionDamage`, one `VehicleSeat` driver component, optional passenger seat, body collider, and WheelColliders. Set Rigidbody interpolation to Interpolate, collision detection to Continuous Dynamic, and center of mass below the visual body.
3. For cars, use four WheelColliders with front steering and rear/front drive as appropriate. For motorcycles, use two WheelColliders, a narrow capsule/body collider, and a lower center of mass. Do not use copyrighted vehicle meshes or names.
4. Create sit/exit transforms on each `VehicleSeat`. `TryEnter(actor)` stores the driver and disables the actor while seated; `ExitDriver()` restores the actor at the exit transform.
5. Build a `LaneGraph` from `LaneNode` objects. Each node must reference only legal next nodes, use a speed limit, and be placed on the corresponding road lane. Do not use latitude/longitude as Unity meters.
6. Add `TrafficLight` objects to an `Intersection` and assign signal indexes to `NPCDriver`. NPC drivers stop on red/amber and choose the next lane node after reaching a node.
7. Add `ParkingSpot` objects with alignment transforms. Parking is occupancy-based and does not teleport a vehicle unless the caller explicitly requests parking.
8. Set `vehicleMask`/physics layers so `TrafficSafePedestrian` and vehicle collision checks see vehicle colliders. Use PhysicMaterials with documented friction/bounce values; avoid unbounded bounciness.
9. For multiplayer, set replicated vehicles to `VehicleAuthority.Server`. Only server-approved inputs may call `SetInput`; clients must send input intent, never authoritative position, fuel, damage, or parking results.

### Vehicle authority contract / สัญญา authority

`VehicleController` accepts local input only from its assigned driver or local AI, and accepts arbitrary input only when configured as `Server`. This is an authority boundary, not a full networking transport. A future network adapter must validate ownership, throttle/rate-limit commands, reconcile transforms, and persist fuel/damage server-side.

## Phase 07 farming setup / การตั้งค่า farming

1. Create a `CropDefinition` asset for rice. Configure bilingual names, suitable seasons, growth stage durations, base yield, base quality, and seed cost. No real-world yield or price is assumed by code.
2. Add `SeasonCalendar`, `FarmWeatherService`, `FarmPlot`, `FarmStorage`, `FarmProgression`, and optional `FarmMarket` to the farm scene.
3. Configure a plot with an interaction point and `FarmInteraction`. The interaction requires the actor to be within the point radius and emits the existing `Interact` Animator trigger.
4. Use `PrepareSoil`, `Plant`, `Irrigate`, `Fertilize`, `SimulateDay`, and `TryHarvest` as the authoritative plot lifecycle. Weather changes moisture and growth multiplier; fertilizer affects quality as an abstract resource.
5. Add `FarmMachine` with `Tractor`, `WaterPump`, or `Harvester` type. Machines operate on plots but do not bypass crop lifecycle rules.
6. Add `FarmStorage` to a warehouse/silo. `FarmMarket.TrySell` removes produce and returns a calculated value only when the transaction authority permits it.
7. Connect `FarmUIModel.GetState()` to a UI Toolkit or Canvas view. It exposes stage, moisture, quality, and farm level without coupling simulation to presentation.
8. Save farm data with `FarmPersistence` using a separate `.farm.json` payload. In online mode, use a server-side implementation of `IFarmTransactionAuthority`; clients must send intent, never crop quantity, quality, storage, or sale results.

### Farming acceptance / เกณฑ์ผ่าน

- Soil can be prepared, suitable-season crops planted, irrigated, grown, and harvested.
- Rain/storm/drought alter irrigation or growth without inventing weather history.
- Yield and quality are deterministic from configured crop data, plot state, and weather.
- Storage capacity prevents overfilling; sales cannot remove more produce than stored.
- Farm persistence is versioned and separate from player save data.
- Tests cover season/progression/storage contracts; Unity Editor validation must cover actual plot prefabs, UI, animations, and save/load scenes.

## Data accuracy and licensing / ความแม่นยำและใบอนุญาต

OpenStreetMap data is governed by ODbL and requires attribution; downstream database/share-alike obligations must be reviewed before distribution. Copernicus DEM is a DSM rather than a bare terrain DTM, and the selected instance, access class, release, and license notice must be recorded in the manifest. The importer therefore refuses to treat missing metadata as proof of accuracy. Source resolution, capture date, CRS, vertical datum, and missing geometry must remain visible in the manifest and build report.

The current repository contains no OSM extract, DEM, aerial imagery, buildings, roads, rivers, or land-use data. Consequently, no geographic mesh, terrain heightfield, or spawn point has been invented here. Actual vector/raster conversion should be performed by a separately verified GIS preprocessing step (for example GDAL/QGIS), then admitted only after the manifest and tile validator pass.

เครื่องมือในเฟสนี้ตรวจโครงสร้างและ metadata เท่านั้น ไม่ได้ยืนยันความแม่นยำเชิงภูมิศาสตร์แทนผู้ให้บริการข้อมูล OSM ใช้ ODbL และต้องมี attribution ส่วน Copernicus DEM เป็น DSM ไม่ใช่ DTM ล้วน จึงต้องบันทึกชนิดข้อมูล release, CRS, vertical datum และข้อจำกัดทุกครั้ง

## Next phase gate

Do not start Phase 05 until the Phase 04 controller is generated in Unity, a valid Humanoid Avatar is assigned, placeholder clips are replaced or explicitly approved, animation events are manually tested, and EditMode tests pass.
