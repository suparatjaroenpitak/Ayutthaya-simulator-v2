using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public sealed class LaneNode : MonoBehaviour
    {
        public LaneNode[] next = new LaneNode[0];
        public float speedLimitKph = 40f;
        public Vector3 Position => transform.position;
    }

    public sealed class LaneGraph : MonoBehaviour
    {
        [SerializeField] private LaneNode[] nodes = new LaneNode[0];
        public IReadOnlyList<LaneNode> Nodes => nodes;
        public LaneNode FindNearest(Vector3 position, float maxDistance)
        {
            LaneNode best = null; float distance = maxDistance;
            for (int i = 0; i < nodes.Length; i++) if (nodes[i] != null && Vector3.Distance(position, nodes[i].Position) <= distance) { best = nodes[i]; distance = Vector3.Distance(position, nodes[i].Position); }
            return best;
        }
    }
}
