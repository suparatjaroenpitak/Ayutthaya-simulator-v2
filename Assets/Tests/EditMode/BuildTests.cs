using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Build;

public sealed class BuildTests
{
    [Test] public void RuntimeConfiguration_DefaultsSafely() { RuntimeConfiguration config = RuntimeConfigurationLoader.Load("missing-test-config.json"); Assert.IsNotNull(config); Assert.IsFalse(string.IsNullOrEmpty(config.buildVersion)); }
    [Test] public void BuildProfile_HasReleaseMetadata() { BuildProfile profile = ScriptableObject.CreateInstance<BuildProfile>(); Assert.IsNotEmpty(profile.productName); Assert.IsNotEmpty(profile.version); Assert.Greater(profile.bundleVersionCode, 0); Object.DestroyImmediate(profile); }
}
