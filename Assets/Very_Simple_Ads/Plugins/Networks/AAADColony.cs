
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
using System;
using System.Collections;
using System.Collections.Generic;

#if ENABLE_ADCOLONY


namespace AppAdvisory.Ads
{
	public class AAADColony : AdBase, IVideoAds, IRewardedVideo
	{
		// AdColony values
		bool IsAdInitialized = false;
		bool IsAdAvailable = false;
		AdColony.InterstitialAd Ad = null;

		float currencyPopupTimer = 0.0f;

//		// Arbitrary version number
//		string version
//		{
//			get
//			{
//				return FindObjectOfType<AppAdvisory.Ads.AdsManager>().adIds.version;
//			}
//		}
//		// Your application id
//		string appId
//		{
//			get
//			{
//				return FindObjectOfType<AppAdvisory.Ads.AdsManager>().adIds.ADCOLONY_appId;
//			}
//		}
//

		public string Name()
		{
			return "AAADColony";
		}

		public void Init()
		{
			AdColony.Ads.OnConfigurationCompleted -= OnConfigurationCompleted;
			AdColony.Ads.OnConfigurationCompleted += OnConfigurationCompleted;

			AdColony.Ads.OnRequestInterstitial -= OnRequestInterstitial;
			AdColony.Ads.OnRequestInterstitial += OnRequestInterstitial;

			AdColony.Ads.OnRequestInterstitialFailed -= OnRequestInterstitialFailed;
			AdColony.Ads.OnRequestInterstitialFailed += OnRequestInterstitialFailed;

			AdColony.Ads.OnOpened -= OnOpened;
			AdColony.Ads.OnOpened += OnOpened;

			AdColony.Ads.OnClosed -= OnClosed;
			AdColony.Ads.OnClosed += OnClosed;

			AdColony.Ads.OnExpiring -= OnExpiring;
			AdColony.Ads.OnExpiring += OnExpiring;

			AdColony.Ads.OnIAPOpportunity -= OnIAPOpportunity;
			AdColony.Ads.OnIAPOpportunity += OnIAPOpportunity;

			AdColony.Ads.OnRewardGranted -= OnRewardGranted;
			AdColony.Ads.OnRewardGranted += OnRewardGranted;

			AdColony.Ads.OnCustomMessageReceived -= OnCustomMessageReceived;
			AdColony.Ads.OnCustomMessageReceived += OnCustomMessageReceived;
		}

		void ConfigureAds()
		{

			Debug.Log("**** Configure ADC SDK ****");

			AdColony.AppOptions appOptions = new AdColony.AppOptions();
//			appOptions.UserId = "foo";
			appOptions.AdOrientation = AdColony.AdOrientationType.AdColonyOrientationAll;

			string[] zoneIDs = new string[] {adIds.ADCOLONY_InterstitialVideoZoneID, adIds.ADCOLONY_RewardedVideoZoneID};

			AdColony.Ads.Configure(adIds.ADCOLONY_appId, appOptions, zoneIDs);
		}


		#region ADColony Callbacks

		void OnConfigurationCompleted (List<AdColony.Zone> zones_)
		{
			Debug.Log("AdColony.Ads.OnConfigurationCompleted called");

			if (zones_ == null || zones_.Count <= 0) {
				// Show the configure asteroid again.
			}
			else {
				IsAdInitialized = true;

				// Successfully configured... show the request ad asteroid.
			}
		}

		void OnRequestInterstitial (AdColony.InterstitialAd ad_)
		{
			Debug.Log("AdColony.Ads.OnRequestInterstitial called");
			Ad = ad_;
			IsAdAvailable = true;

			// Successfully requested ad... show the play ad asteroid.
		}

		void OnRequestInterstitialFailed ()
		{
			Debug.Log("AdColony.Ads.OnRequestInterstitialFailed called");
			IsAdAvailable = false;

			// Request Ad failed... show the request ad asteroid.
		}

		void OnOpened (AdColony.InterstitialAd ad_)
		{
			Debug.Log("AdColony.Ads.OnOpened called");
			IsAdAvailable = false;

			// Ad started playing... show the request ad asteroid for the next ad.
		}

		void OnClosed (AdColony.InterstitialAd ad_)
		{
			Debug.Log("AdColony.Ads.OnClosed called, expired: " + ad_.Expired);
			IsAdAvailable = false;
		}

		void OnExpiring (AdColony.InterstitialAd ad_)
		{
			Debug.Log("AdColony.Ads.OnExpiring called");
			Ad = null;
			IsAdAvailable = false;

			// Current ad expired... show the request ad asteroid.
		}

		void OnIAPOpportunity (AdColony.InterstitialAd ad_, string iapProductId_, AdColony.AdsIAPEngagementType engagement_)
		{
			Debug.Log("AdColony.Ads.OnIAPOpportunity called");
		}

		void OnRewardGranted (string zoneId, bool success, string name, int amount)
		{
			Debug.Log(string.Format("AdColony.Ads.OnRewardGranted called\n\tzoneId: {0}\n\tsuccess: {1}\n\tname: {2}\n\tamount: {3}", zoneId, success, name, amount));

			if(successShowInterstitial != null)
			{
				successShowInterstitial(success);
			}

			successShowInterstitial = null;
		}

