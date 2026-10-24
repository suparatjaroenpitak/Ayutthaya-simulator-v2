# Script inventory / รายการสคริปต์จริง Phase 1–18

Generated from source. Field declarations below are exact source defaults, not recommended production tuning.
รายการนี้แสดงชนิดข้อมูลและค่าเริ่มต้นจากซอร์ส ไม่ใช่การรับรองว่าระบบครบหรือพร้อม production

MonoBehaviour: attach to a GameObject only when its class matches the filename. ScriptableObject: create a data asset, do not attach to a model. Plain classes/interfaces: construct or use from code.
MonoBehaviour ใส่ GameObject; ScriptableObject สร้างเป็น asset แล้วลากลงช่องอ้างอิง; class/interface ธรรมดาห้ามลากใส่โมเดล

## Assets/Editor/BuildPipelineTools.cs — Phase Editor / prototype

- `BuildPipelineTools`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Editor/GISTileValidator.cs — Phase Editor / prototype

- `GISTileValidator`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Editor/OsmTerrainBuilder.cs — Phase Editor / prototype

- `OsmTerrainBuilder`: Code only / เรียกจากโค้ด; base: `none`.
- `Point`: Code only / เรียกจากโค้ด; base: `none`.
- `Road`: Code only / เรียกจากโค้ด; base: `none`.
- `Surface`: Code only / เรียกจากโค้ด; base: `none`.
- `Map`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string id;
public Point[] points;
public float width;
public string kind;
public Point[] points;
public Road[] roads;
public Surface[] surfaces;
```

## Assets/Editor/SomchaiAnimatorControllerBuilder.cs — Phase Editor / prototype

- `SomchaiAnimatorControllerBuilder`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Animation/AnimationEventRelay.cs — Phase 04

- `AnimationEventRelay`: Component / ใส่ GameObject; base: `MonoBehaviour`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Animation/ClothingCustomization.cs — Phase 04

- `ClothingSlot`: Code only / เรียกจากโค้ด; base: `none`.
- `ClothingCustomization`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string id;
public SkinnedMeshRenderer renderer;
public Material[] variants;
[SerializeField] private ClothingSlot[] slots = Array.Empty<ClothingSlot>();
```

## Assets/Scripts/Animation/InteractionPoint.cs — Phase 04

- `InteractionPoint`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private InteractionPointType type;
[SerializeField] private Transform alignment;
[SerializeField] private float useRadius = 1.25f;
public InteractionPointType Type => type;
public Transform Alignment => alignment == null ? transform : alignment;
```

## Assets/Scripts/Animation/SomchaiAnimationState.cs — Phase 04


No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Animation/SomchaiAnimatorDriver.cs — Phase 04

- `SomchaiAnimatorDriver`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Required components / ต้องมี: typeof(Animator)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Animator animator;
[SerializeField] private ThirdPersonPlayer player;
public SomchaiAnimationState CurrentState => state;
```

## Assets/Scripts/Animation/SomchaiIK.cs — Phase 04

- `SomchaiIKController`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Required components / ต้องมี: typeof(Animator)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Animator animator;
[SerializeField] private MonoBehaviour targetProvider;
[SerializeField] private float bodyWeight = 0.25f;
```

## Assets/Scripts/Build/BuildProfile.cs — Phase 18

- `BuildProfile`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string productName = "AYUTTHAYA SIMULATOR";
public string version = "0.18.0";
public int bundleVersionCode = 18;
public BuildTargetProfile target = BuildTargetProfile.WindowsClient;
public string[] scenes = { "Assets/Scenes/Bootstrap.unity" };
public bool developmentBuild;
public bool scriptDebugging;
public bool connectProfiler;
public string configurationFile = "BuildConfig.json";
```

## Assets/Scripts/Build/CrashLogService.cs — Phase 18

- `CrashLogService`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private string folderName = "CrashReports";
```

## Assets/Scripts/Build/RuntimeConfiguration.cs — Phase 18

- `RuntimeConfiguration`: Code only / เรียกจากโค้ด; base: `none`.
- `RuntimeConfigurationLoader`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string environment = "production";
public string serverEndpoint;
public string buildVersion;
public string contentRevision;
public bool onlineEnabled = true;
```

## Assets/Scripts/Economy/Accounts.cs — Phase 09

- `Wallet`: Component / ใส่ GameObject; base: `MonoBehaviour, IAccount`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `BankAccount`: Component / ใส่ GameObject; base: `MonoBehaviour, IAccount`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private long balanceSatang;
public long BalanceSatang => balanceSatang;
[SerializeField] private long balanceSatang;
public long BalanceSatang => balanceSatang;
```

## Assets/Scripts/Economy/Currency.cs — Phase 09


Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public readonly long Satang;
public decimal Baht => Satang / 100m;
```

## Assets/Scripts/Economy/EconomyUIModel.cs — Phase 09

- `EconomyUIModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Wallet wallet;
[SerializeField] private BankAccount bank;
```

## Assets/Scripts/Economy/Inventory.cs — Phase 09

- `Inventory`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private int capacity = 50;
```

## Assets/Scripts/Economy/Jobs.cs — Phase 09

- `JobDefinition`: Data asset / สร้าง asset; base: `ScriptableObject`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `JobProgression`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `JobPayoutService`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string jobId;
public string titleThai;
public string titleEnglish;
public JobType type;
public long wageSatang;
public int experience;
public bool legal = true;
public string jobId;
public int level;
public int experience;
[SerializeField] private JobLevel[] levels = Array.Empty<JobLevel>();
[SerializeField] private EconomyLedger ledger;
```

## Assets/Scripts/Economy/ProductAndPrices.cs — Phase 09

