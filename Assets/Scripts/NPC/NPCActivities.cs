using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    public interface INPCActivityHandler
    {
        void BeginActivity(NPCActivity activity, NPCProfile profile);
    }

    public sealed class ShopkeeperActivity : MonoBehaviour, INPCActivityHandler
    {
        public void BeginActivity(NPCActivity activity, NPCProfile profile) { if (activity == NPCActivity.Shop) { } }
    }

    public sealed class FarmerActivity : MonoBehaviour, INPCActivityHandler
    {
        public void BeginActivity(NPCActivity activity, NPCProfile profile) { if (activity == NPCActivity.Farm) { } }
    }
}