		void OnCustomMessageReceived (string type, string message)
		{
			Debug.Log(string.Format("AdColony.Ads.OnCustomMessageReceived called\n\ttype: {0}\n\tmessage: {1}", type, message));
		}

		#endregion

		#region VSADS interface methods

		public bool IsReadyVideoAds()
		{
			return IsAdAvailable;
		}

		public void CacheVideoAds()
		{
			Debug.Log("**** Cache ADColony Video Ads ****");

			AdColony.AdOptions adOptions = new AdColony.AdOptions();
			adOptions.ShowPrePopup = true;
			adOptions.ShowPostPopup = true;

			AdColony.Ads.RequestInterstitialAd(adIds.ADCOLONY_InterstitialVideoZoneID, adOptions);
		}

		public void ShowVideoAds()
		{
			Debug.Log("**** Play ADColony video ads ****");
	
			if (Ad != null) {
				AdColony.Ads.ShowAd(Ad);
				NotifyVideoInterstitialOpened();
			}
		}

		public void NotifyInterstitialOpened()
		{
			AdsManager.DOInterstitialOpened();
		}

		public void NotifyInterstitialClosed()
		{
			AdsManager.DOInterstitialClosed();
		}

		public void NotifyVideoInterstitialClosed()
		{
			AdsManager.DOVideoInterstitialClosed();
		}

		public void NotifyVideoInterstitialOpened()
		{
			AdsManager.DOVideoInterstitialOpened();
		}

		public bool IsReadyRewardedVideo()
		{
			return IsAdAvailable;
		}

		public void CacheRewardedVideo()
		{
			Debug.Log("**** Cache ADColony REWARDED Video Ads ****");

			AdColony.AdOptions adOptions = new AdColony.AdOptions();
			adOptions.ShowPrePopup = true;
			adOptions.ShowPostPopup = true;

			AdColony.Ads.RequestInterstitialAd(adIds.ADCOLONY_RewardedVideoZoneID, adOptions);
		}

		Action<bool> successShowInterstitial = null;

		public void ShowRewardedVideo(Action<bool> success)
		{
			Debug.Log("**** Play ADColony REWARDED video ****");

			successShowInterstitial = success;

			if (Ad != null) {
				AdColony.Ads.ShowAd(Ad);
			}
		}

		#endregion

	}
//	
//	public class AAADColony : AdBase, IVideoAds, IRewardedVideo
//	{
//
//public string Name()
//{
//return "AAADColony";
//}
//
//		public void Init()
//		{
//			if(FindObjectOfType<ADCAdManagerCustom>() == null)
//				gameObject.AddComponent<ADCAdManagerCustom>();
//		}
//
//		public bool IsReadyVideoAds()
//		{
//			return AdColony.IsVideoAvailable(adIds.ADCOLONY_InterstitialVideoZoneID);
//		}
//
//		public void CacheVideoAds(){}
//
//		public void ShowVideoAds()
//		{
//			if(AdColony.IsVideoAvailable(adIds.ADCOLONY_InterstitialVideoZoneID))
//			{
//				AdColony.OnVideoStarted += OnVideoStarted;
//				AdColony.OnVideoFinished += OnVideoFinished;
//				bool showAds = AdColony.ShowVideoAd(adIds.ADCOLONY_InterstitialVideoZoneID);
//				print("Ad Colony show interstitiazl video = " + showAds);
//		
//
//				return;
//			}
//			print("Ad Colony doesn't have interstitiazl video so don't show!!");
//		}
//
//		void OnVideoStarted()
//		{
//			NotifyVideoInterstitialOpened();
//		}
//
//		void OnVideoFinished(bool ad_shown)
//		{
//			NotifyVideoInterstitialClosed();
//		}
//
//		public bool IsReadyRewardedVideo()
//		{
//			return  AdColony.IsV4VCAvailable(adIds.ADCOLONY_RewardedVideoZoneID);
//		}
//
//		public void CacheRewardedVideo(){}
//
//		Action<bool> successRewardedVideoCallback = null;
//
//		void Unsubscribe()
//		{
//			AdColony.OnV4VCResult -= OnV4VCResult;
//			successRewardedVideoCallback = null;
//		}
//
//		public void ShowRewardedVideo(Action<bool> success)
//		{
//			Unsubscribe();
//
//			if(AdColony.IsV4VCAvailable(adIds.ADCOLONY_RewardedVideoZoneID))
//			{
//				print("adcolony have a rewarded video");
//			
//				successRewardedVideoCallback = success;
//				AdColony.OnV4VCResult += OnV4VCResult;
//				AdColony.OfferV4VC(true, adIds.ADCOLONY_RewardedVideoZoneID);
//
//				return;
//			}
//
//			print("adcolony have not rewarded video  so don't show!!");
//		}
//
//		void OnV4VCResult(bool successRewarded, string name, int amount)
//		{
//			print("adcolony have callback rewarded video success = " + successRewarded);
//
//			if(successRewardedVideoCallback != null)
//				successRewardedVideoCallback(successRewarded);
//		}
//
//		public void NotifyVideoInterstitialOpened()
//		{
//			AdsManager.DOVideoInterstitialOpened();
//		}
//
//		public void NotifyVideoInterstitialClosed()
//		{
//			AdsManager.DOVideoInterstitialClosed();
//		}
//	}
//
}

#endif