using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Narrative;

public sealed class NarrativeTests
{
    [Test] public void StoryState_DoesNotDuplicateFlagsOrCompletions() { StoryState state = new StoryState(); state.SetFlag("intro"); state.SetFlag("intro"); state.MarkCompleted("q1"); state.MarkCompleted("q1"); Assert.AreEqual(1, state.flags.Length); Assert.AreEqual(1, state.completedQuests.Length); }
    [Test] public void QuestWritingPack_ContainsPrologueArcAndFiveSideQuests() { QuestWritingPack pack = ScriptableObject.CreateInstance<QuestWritingPack>(); Assert.GreaterOrEqual(pack.entries.Length, 11); Object.DestroyImmediate(pack); }
    [Test] public void LocalizedText_ReturnsRequestedLanguage() { LocalizedText text = new LocalizedText { thai = "ไทย", english = "English" }; Assert.AreEqual("ไทย", text.Get(DialogueLanguage.Thai)); Assert.AreEqual("English", text.Get(DialogueLanguage.English)); }
}
