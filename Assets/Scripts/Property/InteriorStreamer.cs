using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AyutthayaSimulator.Property
{
    public sealed class InteriorStreamer : MonoBehaviour
    {
        [SerializeField] private PropertyRegistry registry;
        private readonly HashSet<string> loaded = new HashSet<string>();
        public void Load(string propertyId) { PropertyDefinition definition = registry == null ? null : registry.FindDefinition(propertyId); if (definition != null && !string.IsNullOrWhiteSpace(definition.interiorScenePath) && !loaded.Contains(definition.interiorScenePath)) StartCoroutine(LoadAsync(definition.interiorScenePath)); }
        public void Unload(string propertyId) { PropertyDefinition definition = registry == null ? null : registry.FindDefinition(propertyId); if (definition != null && loaded.Contains(definition.interiorScenePath)) StartCoroutine(UnloadAsync(definition.interiorScenePath)); }
        private IEnumerator LoadAsync(string path) { loaded.Add(path); yield return SceneManager.LoadSceneAsync(path, LoadSceneMode.Additive); }
        private IEnumerator UnloadAsync(string path) { loaded.Remove(path); yield return SceneManager.UnloadSceneAsync(path); }
    }
}