- `ProductDefinition`: Data asset / สร้าง asset; base: `ScriptableObject`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `PriceBook`: Data asset / สร้าง asset; base: `ScriptableObject`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string productId;
public string displayNameThai;
public string displayNameEnglish;
public float weightKg = 1f;
public bool legal = true;
public string productId;
public long buyPriceSatang;
public long sellPriceSatang;
public PriceEntry[] entries = Array.Empty<PriceEntry>();
```

## Assets/Scripts/Economy/Shop.cs — Phase 09

- `Shop`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private PriceBook prices;
[SerializeField] private EconomyLedger ledger;
[SerializeField] private Inventory stock;
```

## Assets/Scripts/Economy/Transactions.cs — Phase 09

- `EconomyLedger`: Component / ใส่ GameObject; base: `MonoBehaviour, IEconomyAuthority`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string transactionId;
public string actorId;
public EconomyTransactionType type;
public long amountSatang;
public string rewardId;
public string createdAtUtc;
[SerializeField] private bool serverMode = true;
[SerializeField] private long maxTransactionSatang = 100000000;
public IReadOnlyList<EconomyAuditEntry> Audit => audit;
```

## Assets/Scripts/Farming/CropDefinition.cs — Phase 07

- `CropDefinition`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public CropGrowthStage stage;
public float days;
public string cropId = "rice";
public string displayNameThai = "ข้าว";
public string displayNameEnglish = "Rice";
public Season[] suitableSeasons = { Season.Rainy };
public GrowthStageDefinition[] growthStages = Array.Empty<GrowthStageDefinition>();
public float baseYieldKg = 500f;
public float baseQuality = 0.7f;
public int seedCost = 10;
```

## Assets/Scripts/Farming/FarmInteraction.cs — Phase 07

- `FarmInteraction`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private FarmPlot plot;
[SerializeField] private InteractionPoint point;
[SerializeField] private Animator animator;
```

## Assets/Scripts/Farming/FarmMachinery.cs — Phase 07

- `FarmMachine`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private FarmMachineType type;
[SerializeField] private float operationPower = 1f;
public FarmMachineType Type => type;
```

## Assets/Scripts/Farming/FarmPersistence.cs — Phase 07

- `FarmSaveData`: Code only / เรียกจากโค้ด; base: `none`.
- `FarmPersistence`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string plotId;
public string cropId;
public CropGrowthStage stage;
public float moisture;
public float quality;
public float growthDays;
public int schemaVersion = 1;
public FarmPlotSave[] plots = Array.Empty<FarmPlotSave>();
```

## Assets/Scripts/Farming/FarmPlot.cs — Phase 07

- `FarmPlot`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private CropDefinition crop;
[SerializeField] private FarmWeatherService weather;
[SerializeField] private SeasonCalendar calendar;
[SerializeField] private float moisture;
[SerializeField] private float fertilizer;
[SerializeField] private float growthDays;
[SerializeField] private CropGrowthStage stage = CropGrowthStage.Empty;
[SerializeField] private float quality = 1f;
public CropGrowthStage Stage => stage;
public float Moisture => moisture;
public float Quality => quality;
public string CropId => crop == null ? string.Empty : crop.cropId;
public float GrowthDays => growthDays;
public string cropId;
public float kilograms;
public float quality;
```

## Assets/Scripts/Farming/FarmProgression.cs — Phase 07

- `FarmProgression`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private int startingLevel = 1;
```

## Assets/Scripts/Farming/FarmResources.cs — Phase 07

- `FarmStorage`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `FarmMarket`: Component / ใส่ GameObject; base: `MonoBehaviour, IFarmTransactionAuthority`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private float capacityKg = 5000f;
[SerializeField] private FarmStorage storage;
[SerializeField] private int pricePerKg = 12;
[SerializeField] private bool serverAuthority = true;
```

## Assets/Scripts/Farming/FarmUIModel.cs — Phase 07

- `FarmUIModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public readonly CropGrowthStage stage;
public readonly float moisture;
public readonly float quality;
public readonly int level;
[SerializeField] private FarmPlot selectedPlot;
[SerializeField] private FarmProgression progression;
```

## Assets/Scripts/Farming/FarmWeather.cs — Phase 07

- `FarmWeatherService`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private FarmWeather current = FarmWeather.Clear;
[SerializeField] private float irrigationFromRain = 0.25f;
public FarmWeather Current => current;
public float GrowthMultiplier => current == FarmWeather.Storm ? 0.75f : current == FarmWeather.Drought ? 0.35f : 1f;
public float IrrigationAmount => current == FarmWeather.Rain ? irrigationFromRain : current == FarmWeather.Storm ? irrigationFromRain * 2f : 0f;
```

## Assets/Scripts/Farming/SeasonCalendar.cs — Phase 07

- `SeasonCalendar`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private int daysPerSeason = 30;
[SerializeField] private int startDay = 1;
public Season CurrentSeason => (Season)(((Day - 1) / Mathf.Max(1, daysPerSeason)) % 3);
```

## Assets/Scripts/GIS/AdditiveTileLoader.cs — Phase 03

- `AdditiveTileLoader`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Transform player;
[SerializeField] private GISProjectConfig project;
[SerializeField] private GISTileDefinition[] tiles = new GISTileDefinition[0];
[SerializeField] private float loadRadius = 900f;
[SerializeField] private float unloadRadius = 1200f;
```

## Assets/Scripts/GIS/GeoReference.cs — Phase 03

- `GeoReference`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public double latitude;
public double longitude;
public double elevationMeters;
public double originLatitude;
public double originLongitude;
public double metersPerUnit = 1.0;
```

## Assets/Scripts/GIS/GISProjectConfig.cs — Phase 03

