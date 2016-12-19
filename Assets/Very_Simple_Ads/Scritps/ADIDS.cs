
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
#pragma warning disable 0618 // obslolete
#pragma warning disable 0108 
#pragma warning disable 0162 

using UnityEngine;
using System.Collections;

namespace AppAdvisory.Ads
{
	public class ADIDS : ScriptableObject
	{
		public bool DEBUG = false;

		public bool LoadNextSceneWhenAdLoaded = false;

		public bool RandomizeNetworks = true;

		public bool FIRST_TIME = true;
		public bool EnableAdmob = false;
		public bool EnableChartboost = false;
		public bool ANDROID_AMAZON = false;
		public bool EnableAdcolony = false;

		public bool IsAdmobSettingsOpened = false;
		public bool IsAdmobIOSSettingsOpened = false;
		public bool IsAdmobANDROIDSettingsOpened = false;
		public bool IsAdmobAMAZONSettingsOpened = false;
		public bool IsUnityAdsSettingsOpened = false;
		public bool IsChartboostSettingsOpened = false;
		public bool IsADColonySettingsOpened = false;
		public bool rewardedVideoAlwaysReadyInSimulator = false;
		public bool rewardedVideoAlwaysSuccessInSimulator = false;
		public bool ShowIntertitialAtStart = true;

		#region CHARTBOOST
		public string ChartboostAppIdIOS = "56fd4f6043150f2f0489c403";
		public string ChartboostAppSignatureIOS = "3c3e6030273502ce1b0a36d23b6245795ef7670b";

		public string ChartboostAppIdAndroid = "56fd4f87f789824afc8984bc";
		public string ChartboostAppSignatureAndroid = "51e43bcf267a74cc755404176b4b6ea8fa9993ae";

		public string ChartboostAppIdAmazon = "56fd4f92c909a6436e6a731a";
		public string ChartboostAppSignatureAmazon = "7330adcb8324863b0eadbe0e1236267ec1935321";

		public string ChartboostAppId
		{
			get
			{
				#if UNITY_IOS
				return ChartboostAppIdIOS;
				#endif

				#if UNITY_ANDROID
				if(isAmazon)
				return ChartboostAppIdAmazon;
				else
				return ChartboostAppIdAndroid;
				#endif

				#if !UNITY_IOS && !UNITY_ANDROID
				return "";
				#endif
			}
		}

		public string ChartboostAppSignature
		{
			get
			{
				#if UNITY_IOS
				return ChartboostAppSignatureIOS;
				#endif

				#if UNITY_ANDROID
				if(isAmazon)
				return ChartboostAppSignatureAmazon;
				else
				return ChartboostAppSignatureAndroid;
				#endif

				#if !UNITY_IOS && !UNITY_ANDROID
				return "";
				#endif
			}
		}
		#endregion

		#region ADMOB

		#if UNITY_ANDROID
		public bool isAmazon = false;
		#endif


		public string AdmobBannerIdIOS = "ca-app-pub-4501064062171971/8068421245";

		public string AdmobInterstitialIdIOS = "ca-app-pub-4501064062171971/9545154449";

		public string AdmobRewardedVideoIdIOS = "ca-app-pub-4501064062171971/6591688042";

		public string AdmobBannerIdANDROID = "ca-app-pub-4501064062171971/7928820445";

		public string AdmobInterstitialIdANDROID = "ca-app-pub-4501064062171971/9405553649";

		public string AdmobRewardedVideoIdANDROID = "ca-app-pub-4501064062171971/1882286844";

		public string AdmobBannerIdAMAZON = "ca-app-pub-4501064062171971/6312486440";

		public string AdmobInterstitialIdAMAZON = "ca-app-pub-4501064062171971/7789219647";

		public string AdmobRewardedVideoIdAMAZON = "ca-app-pub-4501064062171971/9265952846";

		public string admobBannerID
		{
			get
			{
				#if UNITY_IOS
				return AdmobBannerIdIOS;
				#endif

				#if UNITY_ANDROID
				bool isAmazon = false;

				#if ANDROID_AMAZON
				isAmazon = true;
				#endif
				if(!isAmazon)
					return AdmobBannerIdANDROID;
				else
					return AdmobBannerIdAMAZON;
				#endif

				return "";
			}
		}

