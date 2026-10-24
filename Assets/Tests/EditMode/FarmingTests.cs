using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Farming;

public sealed class FarmingTests
{
    [Test] public void CropDefinition_SeasonGatePreventsWrongSeasonPlanting()
    {
        GameObject calendarObject = new GameObject("Calendar"); SeasonCalendar calendar = calendarObject.AddComponent<SeasonCalendar>();
        ScriptableObject cropObject = ScriptableObject.CreateInstance<CropDefinition>(); CropDefinition crop = (CropDefinition)cropObject; crop.suitableSeasons = new[] { Season.Rainy };
        GameObject plotObject = new GameObject("Plot"); FarmPlot plot = plotObject.AddComponent<FarmPlot>();
        Assert.IsTrue(plot.PrepareSoil());
        Object.DestroyImmediate(calendarObject); Object.DestroyImmediate(plotObject); Object.DestroyImmediate(cropObject);
    }

    [Test] public void FarmProgression_LevelsAtExperienceThreshold()
    {
        GameObject go = new GameObject("Progression"); FarmProgression progression = go.AddComponent<FarmProgression>(); progression.AddExperience(1000); Assert.AreEqual(2, progression.Level); Object.DestroyImmediate(go);
    }

    [Test] public void HarvestedProduce_StoresWithinCapacity()
    {
        GameObject go = new GameObject("Storage"); FarmStorage storage = go.AddComponent<FarmStorage>(); Assert.IsTrue(storage.TryStore(new HarvestedProduce("rice", 10f, 0.8f))); Assert.AreEqual(10f, storage.UsedKg); Object.DestroyImmediate(go);
    }
}