- `GISProjectConfig`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string projectId;
public string coordinateReferenceSystem = "EPSG:4326 input;
public GeoReference reference = new GeoReference();
public BoundsGeo areaOfInterest;
public string sourceManifestPath = "Assets/GIS/Sources/source-manifest.json";
public string outputRoot = "Assets/World/Tiles";
public int tileSizeMeters = 512;
public int maxLod = 3;
public bool requireLicensedSourceMetadata = true;
public double minLatitude;
public double minLongitude;
public double maxLatitude;
public double maxLongitude;
public bool IsValid => minLatitude < maxLatitude && minLongitude < maxLongitude && minLatitude >= -90 && maxLatitude <= 90 && minLongitude >= -180 && maxLongitude <= 180;
```

## Assets/Scripts/GIS/GISTileDefinition.cs — Phase 03

- `GISTileDefinition`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string tileId;
public BoundsGeo bounds;
public string scenePath;
public string terrainSourcePath;
public string roadsSourcePath;
public string riversSourcePath;
public string buildingsSourcePath;
public string landUseSourcePath;
public int lod;
public bool IsValid => !string.IsNullOrWhiteSpace(tileId) && bounds.IsValid && !string.IsNullOrWhiteSpace(scenePath);
public string id;
public double latitude;
public double longitude;
public float elevationMeters;
public string category;
```

## Assets/Scripts/GIS/OriginShifter.cs — Phase 03

- `OriginShifter`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Transform player;
[SerializeField] private Transform worldRoot;
[SerializeField] private float shiftDistance = 2000f;
```

## Assets/Scripts/GIS/SourceManifest.cs — Phase 03

- `SourceManifest`: Code only / เรียกจากโค้ด; base: `none`.
- `SourceManifestCollection`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string datasetName;
public string provider;
public string license;
public string attribution;
public string sourceUrl;
public string acquiredAtUtc;
public string crs;
public string horizontalAccuracyNote;
public string verticalAccuracyNote;
public string missingGeometryNote;
public bool IsComplete => !string.IsNullOrWhiteSpace(datasetName) && !string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(license) && !string.IsNullOrWhiteSpace(attribution) && !string.IsNullOrWhiteSpace(crs);
public SourceManifest[] sources = Array.Empty<SourceManifest>();
```

## Assets/Scripts/Life/HouseholdUtility.cs — Phase 08

- `HouseholdUtility`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private HouseholdUtilityType type;
[SerializeField] private bool available = true;
public HouseholdUtilityType Type => type;
public bool Available => available;
```

## Assets/Scripts/Life/LifeActions.cs — Phase 08

- `LifeActions`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private LifeSimulation simulation;
[SerializeField] private Animator animator;
```

## Assets/Scripts/Life/LifeAuthority.cs — Phase 08

- `ServerLifeAuthority`: Component / ใส่ GameObject; base: `MonoBehaviour, ILifeAuthority`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private bool serverMode = true;
[SerializeField] private float maxActionAmount = 100f;
```

## Assets/Scripts/Life/LifeBalanceConfig.cs — Phase 08

- `LifeBalanceConfig`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public float maxHunger = 100f;
public float maxEnergy = 100f;
public float maxStamina = 100f;
public float maxHealth = 100f;
public float hungerDrain = 2f;
public float energyDrain = 1f;
public float staminaRecovery = 18f;
public float sleepEnergyRecovery = 28f;
public float sleepHealthRecovery = 3f;
public float lowNeedRecoveryThreshold = 10f;
public float passiveHealthRecovery = 0.5f;
```

## Assets/Scripts/Life/LifePersistence.cs — Phase 08

- `LifePersistence`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Life/LifeSimulation.cs — Phase 08

- `LifeSimulation`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private LifeBalanceConfig balance;
[SerializeField] private LifeClock clock;
[SerializeField] private MonoBehaviour weatherProvider;
```

## Assets/Scripts/Life/LifeState.cs — Phase 08

- `LifeSaveData`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public float hunger;
public float energy;
public float stamina;
public float health;
public bool sleeping;
public int schemaVersion = 1;
public LifeState state;
public int day = 1;
public int minuteOfDay = 420;
```

## Assets/Scripts/Life/LifeTime.cs — Phase 08

- `LifeClock`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `DefaultWeatherProvider`: Component / ใส่ GameObject; base: `MonoBehaviour, IWeatherProvider`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private float gameMinutesPerRealSecond = 1f;
[SerializeField] private int startMinute = 420;
public int Hour => MinuteOfDay / 60;
[SerializeField] private string weatherId = "clear";
[SerializeField] private float energyModifier = 1f;
public string CurrentWeatherId => weatherId;
public float EnergyModifier => energyModifier;
```

## Assets/Scripts/Life/LifeUIModel.cs — Phase 08

- `LifeUIModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public readonly bool sleeping;
[SerializeField] private LifeSimulation simulation;
```

## Assets/Scripts/Multiplayer/NetworkConnectionApproval.cs — Phase 12

- `NetworkConnectionApproval`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private NetworkManager manager;
[SerializeField] private int maxPlayers = 2;
[SerializeField] private NetworkSpawnPoint spawnPoint;
```

## Assets/Scripts/Multiplayer/NetworkInteractable.cs — Phase 12

- `NetworkInteractable`: Component / ใส่ GameObject; base: `NetworkBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private string interactionId;
[SerializeField] private float maxDistance = 3f;
[SerializeField] private MonoBehaviour validatorComponent;
```

## Assets/Scripts/Multiplayer/NetworkLobby.cs — Phase 12

- `NetworkLobby`: Component / ใส่ GameObject; base: `NetworkBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public NetworkVariable<int> PlayerCount = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
```

## Assets/Scripts/Multiplayer/NetworkMode.cs — Phase 12


No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Multiplayer/NetworkPlayerAvatar.cs — Phase 12

- `NetworkPlayerAvatar`: Component / ใส่ GameObject; base: `NetworkBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private float moveSpeed = 4.5f;
[SerializeField] private float interpolation = 12f;
[SerializeField] private Transform visual;
public NetworkVariable<Vector3> ServerPosition = new NetworkVariable<Vector3>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
```

