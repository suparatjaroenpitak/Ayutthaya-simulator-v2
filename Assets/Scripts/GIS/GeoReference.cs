using System;
using UnityEngine;

namespace AyutthayaSimulator.GIS
{
    [Serializable]
    public struct GeoCoordinate
    {
        public double latitude;
        public double longitude;
        public double elevationMeters;
        public GeoCoordinate(double lat, double lon, double elevation = 0) { latitude = lat; longitude = lon; elevationMeters = elevation; }
    }

    [Serializable]
    public sealed class GeoReference
    {
        public double originLatitude;
        public double originLongitude;
        public double metersPerUnit = 1.0;

        public Vector3 ToUnity(GeoCoordinate coordinate)
        {
            const double earthRadius = 6378137.0;
            double latRadians = originLatitude * Math.PI / 180.0;
            double east = (coordinate.longitude - originLongitude) * Math.PI / 180.0 * earthRadius * Math.Cos(latRadians);
            double north = (coordinate.latitude - originLatitude) * Math.PI / 180.0 * earthRadius;
            return new Vector3((float)(east / metersPerUnit), (float)(coordinate.elevationMeters / metersPerUnit), (float)(north / metersPerUnit));
        }

        public GeoCoordinate ToGeo(Vector3 local)
        {
            const double earthRadius = 6378137.0;
            double latRadians = originLatitude * Math.PI / 180.0;
            double latitude = originLatitude + local.z * metersPerUnit / earthRadius * 180.0 / Math.PI;
            double longitude = originLongitude + local.x * metersPerUnit / (earthRadius * Math.Cos(latRadians)) * 180.0 / Math.PI;
            return new GeoCoordinate(latitude, longitude, local.y * metersPerUnit);
        }
    }
}
