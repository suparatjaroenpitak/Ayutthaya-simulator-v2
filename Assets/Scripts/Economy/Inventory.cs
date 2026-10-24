using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Economy
{
    public sealed class Inventory : MonoBehaviour
    {
        [SerializeField] private int capacity = 50;
        private readonly Dictionary<string, int> quantities = new Dictionary<string, int>();
        public int Count(string productId) => quantities.TryGetValue(productId, out int value) ? value : 0;
        public bool TryAdd(string productId, int quantity) { if (string.IsNullOrWhiteSpace(productId) || quantity <= 0 || Total() + quantity > capacity) return false; quantities[productId] = Count(productId) + quantity; return true; }
        public bool TryRemove(string productId, int quantity) { if (quantity <= 0 || Count(productId) < quantity) return false; quantities[productId] -= quantity; return true; }
        private int Total() { int total = 0; foreach (int value in quantities.Values) total += value; return total; }
    }
}