## Assets/Scripts/Multiplayer/NetworkSessionManager.cs — Phase 12

- `NetworkSessionManager`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private NetworkManager manager;
[SerializeField] private string address = "127.0.0.1";
[SerializeField] private ushort port = 7777;
```

## Assets/Scripts/Multiplayer/NetworkSpawnPoint.cs — Phase 12

- `NetworkSpawnPoint`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private NetworkObject playerPrefab;
[SerializeField] private Transform[] spawnPoints = new Transform[0];
```

## Assets/Scripts/Narrative/Localization.cs — Phase 11

- `DialogueLine`: Data asset / สร้าง asset; base: `ScriptableObject`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `DialogueRunner`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `DialogueSession`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string thai;
public string english;
public string speakerId;
public LocalizedText text;
public string[] nextNodeIds = Array.Empty<string>();
public string requiredFlag;
public string setFlag;
public int relationshipDelta;
[SerializeField] private DialogueLanguage language = DialogueLanguage.Thai;
[SerializeField] private DialogueLine[] nodes = Array.Empty<DialogueLine>();
[SerializeField] private StoryStateService story;
[SerializeField] private NPCRelationshipStore relationships;
```

## Assets/Scripts/Narrative/PrologueAndQuests.cs — Phase 11

- `QuestWritingPack`: Data asset / สร้าง asset; base: `ScriptableObject`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string questId;
public QuestType type;
public LocalizedText title;
public LocalizedText summary;
```

## Assets/Scripts/Narrative/QuestDefinition.cs — Phase 11

- `QuestDefinition`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string requiredFlag;
public string requiredQuestId;
public int minimumRelationship;
public string npcId;
public string objectiveId;
public ObjectiveType type;
public LocalizedText description;
public int requiredAmount;
public string targetId;
public int experience;
public long moneySatang;
public string flagToSet;
public int relationshipDelta;
public string npcId;
public string questId;
public QuestType type;
public LocalizedText title;
public LocalizedText summary;
public QuestPrerequisite[] prerequisites = Array.Empty<QuestPrerequisite>();
public QuestObjective[] objectives = Array.Empty<QuestObjective>();
public QuestReward[] rewards = Array.Empty<QuestReward>();
public bool replaySafe = true;
```

## Assets/Scripts/Narrative/QuestRuntime.cs — Phase 11

- `QuestProgress`: Code only / เรียกจากโค้ด; base: `none`.
- `QuestService`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `ServerQuestAuthority`: Component / ใส่ GameObject; base: `MonoBehaviour, IQuestAuthority`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string questId;
public int[] amounts = Array.Empty<int>();
public bool completed;
[SerializeField] private QuestDefinition[] definitions = Array.Empty<QuestDefinition>();
[SerializeField] private StoryStateService story;
[SerializeField] private Wallet wallet;
[SerializeField] private NPCRelationshipStore relationships;
[SerializeField] private MonoBehaviour authorityComponent;
[SerializeField] private bool serverMode = true;
```

## Assets/Scripts/Narrative/QuestUIModel.cs — Phase 11

- `QuestUIModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private QuestService quests;
```

## Assets/Scripts/Narrative/StoryState.cs — Phase 11

- `StoryState`: Code only / เรียกจากโค้ด; base: `none`.
- `StoryStateService`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string[] flags = Array.Empty<string>();
public string[] completedQuests = Array.Empty<string>();
```

## Assets/Scripts/NPC/CivilianNPC.cs — Phase 05

- `CivilianNPC`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Required components / ต้องมี: typeof(NavMeshAgent)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private NPCProfile profile;
[SerializeField] private Animator animator;
[SerializeField] private float destinationTolerance = 1.2f;
public NPCAISimulationLOD CurrentLOD => lod;
public int CurrentMinute => currentMinute;
```

## Assets/Scripts/NPC/CrowdSpawner.cs — Phase 05

- `CrowdSpawner`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private NPCPool pool;
[SerializeField] private NPCProfile[] profiles = new NPCProfile[0];
[SerializeField] private Transform[] spawnPoints = new Transform[0];
[SerializeField] private int count = 20;
[SerializeField] private float sampleRadius = 4f;
```

## Assets/Scripts/NPC/NPCActivities.cs — Phase 05

- `ShopkeeperActivity`: Component / ใส่ GameObject; base: `MonoBehaviour, INPCActivityHandler`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `FarmerActivity`: Component / ใส่ GameObject; base: `MonoBehaviour, INPCActivityHandler`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/NPC/NPCConversation.cs — Phase 05

- `NPCConversation`: Component / ใส่ GameObject; base: `MonoBehaviour, IConversationParticipant`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private string conversationId = "generic_civilian";
public string ConversationId => conversationId;
```

## Assets/Scripts/NPC/NPCLOD.cs — Phase 05

- `NPCLodRules`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/NPC/NPCPool.cs — Phase 05

- `NPCPool`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private CivilianNPC prefab;
[SerializeField] private int initialSize = 32;
```

## Assets/Scripts/NPC/NPCProfile.cs — Phase 05

- `NPCProfile`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public int startMinute;
public int endMinute;
public NPCActivity activity;
public Transform target;
public string profileId;
public string displayNameThai;
public string displayNameEnglish;
public NPCOccupation occupation;
public ScheduleEntry[] schedule = Array.Empty<ScheduleEntry>();
public float walkSpeed = 1.5f;
public float runSpeed = 3.5f;
public float talkDistance = 2f;
public float spawnWeight = 1f;
```

## Assets/Scripts/NPC/NPCRelationships.cs — Phase 05

