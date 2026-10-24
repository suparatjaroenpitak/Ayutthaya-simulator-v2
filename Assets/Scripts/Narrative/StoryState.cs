using System;
using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Narrative
{
    [Serializable] public sealed class StoryState
    {
        public string[] flags = Array.Empty<string>();
        public string[] completedQuests = Array.Empty<string>();
        public bool HasFlag(string flag) { for (int i = 0; i < flags.Length; i++) if (flags[i] == flag) return true; return false; }
        public bool HasCompleted(string questId) { for (int i = 0; i < completedQuests.Length; i++) if (completedQuests[i] == questId) return true; return false; }
        public void SetFlag(string flag) { if (string.IsNullOrWhiteSpace(flag) || HasFlag(flag)) return; Array.Resize(ref flags, flags.Length + 1); flags[flags.Length - 1] = flag; }
        public void MarkCompleted(string questId) { if (string.IsNullOrWhiteSpace(questId) || HasCompleted(questId)) return; Array.Resize(ref completedQuests, completedQuests.Length + 1); completedQuests[completedQuests.Length - 1] = questId; }
    }
    public sealed class StoryStateService : MonoBehaviour
    {
        public StoryState State { get; private set; } = new StoryState();
        public event Action<StoryState> Changed;
        public bool SetFlag(string flag) { if (State.HasFlag(flag)) return false; State.SetFlag(flag); Changed?.Invoke(State); return true; }
        public bool MarkCompleted(string questId) { if (State.HasCompleted(questId)) return false; State.MarkCompleted(questId); Changed?.Invoke(State); return true; }
    }
}
