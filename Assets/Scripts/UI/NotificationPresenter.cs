using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.UI
{
    public sealed class NotificationPresenter : MonoBehaviour
    {
        [SerializeField] private UiEventBus bus;
        [SerializeField] private Transform container;
        [SerializeField] private GameObject notificationPrefab;
        private readonly Queue<UiNotification> pending = new Queue<UiNotification>();
        private void OnEnable() { if (bus != null) bus.NotificationRaised += Enqueue; }
        private void OnDisable() { if (bus != null) bus.NotificationRaised -= Enqueue; }
        private void Enqueue(UiNotification notification) => pending.Enqueue(notification);
        private void Update() { if (pending.Count == 0 || notificationPrefab == null || container == null) return; GameObject item = Instantiate(notificationPrefab, container); item.SendMessage("SetNotification", pending.Dequeue(), SendMessageOptions.DontRequireReceiver); }
    }
}