- `NPCRelationshipStore`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string otherId;
public int value;
[SerializeField] private RelationshipValue[] initialValues = Array.Empty<RelationshipValue>();
```

## Assets/Scripts/NPC/NPCSimulationManager.cs — Phase 05

- `NPCSimulationManager`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Transform[] players = new Transform[0];
[SerializeField] private CivilianNPC[] civilians = new CivilianNPC[0];
[SerializeField] private float fullDistance = 40f;
[SerializeField] private float mediumDistance = 180f;
[SerializeField] private int updatesPerFrame = 32;
[SerializeField] private float gameMinutesPerSecond = 1f;
[SerializeField] private int startMinute = 480;
public int CurrentMinute => currentMinute;
```

## Assets/Scripts/NPC/TrafficSafePedestrian.cs — Phase 05

- `TrafficSafePedestrian`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Required components / ต้องมี: typeof(NavMeshAgent)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private LayerMask vehicleMask;
[SerializeField] private float lookAhead = 3f;
[SerializeField] private float safetyRadius = 1.2f;
```

## Assets/Scripts/Operations/GracefulServerShutdown.cs — Phase 14

- `GracefulServerShutdown`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private MonoBehaviour[] handlers = Array.Empty<MonoBehaviour>();
```

## Assets/Scripts/Operations/LoadTestHarness.cs — Phase 14

- `LoadTestHarness`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private int virtualPlayers = 100;
[SerializeField] private float requestsPerSecond = 5f;
[SerializeField] private ServerObservability observability;
```

## Assets/Scripts/Operations/ServerObservability.cs — Phase 14

- `ServerObservability`: Component / ใส่ GameObject; base: `MonoBehaviour`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Operations/ShardAllocation.cs — Phase 14

- `ShardAssignment`: Code only / เรียกจากโค้ด; base: `none`.
- `ShardRoutingClient`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string shardId;
public string zoneId;
public string endpoint;
public bool accepted;
```

## Assets/Scripts/Operations/TransportSecurityConfig.cs — Phase 14

- `TransportSecurityConfig`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public bool requireAuthenticatedRelay = true;
public bool allowDirectIpForDevelopment = true;
public bool rejectUnencryptedProductionTransport = true;
public string certificateProviderContract = "Configure TLS/DTLS or a trusted Relay provider in deployment adapter";
public bool IsProductionSafeWithoutAdapter => !rejectUnencryptedProductionTransport;
```

## Assets/Scripts/Performance/AITickBudget.cs — Phase 16

- `AITickBudget`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private MonoBehaviour[] agents = new MonoBehaviour[0];
[SerializeField] private int updatesPerFrame = 32;
```

## Assets/Scripts/Performance/BenchmarkReport.cs — Phase 16

- `BenchmarkReport`: Code only / เรียกจากโค้ด; base: `none`.
- `BenchmarkReportWriter`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string scenarioId;
public string runId;
public string capturedAtUtc;
public string hardware;
public List<BenchmarkSample> samples = new List<BenchmarkSample>();
public string[] limitations = { "Unity Editor capture required", "No FPS result is valid until sealed telemetry is verified" };
[SerializeField] private BenchmarkScenario scenario;
[SerializeField] private PerformanceTelemetry telemetry;
```

## Assets/Scripts/Performance/BenchmarkScenario.cs — Phase 16

- `BenchmarkScenario`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string scenarioId = "phase16-open-world-baseline";
public string scenePath;
public int seed = 1601;
public int durationSeconds = 120;
public int npcCount = 100;
public int vehicleCount = 30;
public int streamedTileCount = 4;
public string rendererPath = "URP";
public string hardwareDescription = "Record in the run bundle;
public string[] metrics = { "frame_time_ms", "draw_calls", "triangles", "gc_bytes", "physics_ms", "npc_updates", "streaming_ms", "network_bytes" };
```

## Assets/Scripts/Performance/InstancedMeshBatch.cs — Phase 16

- `InstancedMeshBatch`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Mesh mesh;
[SerializeField] private Material material;
[SerializeField] private Matrix4x4[] instances = new Matrix4x4[0];
```

## Assets/Scripts/Performance/ObjectPool.cs — Phase 16

- `ObjectPool`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private GameObject prefab;
[SerializeField] private int initialSize = 32;
```

## Assets/Scripts/Performance/PerformanceConfig.cs — Phase 16

- `QualityPreset`: Data asset / สร้าง asset; base: `ScriptableObject`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string presetId = "medium";
public float renderScale = 1f;
public float terrainDetailDistance = 0.7f;
public float npcSimulationDistance = 0.7f;
public int npcUpdatesPerFrame = 32;
public int shadowCascades = 2;
public bool enableOcclusion = true;
public bool enableGpuInstancing = true;
```

## Assets/Scripts/Performance/PerformanceTelemetry.cs — Phase 16

- `PerformanceTelemetry`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public float frameMs;
public long drawCalls;
public long triangles;
public long gcBytes;
public long physicsMs;
public long networkBytes;
[SerializeField] private bool capture;
```

## Assets/Scripts/Performance/QualityPresetRuntime.cs — Phase 16

- `QualityPresetRuntime`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private QualityPreset preset;
```

## Assets/Scripts/Performance/WorldStreamingBudget.cs — Phase 16

- `WorldStreamingBudget`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private int maxTileOperationsPerFrame = 1;
public int MaxTileOperationsPerFrame => maxTileOperationsPerFrame;
```

## Assets/Scripts/Persistence/AuthenticationContracts.cs — Phase 13

- `AuthSession`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string accountId;
public string accessToken;
public DateTime expiresAtUtc;
public bool IsValid => !string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(accessToken) && expiresAtUtc > DateTime.UtcNow;
```

## Assets/Scripts/Persistence/OfflineSaveSlots.cs — Phase 13

- `OfflineSaveSlots`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private int currentSchema = 1;
```

## Assets/Scripts/Persistence/OnlinePersistenceClient.cs — Phase 13

- `OnlinePersistenceClient`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private MonoBehaviour authComponent;
[SerializeField] private MonoBehaviour repositoryComponent;
```

## Assets/Scripts/Persistence/PersistenceUIModel.cs — Phase 13

- `PersistenceUIModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Persistence/PersistentModels.cs — Phase 13

