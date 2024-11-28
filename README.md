<p align="left">
  <a>
    <img alt="Made With Unity" src="https://img.shields.io/badge/made%20with-Unity-57b9d3.svg?logo=Unity">
  </a>
  <a>
    <img alt="License" src="https://img.shields.io/github/license/unity-package/app-tracking-unity?logo=github">
  </a>
  <a>
    <img alt="Last Commit" src="https://img.shields.io/github/last-commit/unity-package/app-tracking-unity?logo=Mapbox&color=orange">
  </a>
  <a>
    <img alt="Repo Size" src="https://img.shields.io/github/repo-size/unity-package/app-tracking-unity?logo=VirtualBox">
  </a>
  <a>
    <img alt="Last Release" src="https://img.shields.io/github/v/release/unity-package/app-tracking-unity?include_prereleases&logo=Dropbox&color=yellow">
  </a>
</p>

## What

- Support tracking for game unity (Firebase Analytic, Adjust and AppsFlyer)

## How To Install

### Add the line below to `Packages/manifest.json`

for version `1.0.3`
```csharp
"com.wolf-org.tracking":"https://github.com/unity-package/app-tracking-unity.git#1.0.3",
```

## Use

#### Firebase Tracking

- Add define symbols `VIRTUESKY_FIREBASE_ANALYTIC` to use ([Get Firebase Analytic Sdk](https://github.com/firebase-unity/firebase-analytics))
- Tracking event
```csharp
    static void TrackEvent(string eventName)
    static void TrackEvent(string eventName, string parameterName, string parameterValue)
    static void TrackEvent(string eventName, Dictionary<string, string> dictParameters)
    static void TrackEvent(string eventName, Parameter[] parameters)
```
Example

```csharp
        void TrackNoParam()
        {
            FirebaseTracking.TrackEvent("WinGame");
        }

        /// <summary>
        /// parameter_name: level
        /// parameter_value: level_1
        /// </summary>
        void TrackOneParam()
        {
            FirebaseTracking.TrackEvent("WinGame", "level", "level_1");
        }

        void TrackHasPramDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("level", "level_1");
            dict.Add("level", "level_2");
            dict.Add("level", "level_3");
            FirebaseTracking.TrackEvent("WinGame", dict);
        }

        void TrackHasPram()
        {
            Parameter[] parameters = new[]
            {
                new Parameter("level", "level_1"),
                new Parameter("level", "level_2"),
                new Parameter("level", "level_3")
            };
            FirebaseTracking.TrackEvent("WinGame", parameters);
        }
```

- Tracking ads revenue

```csharp
    static void FirebaseAnalyticTrackRevenue(double value, string network, string unitId, string format, string adNetwork)
```
Example

```csharp
        void TrackingRevenue()
        {
            FirebaseAnalyticTrackingRevenue.FirebaseAnalyticTrackRevenue(...);
        }
```

#### Adjust Tracking

- Add define symbol `VIRTUESKY_ADJUST` to use ([Get Adjust Sdk](https://github.com/pancake-llc/adjust))
- Tracking event

```csharp
    static void TrackEvent(string eventToken)
```

Example
```csharp
        void TrackingEventAdjust()
        {
            AdjustTracking.TrackEvent("asdwdsfwa");
        }
```

- Tracking ads revenue
```csharp
    static void AdjustTrackRevenue(double value, string network, string unitId, string placement, string adNetwork)
```
Example

```csharp
        void TrackingRevenue()
        {
            AdjustTrackingRevenue.AdjustTrackRevenue(...);
        }
```

#### AppsFlyer Tracking

- Add define symbol `VIRTUESKY_APPSFLYER` to use ([Get Appsflyer Sdk](https://github.com/AppsFlyerSDK/appsflyer-unity-plugin) , [Get AppsFlyer AdRevenue](https://github.com/AppsFlyerSDK/appsflyer-unity-adrevenue-generic-connector))
- Tracking event

```csharp
    static void TrackEvent(string eventName)
    static void TrackEvent(string eventName, string parameterName, string parameterValue)
    static void TrackEvent(string eventName, Dictionary<string, string> eventValues)
```

Example

```csharp
        void TrackNoParam()
        {
            AppsFlyerTracking.TrackEvent("WinGame");
        }

        /// <summary>
        /// parameter_name: level
        /// parameter_value: level_1
        /// </summary>
        void TrackOneParam()
        {
            AppsFlyerTracking.TrackEvent("WinGame", "level", "level_1");
        }

        void TrackHasPramDict()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("level", "level_1");
            dict.Add("level", "level_2");
            dict.Add("level", "level_3");
            AppsFlyerTracking.TrackEvent("WinGame", dict);
        }
```
- Tracking ads revenue

```csharp
    static void AppsFlyerTrackRevenueAd(double value, string network, string unitId, string format, string adNetwork)
```

Example

```csharp
        void TrackingRevenue()
        {
            AppsFlyerTrackingRevenue.AppsFlyerTrackRevenueAd(...);
        }
```
- Tracking iap revenue
Add define symbol `VIRTUESKY_IAP` to use
```csharp
    static void AppFlyerTrackingRevenueInAppPurchase(Product product)
```

Example
```csharp
        void TrackingRevenue(Product productIAP)
        {
            AppsFlyerTrackingRevenue.AppFlyerTrackingRevenueInAppPurchase(productIAP);
        }
```
#### App Tracking

- Tracking ad revenue (If calling `Track Revenue` through `App Tracking`, revenue will be tracked in all of Firebase Analytics, Adjust, and AppsFlyer)
```csharp
    static void TrackRevenue(double value, string network, string unitId, string format, string adNetwork)
```

Example

```csharp
        void TrackingRevenue()
        {
            AppTracking.TrackRevenue(...);
        }
```

- Firebase tracking ATT Results IOS (App Tracking Transparency) 
- Require: `"com.unity.ads.ios-support": "1.2.0"`

```csharp
    static void FirebaseAnalyticTrackATTResult(int status)
```

Example

```csharp
        void AppTrackingTransparency()
        {
            if (ATTrackingStatusBinding.GetAuthorizationTrackingStatus() ==
                ATTrackingStatusBinding.AuthorizationTrackingStatus.NOT_DETERMINED)
            {
                ATTrackingStatusBinding.RequestAuthorizationTracking(AppTracking.FirebaseAnalyticTrackATTResult);
            }
        }
```
