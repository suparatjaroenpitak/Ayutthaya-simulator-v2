using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace AyutthayaSimulator.GIS
{
    public sealed class AdditiveTileLoader : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private GISProjectConfig project;
        [SerializeField] private GISTileDefinition[] tiles = new GISTileDefinition[0];
        [SerializeField] private float loadRadius = 900f;
        [SerializeField] private float unloadRadius = 1200f;
        private readonly HashSet<string> loaded = new HashSet<string>();

        private void Update() { if (player != null) StartCoroutine(Reconcile()); }

        private IEnumerator Reconcile()
        {
            yield return null;
            for (int i = 0; i < tiles.Length; i++)
            {
                GISTileDefinition tile = tiles[i];
                if (tile == null || string.IsNullOrWhiteSpace(tile.scenePath)) continue;
                if (project == null || project.reference == null) yield break;
                GeoCoordinate centerGeo = new GeoCoordinate(
                    (tile.bounds.minLatitude + tile.bounds.maxLatitude) * 0.5,
                    (tile.bounds.minLongitude + tile.bounds.maxLongitude) * 0.5);
                Vector3 center = project.reference.ToUnity(centerGeo);
                float distance = Vector2.Distance(new Vector2(player.position.x, player.position.z), new Vector2(center.x, center.z));
                if (distance <= loadRadius && !loaded.Contains(tile.scenePath))
                {
                    loaded.Add(tile.scenePath);
                    yield return SceneManager.LoadSceneAsync(tile.scenePath, LoadSceneMode.Additive);
                }
                else if (distance > unloadRadius && loaded.Contains(tile.scenePath))
                {
                    loaded.Remove(tile.scenePath);
                    yield return SceneManager.UnloadSceneAsync(tile.scenePath);
                }
            }
        }
    }
}