- `PersistentPlayerData`: Code only / เรียกจากโค้ด; base: `none`.
- `PersistentWorldData`: Code only / เรียกจากโค้ด; base: `none`.
- `PersistentSaveEnvelope`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string playerId;
public int schemaVersion = 1;
public long walletSatang;
public long bankSatang;
public string[] inventoryIds = Array.Empty<string>();
public int[] inventoryQuantities = Array.Empty<int>();
public string[] propertyIds = Array.Empty<string>();
public string[] questFlags = Array.Empty<string>();
public string[] completedQuests = Array.Empty<string>();
public Vector3 position;
public int schemaVersion = 1;
public int day = 1;
public int minuteOfDay = 420;
public string weatherId = "clear";
public string[] npcIds = Array.Empty<string>();
public string[] npcStates = Array.Empty<string>();
public string[] farmPlotJson = Array.Empty<string>();
public string[] propertyJson = Array.Empty<string>();
public int schemaVersion = 1;
public string saveId;
public string revision;
public string createdAtUtc;
public PersistentPlayerData player = new PersistentPlayerData();
public PersistentWorldData world = new PersistentWorldData();
public readonly bool success;
public readonly PersistenceFailure failure;
public readonly string message;
```

## Assets/Scripts/Persistence/SaveMigration.cs — Phase 13

- `SaveMigrationV1ToV2`: Code only / เรียกจากโค้ด; base: `ISaveMigration`.
- `SaveMigrationRunner`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public int FromVersion => 1;
public int ToVersion => 2;
```

## Assets/Scripts/Property/EnterableDoor.cs — Phase 10

- `EnterableDoor`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private string propertyId;
[SerializeField] private PropertyRegistry registry;
[SerializeField] private InteriorStreamer interiors;
[SerializeField] private Transform entryPoint;
[SerializeField] private bool open;
```

## Assets/Scripts/Property/FurniturePlacement.cs — Phase 10

- `FurniturePlacement`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string decorationId;
public Vector3 position;
public Quaternion rotation;
public string prefabKey;
[SerializeField] private PropertyRegistry registry;
[SerializeField] private string propertyId;
[SerializeField] private Transform placementRoot;
```

## Assets/Scripts/Property/InteriorStreamer.cs — Phase 10

- `InteriorStreamer`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private PropertyRegistry registry;
```

## Assets/Scripts/Property/PropertyDefinition.cs — Phase 10

- `PropertyDefinition`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string propertyId;
public string displayNameThai;
public string displayNameEnglish;
public PropertyType type;
public long purchasePriceSatang;
public long rentPriceSatang;
public string interiorScenePath;
public bool canRent = true;
public bool canPurchase = true;
```

## Assets/Scripts/Property/PropertyPersistence.cs — Phase 10

- `PropertyPersistence`: Code only / เรียกจากโค้ด; base: `none`.
- `PropertySaveData`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public int schemaVersion = 1;
public PropertyState[] states = new PropertyState[0];
```

## Assets/Scripts/Property/PropertyRegistry.cs — Phase 10

- `PropertyRegistry`: Component / ใส่ GameObject; base: `MonoBehaviour, IPropertyAuthority`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private PropertyDefinition[] definitions = new PropertyDefinition[0];
[SerializeField] private PropertyState[] initialStates = new PropertyState[0];
```

## Assets/Scripts/Property/PropertyState.cs — Phase 10

- `PropertyState`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string propertyId;
public string ownerId;
public string tenantId;
public bool rented;
public bool purchased;
public string[] decorationIds = Array.Empty<string>();
```

## Assets/Scripts/Property/PropertyTransactionService.cs — Phase 10

- `PropertyTransactionService`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private PropertyRegistry registry;
[SerializeField] private EconomyLedger ledger;
```

## Assets/Scripts/Property/PropertyUIModel.cs — Phase 10

- `PropertyUIModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private PropertyRegistry registry;
```

## Assets/Scripts/Runtime/GameBootstrap.cs — Phase 01–02

- `GameBootstrap`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private GameConfig config;
[SerializeField] private ThirdPersonPlayer player;
[SerializeField] private PlayerNeeds playerNeeds;
```

## Assets/Scripts/Runtime/GameConfig.cs — Phase 01–02

- `GameConfig`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string gameVersion = "0.2.0-phase02";
public string defaultSaveSlot = "slot_01";
public float walkSpeed = 4.5f;
public float runSpeed = 7f;
public float rotationSharpness = 12f;
public float gravity = 25f;
public float jumpHeight = 1.4f;
public float groundedStickForce = 2f;
public float groundProbeDistance = 0.35f;
public float spawnProbeHeight = 3f;
public float spawnProbeDistance = 20f;
public float cameraDistance = 5f;
public float cameraMinPitch = -35f;
public float cameraMaxPitch = 70f;
public float cameraCollisionRadius = 0.2f;
public float cameraCollisionBuffer = 0.15f;
public float maxHunger = 100f;
public float maxEnergy = 100f;
public float hungerDrainPerMinute = 2f;
public float energyDrainPerMinute = 1f;
```

## Assets/Scripts/Runtime/Grounding.cs — Phase 01–02

- `Grounding`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Runtime/OrbitCamera.cs — Phase 01–02

- `OrbitCamera`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private GameConfig config;
[SerializeField] private Transform target;
[SerializeField] private InputActionReference lookAction;
[SerializeField] private LayerMask collisionMask = Physics.DefaultRaycastLayers;
[SerializeField] private float lookSensitivity = 0.08f;
[SerializeField] private float followSharpness = 14f;
[SerializeField] private float initialPitch = 18f;
[SerializeField] private float initialYaw = 0f;
```

## Assets/Scripts/Runtime/PlayerInteraction.cs — Phase 01–02

- `PlayerInteraction`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Camera playerCamera;
[SerializeField] private float interactionDistance = 3f;
[SerializeField] private LayerMask interactionMask = Physics.DefaultRaycastLayers;
```

