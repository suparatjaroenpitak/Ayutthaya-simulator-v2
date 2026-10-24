using System;

namespace AyutthayaSimulator.Economy
{
    [Serializable]
    public readonly struct ThaiBaht
    {
        public readonly long Satang;
        public ThaiBaht(long satang) { Satang = satang; }
        public static ThaiBaht FromBaht(decimal baht) => new ThaiBaht((long)Math.Round(baht * 100m, MidpointRounding.AwayFromZero));
        public decimal Baht => Satang / 100m;
        public override string ToString() => $"฿{Baht:0.00}";
    }
}
