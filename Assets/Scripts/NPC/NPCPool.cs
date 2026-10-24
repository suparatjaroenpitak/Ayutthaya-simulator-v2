using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    public sealed class NPCPool : MonoBehaviour
    {
        [SerializeField] private CivilianNPC prefab;
        [SerializeField] private int initialSize = 32;
        private readonly Queue<CivilianNPC> available = new Queue<CivilianNPC>();
        private void Awake() { for (int i = 0; i < initialSize; i++) Release(Create()); }
        private CivilianNPC Create() => Instantiate(prefab, transform);
        public CivilianNPC Acquire(Vector3 position, Quaternion rotation) { CivilianNPC npc = available.Count > 0 ? available.Dequeue() : Create(); npc.transform.SetPositionAndRotation(position, rotation); npc.gameObject.SetActive(true); return npc; }
        public void Release(CivilianNPC npc) { if (npc == null) return; npc.gameObject.SetActive(false); npc.transform.SetParent(transform); available.Enqueue(npc); }
    }
}