## Assets/Scripts/Runtime/PlayerNeeds.cs — Phase 01–02

- `PlayerNeeds`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private GameConfig config;
```

## Assets/Scripts/Runtime/SaveData.cs — Phase 01–02

- `SaveData`: Code only / เรียกจากโค้ด; base: `none`.
- `SaveService`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public int schemaVersion = 1;
public string slotId;
public string savedAtUtc;
public Vector3 playerPosition;
public float hunger;
public float energy;
public int money;
```

## Assets/Scripts/Runtime/SpawnRecovery.cs — Phase 01–02

- `SpawnRecovery`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private GameConfig config;
[SerializeField] private Transform fallbackSpawn;
[SerializeField] private float minimumY = -20f;
[SerializeField] private float checkInterval = 0.25f;
```

## Assets/Scripts/Runtime/ThirdPersonPlayer.cs — Phase 01–02

- `ThirdPersonPlayer`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Required components / ต้องมี: typeof(CharacterController)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private GameConfig config;
[SerializeField] private Transform cameraTransform;
[SerializeField] private InputActionReference moveAction;
[SerializeField] private InputActionReference runAction;
[SerializeField] private InputActionReference jumpAction;
[SerializeField] private InputActionReference interactAction;
[SerializeField] private Animator animator;
[SerializeField] private PlayerInteraction interaction;
public CharacterController Controller => controller;
public bool IsGrounded => controller != null && controller.isGrounded;
```

## Assets/Scripts/Security/MovementSanityValidator.cs — Phase 14

- `MovementSanityValidator`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private float maxSpeed = 12f;
[SerializeField] private float positionTolerance = 4f;
[SerializeField] private float maxVerticalDelta = 8f;
```

## Assets/Scripts/Security/RateLimiter.cs — Phase 14

- `TokenBucketRateLimiter`: Code only / เรียกจากโค้ด; base: `none`.
- `Bucket`: Code only / เรียกจากโค้ด; base: `none`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public float tokens;
public float last;
```

## Assets/Scripts/Security/ServerAuthorityGate.cs — Phase 14

- `ServerAuthorityGate`: Component / ใส่ GameObject; base: `MonoBehaviour, IServerAuthorityGate`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private SessionAuthorizationService sessions;
[SerializeField] private ServerRequestGuard requests;
```

## Assets/Scripts/Security/ServerRequestGuard.cs — Phase 14

- `ServerRequestGuard`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public readonly ServerRequestKind kind;
public readonly float receivedAt;
[SerializeField] private float requestsPerSecond = 20f;
[SerializeField] private float burst = 40f;
```

## Assets/Scripts/Security/SessionAuthorization.cs — Phase 14

- `AuthorizedSession`: Code only / เรียกจากโค้ด; base: `none`.
- `SessionAuthorizationService`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string accountId;
public string sessionId;
public DateTime expiresAtUtc;
public bool revoked;
public bool IsValid => !revoked && !string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(sessionId) && expiresAtUtc > DateTime.UtcNow;
```

## Assets/Scripts/UI/GameHudModel.cs — Phase 15

- `GameHudModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public readonly long walletSatang;
public readonly int questCount;
public readonly string vehicleLabel;
```

## Assets/Scripts/UI/LocalizationService.cs — Phase 15

- `TranslationTable`: Data asset / สร้าง asset; base: `ScriptableObject`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `LocalizationPreferenceService`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public string key;
public string thai;
public string english;
public TranslationRow[] rows = Array.Empty<TranslationRow>();
[SerializeField] private TranslationTable table;
[SerializeField] private UiLanguage language = UiLanguage.Thai;
public UiLanguage Language => language;
```

## Assets/Scripts/UI/NotificationPresenter.cs — Phase 15

- `NotificationPresenter`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private UiEventBus bus;
[SerializeField] private Transform container;
[SerializeField] private GameObject notificationPrefab;
```

## Assets/Scripts/UI/ResponsivePanel.cs — Phase 15

- `ResponsivePanel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private UiPanelId panelId;
[SerializeField] private GameObject content;
[SerializeField] private float compactWidth = 900f;
public UiPanelId PanelId => panelId;
```

## Assets/Scripts/UI/SettingsUiModel.cs — Phase 15

- `SettingsUiModel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private LocalizationPreferenceService localization;
```

## Assets/Scripts/UI/UiEventBus.cs — Phase 15

- `UiEventBus`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public readonly string key;
public readonly string fallback;
public readonly float seconds;
```

## Assets/Scripts/UI/UiPanelController.cs — Phase 15

- `UiPanelController`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private UiEventBus bus;
[SerializeField] private ResponsivePanel[] panels = new ResponsivePanel[0];
```

## Assets/Scripts/UI/UiTextOverflowValidator.cs — Phase 15

- `UiTextOverflowValidator`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Text text;
[SerializeField] private RectTransform bounds;
```

## Assets/Scripts/UI/UiTypes.cs — Phase 15


No simple serialized fields detected; inspect source for properties/methods.

## Assets/Scripts/Vehicles/Intersection.cs — Phase 06

- `Intersection`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private TrafficLight[] signals = new TrafficLight[0];
```

## Assets/Scripts/Vehicles/LaneGraph.cs — Phase 06

- `LaneNode`: Component / ใส่ GameObject; base: `MonoBehaviour`.
  - WARNING / ระวัง: class name differs from filename; split into a matching file before relying on Inspector attachment/asset creation.
- `LaneGraph`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public LaneNode[] next = new LaneNode[0];
public float speedLimitKph = 40f;
public Vector3 Position => transform.position;
[SerializeField] private LaneNode[] nodes = new LaneNode[0];
public IReadOnlyList<LaneNode> Nodes => nodes;
```

