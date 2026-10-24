using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public enum FarmMachineType { Tractor, Harvester, WaterPump }
    public sealed class FarmMachine : MonoBehaviour
    {
        [SerializeField] private FarmMachineType type;
        [SerializeField] private float operationPower = 1f;
        public FarmMachineType Type => type;
        public float Operate(FarmPlot plot)
        {
            if (plot == null) return 0f;
            if (type == FarmMachineType.WaterPump) { plot.Irrigate(operationPower); return operationPower; }
            if (type == FarmMachineType.Tractor) { plot.PrepareSoil(); return operationPower; }
            return plot.Stage == CropGrowthStage.Mature ? operationPower : 0f;
        }
    }
}
