
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
#pragma warning disable 0649 //never used


using UnityEngine;
using System.Collections;
using System;

#if CHARTBOOST
using ChartboostSDK;

namespace AppAdvisory.Ads
{
	public class AAChartboost : AdBase, IInterstitial, IRewardedVideo
	{
		public string Name()
		{
			return "AAChartboost";
		}

		public void Init()
		{
			print("AAChartboost - Init");

			CBSettings settings = ScriptableObject.CreateInstance<CBSettings>();


			string amazonAppId = adIds.ChartboostAppIdAmazon;
			string amazonAppSecret = adIds.ChartboostAppSignatureAmazon;

			string androidAppId = adIds.ChartboostAppIdAndroid;
			string androidAppSecret = adIds.ChartboostAppSignatureAndroid;



			settings.iOSAppId = adIds.ChartboostAppIdIOS;
			settings.iOSAppSecret = adIds.ChartboostAppSignatureIOS;

			settings.SetIOSAppId(adIds.ChartboostAppIdIOS);
			settings.SetIOSAppSecret(adIds.ChartboostAppSignatureIOS);




#if ANDROID_AMAZON
SetAndroidIds(settings, amazonAppId, amazonAppSecret);
#else
			SetAndroidIds(settings, androidAppId, androidAppSecret);
#endif




			var c = FindObjectOfType<Chartboost>();

			if(c == null)
			{
				gameObject.AddComponent<Chartboost>();
			}

			Chartboost.setAutoCacheAds(true);
			Chartboost.cacheInterstitial (CBLocation.Default);
			Chartboost.cacheInterstitial (CBLocation.Startup);
			Chartboost.cacheRewardedVideo(CBLocation.Default);
		}

		void SetAndroidIds(CBSettings settings, string appId, string appSecret)
		{
			settings.amazonAppId = appId;
			settings.amazonAppSecret = appSecret;

			settings.SetAmazonAppId(appId);
			settings.SetAmazonAppSecret(appSecret);



			settings.androidAppId = appId;
			settings.androidAppSecret = appSecret;

			settings.SetAndroidAppId(appId);
			settings.SetAndroidAppSecret(appSecret);
		}

		private bool _IsReadyInterstitial(CBLocation location)
		{
			bool isOK = Chartboost.hasInterstitial(location);

			if(!isOK)
			{
				Chartboost.cacheInterstitial(location);
			}

			return isOK;
		}

		public bool IsReadyInterstitial()
		{
			return _IsReadyInterstitial(CBLocation.Default);
		}

		public bool IsReadyInterstitialStartup()
		{
			return _IsReadyInterstitial(CBLocation.Startup);
		}

		#region CBLocation startup

		#region CacheInterstitial Startup
		public void CacheInterstitialStartup()
		{
			Chartboost.cacheInterstitial(CBLocation.Startup);
			Chartboost.didCacheInterstitial -= OnDidCacheInterstitialStartup;
			Chartboost.didCacheInterstitial += OnDidCacheInterstitialStartup;
		}

		void OnDidCacheInterstitialStartup(CBLocation obj)
		{
			GC.Collect();
			Application.targetFrameRate = 60;
			print("AAChartboost - CacheInterstitialStartup - didCacheInterstitial");
			Chartboost.didCacheInterstitial -= OnDidCacheInterstitialStartup;
		}

		#endregion

		#region ShowInterstitial Startup
		Action<bool> successInterstitialStartup;

		void UnnubscribeInterstitialStartup()
		{
			successInterstitialStartup = null;
			Chartboost.didDisplayInterstitial -= OnDidDisplayInterstitialStartup;
			Chartboost.didFailToLoadInterstitial -= OnDidFailToLoadInterstitialStartup;
			Chartboost.didCloseInterstitial -= OnDidCloseInterstitialStartup;

			GC.Collect();
			Application.targetFrameRate = 60;
		}

		void OnDidDisplayInterstitialStartup(CBLocation obj)
		{
			print("AAChartboost - OnDidDisplayInterstitialStartup");
			if(successInterstitialStartup != null)
				successInterstitialStartup(true);

			UnnubscribeInterstitialStartup();
			NotifyInterstitialOpened();
		}

		void OnDidFailToLoadInterstitialStartup(CBLocation arg1, CBImpressionError arg2)
		{
			print("AAChartboost - OnDidFailToLoadInterstitialStartup : error = " + arg2.ToString());
			if(successInterstitialStartup != null)
				successInterstitialStartup(false);

			UnnubscribeInterstitialStartup();
		}

		void OnDidCloseInterstitialStartup(CBLocation loc)
		{
			NotifyInterstitialClosed();
		}


		public void ShowInterstitialStartup(Action<bool> success)
		{
			UnnubscribeInterstitialStartup();

			print("******** ShowInterstitialStartup CHARTBOOST ********");

			Chartboost.didDisplayInterstitial += OnDidDisplayInterstitialStartup;
			Chartboost.didFailToLoadInterstitial += OnDidFailToLoadInterstitialStartup;
			Chartboost.didCloseInterstitial += OnDidCloseInterstitialStartup;

			this.successInterstitialStartup = success;
			Chartboost.showInterstitial (CBLocation.Startup);
		}

		#endregion

		#endregion


		#region CBLocation default

