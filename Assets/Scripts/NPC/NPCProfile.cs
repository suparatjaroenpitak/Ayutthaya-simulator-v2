using System;
using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    public enum NPCOccupation { Unemployed, Shopkeeper, Farmer, Student, Driver, Monk, Vendor }
    public enum NPCActivity { Home, Work, Shop, Farm, Eat, Sleep, Wander, Talk }

    [Serializable]
    public struct ScheduleEntry
    {
        [Range(0, 1440)] public int startMinute;
        [Range(0, 1440)] public int endMinute;
        public NPCActivity activity;
        public Transform target;
        public bool Contains(int minute) => startMinute <= endMinute ? minute >= startMinute && minute < endMinute : minute >= startMinute || minute < endMinute;
    }

    [CreateAssetMenu(menuName = "Ayutthaya/NPC/NPC Profile", fileName = "NPCProfile")]
    public sealed class NPCProfile : ScriptableObject
    {
        public string profileId;
        public string displayNameThai;
        public string displayNameEnglish;
        public NPCOccupation occupation;
        public ScheduleEntry[] schedule = Array.Empty<ScheduleEntry>();
        [Min(0.1f)] public float walkSpeed = 1.5f;
        [Min(0.1f)] public float runSpeed = 3.5f;
        [Min(0.1f)] public float talkDistance = 2f;
        [Range(0f, 1f)] public float spawnWeight = 1f;
    }
}
