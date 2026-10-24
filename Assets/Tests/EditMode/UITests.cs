using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.UI;

public sealed class UITests
{
    [Test] public void TranslationTable_ReturnsThaiAndEnglish()
    {
        TranslationTable table = ScriptableObject.CreateInstance<TranslationTable>(); table.rows = new[] { new TranslationRow { key = "hud.wallet", thai = "เงิน ฿{count}", english = "Wallet ฿{count}" } }; Assert.IsTrue(table.TryGet("hud.wallet", UiLanguage.Thai, out string thai)); Assert.IsTrue(thai.Contains("เงิน")); Assert.IsTrue(table.TryGet("hud.wallet", UiLanguage.English, out string english)); Assert.IsTrue(english.Contains("Wallet")); Object.DestroyImmediate(table);
    }
    [Test] public void TranslationTable_MissingKeyReturnsKey()
    {
        TranslationTable table = ScriptableObject.CreateInstance<TranslationTable>(); Assert.IsFalse(table.TryGet("missing", UiLanguage.English, out string value)); Assert.AreEqual("missing", value); Object.DestroyImmediate(table);
    }
}
