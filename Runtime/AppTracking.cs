#if VIRTUESKY_FIREBASE_ANALYTIC
using Firebase.Analytics;
#endif


namespace VirtueSky.Tracking
{
    public struct AppTracking
    {
        private static bool enableTrackAdRevenue;
        public static void Init(bool _enableTrackAdRevenue)
        {
            enableTrackAdRevenue = _enableTrackAdRevenue;
        }
        public static void TrackRevenue(double value, string network, string unitId, string format, string adNetwork)
        {
            if (!enableTrackAdRevenue) return;
            AdjustTrackingRevenue.AdjustTrackRevenue(value, network, unitId, format, adNetwork);
            FirebaseAnalyticTrackingRevenue.FirebaseAnalyticTrackRevenue(value, network, unitId,
                format, adNetwork);
            AppsFlyerTrackingRevenue.AppsFlyerTrackRevenueAd(value, network, unitId, format, adNetwork);
        }

        public static void FirebaseAnalyticTrackATTResult(int status)
        {
#if VIRTUESKY_FIREBASE_ANALYTIC
            FirebaseAnalytics.LogEvent("app_tracking_transparency", "status", status);
#endif
        }
    }
}