## Assets/Scripts/Vehicles/NPCDriver.cs — Phase 06

- `NPCDriver`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Required components / ต้องมี: typeof(VehicleController)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private LaneGraph graph;
[SerializeField] private Intersection intersection;
[SerializeField] private int signalIndex;
```

## Assets/Scripts/Vehicles/ParkingSpot.cs — Phase 06

- `ParkingSpot`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Transform alignment;
public bool IsFree => occupant == null;
```

## Assets/Scripts/Vehicles/TrafficLight.cs — Phase 06

- `TrafficLight`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private float greenSeconds = 20f;
[SerializeField] private float amberSeconds = 3f;
[SerializeField] private float redSeconds = 20f;
```

## Assets/Scripts/Vehicles/VehicleCollisionDamage.cs — Phase 06

- `VehicleCollisionDamage`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private float impactThreshold = 5f;
[SerializeField] private float maxDamage = 100f;
```

## Assets/Scripts/Vehicles/VehicleController.cs — Phase 06

- `VehicleController`: Component / ใส่ GameObject; base: `MonoBehaviour, IVehicleInteractable, IVehicleAuthority`.

Required components / ต้องมี: typeof(Rigidbody), typeof(VehicleFuel)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private VehicleDefinition definition;
[SerializeField] private WheelCollider[] drivenWheels = new WheelCollider[0];
[SerializeField] private WheelCollider[] steeringWheels = new WheelCollider[0];
[SerializeField] private VehicleSeat driverSeat;
[SerializeField] private VehicleSeat passengerSeat;
[SerializeField] private VehicleAuthority authority = VehicleAuthority.Local;
[SerializeField] private GameObject localDriver;
public VehicleAuthority Authority => authority;
```

## Assets/Scripts/Vehicles/VehicleDefinition.cs — Phase 06

- `VehicleDefinition`: Data asset / สร้าง asset; base: `ScriptableObject`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public VehicleKind kind = VehicleKind.Car;
public float mass = 1200f;
public float engineForce = 7000f;
public float brakeForce = 9000f;
public float maxSpeedKph = 90f;
public float fuelCapacityLitres = 45f;
public float fuelBurnLitresPerSecond = 0.012f;
public float steeringLimitDegrees = 28f;
```

## Assets/Scripts/Vehicles/VehicleFuel.cs — Phase 06

- `VehicleFuel`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private VehicleDefinition definition;
[SerializeField] private float litres;
public float Litres => litres;
public bool HasFuel => litres > 0.01f;
```

## Assets/Scripts/Vehicles/VehicleInterfaces.cs — Phase 06


Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public float steering;
public float throttle;
public float brake;
public bool handbrake;
```

## Assets/Scripts/Vehicles/VehicleSeat.cs — Phase 06

- `VehicleSeat`: Component / ใส่ GameObject; base: `MonoBehaviour, IVehicleSeat`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private Transform sitPoint;
[SerializeField] private Transform exitPoint;
public bool IsOccupied => occupant != null;
public GameObject Occupant => occupant;
```

## Assets/Tests/EditMode/BuildTests.cs — Phase 17

- `BuildTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/EconomyTests.cs — Phase 17

- `EconomyTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/FarmingTests.cs — Phase 17

- `FarmingTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/GeoReferenceTests.cs — Phase 17

- `GeoReferenceTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/GroundingTests.cs — Phase 17

- `GroundingTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/LifeSystemsTests.cs — Phase 17

- `LifeSystemsTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/MultiplayerTests.cs — Phase 17

- `MultiplayerTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/NarrativeTests.cs — Phase 17

- `NarrativeTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/NPCSimulationTests.cs — Phase 17

- `NPCSimulationTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/PerformanceTests.cs — Phase 17

- `PerformanceTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/PersistenceTests.cs — Phase 17

- `PersistenceTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/PropertyTests.cs — Phase 17

- `PropertyTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/QATestContracts.cs — Phase 17

- `QATestContracts`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/SaveServiceTests.cs — Phase 17

- `SaveServiceTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/SecurityTests.cs — Phase 17

- `SecurityTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/SomchaiAnimationTests.cs — Phase 17

- `SomchaiAnimationTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/UITests.cs — Phase 17

- `UITests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/EditMode/VehicleSystemTests.cs — Phase 17

- `VehicleSystemTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/PlayMode/GameplayPlayModeTests.cs — Phase 17

- `GameplayPlayModeTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/Tests/PlayMode/LatencyTestAdapter.cs — Phase 17

- `LatencyTestAdapter`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
[SerializeField] private int simulatedLatencyMs = 100;
[SerializeField] private int packetLossPercent;
public int SimulatedLatencyMs => simulatedLatencyMs;
public int PacketLossPercent => packetLossPercent;
```

## Assets/Tests/PlayMode/MultiplayerPlayModeTests.cs — Phase 17

- `MultiplayerPlayModeTests`: Code only / เรียกจากโค้ด; base: `none`.

No simple serialized fields detected; inspect source for properties/methods.

## Assets/WorldPrototype/PrototypeExplorer.cs — Phase Editor / prototype

- `PrototypeExplorer`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Required components / ต้องมี: typeof(CharacterController)

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public Camera view;
public float walkSpeed = 4.5f, runSpeed = 8f, jumpHeight = 1.2f;
public float cameraDistance = 5f;
```

## Assets/WorldPrototype/TerrainVisibility.cs — Phase Editor / prototype

- `TerrainVisibility`: Component / ใส่ GameObject; base: `MonoBehaviour`.

Inspector/data declarations / ฟิลด์ตั้งค่า (รวมฟิลด์ข้อมูลที่ไม่ได้แสดง Inspector):

```csharp
public Transform viewer;
public Terrain[] tiles;
public float drawDistance = 1600;
```
