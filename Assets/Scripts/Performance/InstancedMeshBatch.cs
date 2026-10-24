using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    public sealed class InstancedMeshBatch : MonoBehaviour
    {
        [SerializeField] private Mesh mesh;
        [SerializeField] private Material material;
        [SerializeField] private Matrix4x4[] instances = new Matrix4x4[0];
        private readonly Matrix4x4[] batch = new Matrix4x4[1023];
        private void Update() { if (mesh == null || material == null || !material.enableInstancing) return; for (int offset = 0; offset < instances.Length; offset += batch.Length) { int count = Mathf.Min(batch.Length, instances.Length - offset); System.Array.Copy(instances, offset, batch, 0, count); Graphics.DrawMeshInstanced(mesh, 0, material, batch, count); } }
    }
}