		#region CacheInterstitial Default
		public void CacheInterstitial()
		{
			Chartboost.cacheInterstitial(CBLocation.Default);
			Chartboost.didCacheInterstitial -= OnDidCacheInterstitialDefault;
			Chartboost.didCacheInterstitial += OnDidCacheInterstitialDefault;
		}

		void OnDidCacheInterstitialDefault(CBLocation obj)
		{
			GC.Collect();
			Application.targetFrameRate = 60;
			print("AAChartboost - OnDidCacheInterstitialDefault");
			Chartboost.didCacheInterstitial -= OnDidCacheInterstitialDefault;
		}

		#endregion

		#region ShowInterstitial Default

		Action<bool> successInterstitialDefault;

		void UnnubscribeInterstitialDefault()
		{
			successInterstitialDefault = null;
			Chartboost.didDisplayInterstitial -= OnDidDisplayInterstitialDefault;
			Chartboost.didFailToLoadInterstitial -= OnDidFailToLoadInterstitialDefault;
			Chartboost.didCloseInterstitial -= OnDidCloseInterstitialDefault;

			GC.Collect();
			Application.targetFrameRate = 60;
		}

		public void ShowInterstitial(Action<bool> success)
		{
			print("******** ShowInterstitial CHARTBOOST ********");

			UnnubscribeInterstitialDefault();

			this.successInterstitialDefault = success;

			Chartboost.didDisplayInterstitial += OnDidDisplayInterstitialDefault;
			Chartboost.didFailToLoadInterstitial += OnDidFailToLoadInterstitialDefault;
			Chartboost.didCloseInterstitial += OnDidCloseInterstitialDefault;

			Chartboost.showInterstitial (CBLocation.Default);
		}

		void OnDidDisplayInterstitialDefault(CBLocation obj)
		{
			print("AAChartboost - ShowInterstitial - didDisplayInterstitial");

			if(successInterstitialDefault != null)
				successInterstitialDefault(true);

			UnnubscribeInterstitialDefault();
			NotifyInterstitialOpened();
		}

		void OnDidFailToLoadInterstitialDefault(CBLocation arg1, CBImpressionError arg2)
		{
			print("AAChartboost - ShowInterstitial - didFailToLoadInterstitial : error = " + arg2.ToString());

			if(successInterstitialDefault != null)
				successInterstitialDefault(false);

			UnnubscribeInterstitialDefault();
		}

		void OnDidCloseInterstitialDefault(CBLocation obj)
		{
			NotifyInterstitialClosed();
		}

		#endregion
		#endregion

		#region video rewarded

		void UnsubscribeRewardedVideo()
		{
			GC.Collect();
			Application.targetFrameRate = 60;
			successRewardedVideo = null;
			Chartboost.didFailToLoadRewardedVideo -= OnDidFailToLoadRewardedVideo;
			Chartboost.didCompleteRewardedVideo -= OnDidCompleteRewardedVideo;
			Chartboost.didDismissRewardedVideo -= OnDidDismissRewardedVideo;
		}

		public bool IsReadyRewardedVideo()
		{
			bool isOK =  Chartboost.hasRewardedVideo(CBLocation.Default);

			print("AAChartboost - IsReadyRewardedVideo : " + isOK.ToString());

			return isOK;
		}

		public void CacheRewardedVideo()
		{
			print("AAChartboost - CacheRewardedVideo");
			Chartboost.cacheRewardedVideo(CBLocation.Default);
		}

		Action<bool> successRewardedVideo;

		public void ShowRewardedVideo(Action<bool> success)
		{
			UnsubscribeRewardedVideo();

			this.successRewardedVideo = success;

			Chartboost.showRewardedVideo(CBLocation.Default);

			Chartboost.didFailToLoadRewardedVideo += OnDidFailToLoadRewardedVideo;

			Chartboost.didCompleteRewardedVideo += OnDidCompleteRewardedVideo;

			Chartboost.didDismissRewardedVideo += OnDidDismissRewardedVideo;
		}

		void OnDidFailToLoadRewardedVideo(CBLocation arg1, CBImpressionError arg2) 
		{
			GC.Collect();
			Application.targetFrameRate = 60;

			print("AAChartboost - didFailToLoadRewardedVideo - error = " + arg2);

			if (successRewardedVideo != null)
				successRewardedVideo (false);

			UnsubscribeRewardedVideo();
		}

		void OnDidCompleteRewardedVideo(CBLocation arg1, int arg2) 
		{
			GC.Collect();
			Application.targetFrameRate = 60;

			Debug.Log ("user success chartboost rewarded video - didCompleteRewardedVideo");

			if (successRewardedVideo != null)
				successRewardedVideo (true);

			UnsubscribeRewardedVideo();
		}

		void OnDidDismissRewardedVideo(CBLocation arg1) 
		{
			GC.Collect();
			Application.targetFrameRate = 60;

			Debug.Log ("user success chartboost rewarded video - didDismissRewardedVideo");

			if (successRewardedVideo != null)
				successRewardedVideo (false);

			UnsubscribeRewardedVideo();
		}
		#endregion

		public void NotifyInterstitialOpened()
		{
			AdsManager.DOInterstitialOpened();
		}

		public void NotifyInterstitialClosed()
		{
			AdsManager.DOInterstitialClosed();
		}

	}
}

#endif