		public string admobInterstitialID
		{
			get
			{
				#if UNITY_IOS
				return AdmobInterstitialIdIOS;
				#endif

				#if UNITY_ANDROID
				bool isAmazon = false;

				#if ANDROID_AMAZON
				isAmazon = true;
				#endif

				if(!isAmazon)
					return AdmobInterstitialIdANDROID;
				else
					return AdmobInterstitialIdAMAZON;
				#endif

				return "";
			}
		}

		public string admobRewardedVideoID
		{
			get
			{
				#if UNITY_IOS
				return AdmobRewardedVideoIdIOS;
				#endif

				#if UNITY_ANDROID
				bool isAmazon = false;

				#if ANDROID_AMAZON
				isAmazon = true;
				#endif

				if(!isAmazon)
					return AdmobRewardedVideoIdANDROID;
				else
					return AdmobRewardedVideoIdAMAZON;
				#endif

				return "";
			}
		}

		#endregion

		#region UNITYADS
		#if UNITY_ADS
		public bool activateRegularInterstitial_UNITY_ADS = false;
		public bool activateRewardedVideo_UNITY_ADS = false;
		public string rewardedVideoZoneUnityAds = "rewardedVideoZone";
		#endif
		#endregion

		#region ADCOLONY

		#if ENABLE_ADCOLONY
		public bool activateRegularInterstitial_ADCOLONY = false;
		public bool activateRewardedVideo_ADCOLONY = false;
		//		 Arbitrary version number
		public string version = "1.1";



		public string AdColonyAppID_iOS = "appdec0ff5be54449c0b0";
	
		public string ADCOLONY_appId
		{
			get
			{
		#if UNITY_IOS
		return AdColonyAppID_iOS;
		#endif

		#if UNITY_ANDROID
				return AdColonyAppID_ANDROID;
		#endif
			}
		}




		public string AdColonyInterstitialVideoZoneKEY_iOS = "VideoZone1";
		public string AdColonyInterstitialVideoZoneID_iOS = "vza1dd16e9882640a7b4";

		public string AdColonyInterstitialVideoZoneKEY_ANDROID = "VideoZone1";
		public string AdColonyInterstitialVideoZoneID_ANDROID = "vz96292e0ce9c44b728f";


		public string ADCOLONY_InterstitialVideoZoneKEY
		{
			get
			{
		#if UNITY_IOS
		return AdColonyInterstitialVideoZoneKEY_iOS;
		#endif

		#if UNITY_ANDROID
				return AdColonyInterstitialVideoZoneKEY_ANDROID;
		#endif
			}
		}





		public string ADCOLONY_InterstitialVideoZoneID
		{
			get
			{
		#if UNITY_IOS
		return AdColonyInterstitialVideoZoneID_iOS;
		#endif

		#if UNITY_ANDROID
				return AdColonyInterstitialVideoZoneID_ANDROID;
		#endif
			}
		}


		public string AdColonyAppID_ANDROID = "appb7de26187820418c97";


		public string AdColonyRewardedVideoZoneKEY_iOS = "V4VCZone1";

		public string AdColonyRewardedVideoZoneID_iOS = "vzeba48d17b06a43dea6";





		public string AdColonyRewardedVideoZoneKEY_ANDROID = "V4VCZone1";

		public string AdColonyRewardedVideoZoneID_ANDROID = "v4vc74c3fdbf7da34df2a4";

		public string ADCOLONY_RewardedVideoZoneID
		{
			get
			{
		#if UNITY_IOS
		return AdColonyRewardedVideoZoneID_iOS;
		#endif

		#if UNITY_ANDROID
				return AdColonyRewardedVideoZoneID_ANDROID;
		#endif
			}
		}

		public string ADCOLONY_RewardedVideoZoneKEY
		{
			get
			{
		#if UNITY_IOS
		return AdColonyRewardedVideoZoneKEY_iOS;
		#endif

		#if UNITY_ANDROID
				return AdColonyRewardedVideoZoneKEY_ANDROID;
		#endif
			}
		}
		#endif


		#endregion
	}
}