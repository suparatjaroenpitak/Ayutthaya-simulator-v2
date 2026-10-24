using System;
using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    [Serializable]
    public struct RelationshipValue
    {
        public string otherId;
        [Range(-100, 100)] public int value;
    }

    public sealed class NPCRelationshipStore : MonoBehaviour
    {
        [SerializeField] private RelationshipValue[] initialValues = Array.Empty<RelationshipValue>();
        private readonly Dictionary<string, int> values = new Dictionary<string, int>();
        private void Awake() { for (int i = 0; i < initialValues.Length; i++) values[initialValues[i].otherId] = Mathf.Clamp(initialValues[i].value, -100, 100); }
        public int Get(string otherId) => values.TryGetValue(otherId, out int value) ? value : 0;
        public void Adjust(string otherId, int delta) => values[otherId] = Mathf.Clamp(Get(otherId) + delta, -100, 100);
    }
}
