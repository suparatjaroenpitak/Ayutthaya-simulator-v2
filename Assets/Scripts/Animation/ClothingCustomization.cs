using System;
using UnityEngine;

namespace AyutthayaSimulator.Animation
{
    [Serializable]
    public sealed class ClothingSlot
    {
        public string id;
        public SkinnedMeshRenderer renderer;
        public Material[] variants;
    }

    public sealed class ClothingCustomization : MonoBehaviour
    {
        [SerializeField] private ClothingSlot[] slots = Array.Empty<ClothingSlot>();

        public bool Apply(string slotId, int variantIndex)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                ClothingSlot slot = slots[i];
                if (slot == null || slot.id != slotId || slot.renderer == null || slot.variants == null || variantIndex < 0 || variantIndex >= slot.variants.Length) continue;
                slot.renderer.sharedMaterial = slot.variants[variantIndex];
                return true;
            }
            return false;
        }
    }
}
