using System.IO;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using AyutthayaSimulator.Build;

namespace AyutthayaSimulator.Editor
{
    public static class BuildPipelineTools
    {
        [MenuItem("Ayutthaya/Build/Validate Selected Profile")]
        public static void ValidateSelected()
        {
            BuildProfile profile = Selection.activeObject as BuildProfile; if (profile == null) { Debug.LogError("Select a BuildProfile asset."); return; }
            for (int i = 0; i < profile.scenes.Length; i++) if (!File.Exists(profile.scenes[i])) Debug.LogError("Missing scene: " + profile.scenes[i]);
            if (string.IsNullOrWhiteSpace(profile.version)) Debug.LogError("Version is required."); else Debug.Log("Build profile validation completed: " + profile.version);
        }

        [MenuItem("Ayutthaya/Build/Build Windows Client")]
        public static void BuildClient() => Build(BuildTarget.StandaloneWindows64, "Builds/WindowsClient", false);

        [MenuItem("Ayutthaya/Build/Build Windows Dedicated Server")]
        public static void BuildServer() => Build(BuildTarget.StandaloneWindows64, "Builds/WindowsServer", true);

        private static void Build(BuildTarget target, string path, bool server)
        {
            BuildProfile profile = Selection.activeObject as BuildProfile; if (profile == null) { Debug.LogError("Select a BuildProfile asset."); return; }
            BuildPlayerOptions options = new BuildPlayerOptions { scenes = profile.scenes, locationPathName = path + "/AyutthayaSimulator.exe", target = target, options = server ? BuildOptions.EnableHeadlessMode : BuildOptions.None };
            BuildReport report = BuildPipeline.BuildPlayer(options); if (report.summary.result != BuildResult.Succeeded) throw new BuildFailedException("Build failed: " + report.summary.result);
            Debug.Log("Build succeeded: " + report.summary.totalSize + " bytes");
        }
    }
}
