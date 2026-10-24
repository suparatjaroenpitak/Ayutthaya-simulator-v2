using UnityEngine;
namespace AyutthayaSimulator.WorldPrototype
{
    public sealed class TerrainVisibility : MonoBehaviour
    {
        public Transform viewer;
        public Terrain[] tiles;
        public float drawDistance = 1600;
        private float next;
        void Update()
        {
            if(viewer==null || Time.unscaledTime<next) return;
            next=Time.unscaledTime+.25f;
            foreach(var tile in tiles)
            {
                var bounds=new Bounds(tile.transform.position+tile.terrainData.size*.5f,tile.terrainData.size);
                tile.drawHeightmap=bounds.SqrDistance(viewer.position)<drawDistance*drawDistance;
                // Colliders remain active: visual culling must not remove ground.
            }
        }
    }
}
