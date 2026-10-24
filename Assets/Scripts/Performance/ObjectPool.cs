using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    public sealed class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;
        [SerializeField] private int initialSize = 32;
        private readonly Queue<GameObject> available = new Queue<GameObject>();
        private void Awake() { for (int i = 0; i < initialSize; i++) Release(Instantiate(prefab, transform)); }
        public GameObject Acquire(Vector3 position, Quaternion rotation) { GameObject item = available.Count > 0 ? available.Dequeue() : Instantiate(prefab, transform); item.transform.SetPositionAndRotation(position, rotation); item.SetActive(true); return item; }
        public void Release(GameObject item) { if (item == null) return; item.SetActive(false); item.transform.SetParent(transform); available.Enqueue(item); }
    }
}
