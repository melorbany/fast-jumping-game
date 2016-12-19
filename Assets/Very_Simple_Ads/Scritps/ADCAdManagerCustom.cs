
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

/// <summary>
/// This is a static class that references a singleton object in order to provide a simple interface for
/// interacting with the AdColony functionality.
///
/// This object is self-composing, meanining that it doesn't need to be added to the unity hierarchy list
/// in order to make calls to it. It will create the object if a call is made to it and it doesn't exist.
///
/// If desired you can still add it to the scene, however changing to another scene with an AdManager declared
/// will throw an error because two AdManagers will exist. This is because this object has DontDestroyOnLoad
/// called on it so that the scene changes will not affect its state.
///
/// To destroy this object you must manually call Destroy() on it.
///
/// This object uses a dictionary to associate arbitrary string names with video zones.
/// These arbitrary string names serve as a way to retrieve the zone information easier,
/// so that the developer does not need to remember random numbers.
///
/// The dictionary is configured by the 'ConfigureZones()' which in turn is called by the
/// 'ConfigureADCPlugin()' method on Awake()
/// </summary>

namespace AppAdvisory.Ads
{
//	#if ENABLE_ADCOLONY
//	public class ADCAdManagerCustom : Singleton<ADCAdManagerCustom>  
//	{
//	#else
//	public class ADCAdManagerCustom : MonoBehaviour
//	{
//	#endif
//
//		public ADIDS adIds;
//
//		#if ENABLE_ADCOLONY
////		protected ADCAdManagerCustom () {} // guarantee this will be always a singleton only - can't use the constructor!
//
//		public int onVideoFinishedCounter = 0;
//		public int onVideoFinishedWithInfoCounter = 0;
//		public int onV4VCResultCounter = 0;
//		public int onAdAvailabilityChangeCounter = 0;
//
//		public int GetCounter(string counterName) {
//			switch(counterName) {
//			case "VideoFinished":
//				return onVideoFinishedCounter;
//			case "VideoFinishedWithInfo":
//				return onVideoFinishedWithInfoCounter;
//			case "V4VC":
//				return onV4VCResultCounter;
//			case "AdAvailable":
//				return onAdAvailabilityChangeCounter;
//			default:
//				return -1;
//			}
//		}
//
//		// Currency tracker for the player
//		public int regularCurrency = 0;
//
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
//		public Dictionary<string, ADCVideoZoneCustom> videoZones = new Dictionary<string, ADCVideoZoneCustom>();
//
//		void Awake() {
//			//This calls the ADColony SDK's configure method in order to set up the zones for playing ads
//			ConfigureADCPlugin();
//
//			// These set the delegate functions that are called when these events fired by the ADColony SDK.
//			// This is done so that users can have custom methods to respond to these events.
//			AddOnVideoStartedMethod(OnVideoStarted);
//			AddOnVideoFinishedMethod(OnVideoFinished);
//			AddOnVideoFinishedWithInfoMethod(OnVideoFinishedWithInfo);
//			AddOnV4VCResultMethod(OnV4VCResult);
//			AddOnAdAvailabilityChangeMethod(OnAdAvailabilityChange);
//
//			DontDestroyOnLoad(this.gameObject);
//		}
//
//		List<AudioListener> listAudioListener;
//
//		public void Pause() 
//		{
//			var audioListeners = FindObjectsOfType<AudioListener>();
//
//			listAudioListener = new List<AudioListener>();
//
//			if(audioListeners != null) 
//			{
//				foreach(var a in audioListeners)
//				{
//					if(a.enabled)
//					{
//						a.enabled = false;
//						listAudioListener.Add(a);
//					}
//				}
//			}
//
//			Time.timeScale = 0;
//		}
//
//		public void Resume()
//		{
//			if(listAudioListener != null)
//			{
//				foreach(var a in listAudioListener)
//				{
//					a.enabled = true;
//				}
//			}
//
//			Time.timeScale = 1;
//		}
//
//		public void ConfigureADCPlugin() {
//			//THIS MUST BE RUN BEFORE ADCOLONY.CONFIGURE() IN ORDER FOR THE AD MANAGER TO BE AWARE OF WHAT INFORMATION TO PASS TO THE ADCOLONY PLUGIN
//			ConfigureZones();
//
//			// This configures the AdColony SDK so that the application is targetting the correct zone for generating ads
//			AdColony.Ads.Configure (version, // Arbitrary app version
//				appId,   // ADC App ID from adcolony.com
//				GetVideoZoneIdsAsStringArray());
//		}
//
//		/// <summary>
//		/// This method uses platform dependent compilation to determine what type of app id and zone id to use for the buttons. There are other ways to do this, but platform dependent compliation makes it easier for the code to stay all in one place for configuration.
//		/// Reference: http://docs.unity3d.com/Manual/PlatformDependentCompilation.html
//		/// </summary>
//		public void ConfigureZones() {
//			//		appId = AdsManager.instance.adIds.ADCOLONY_appId;
//			#if ENABLE_ADCOLONY
//			// Video zones
//			AddZoneToManager(FindObjectOfType<AppAdvisory.Ads.AdsManager>().adIds.ADCOLONY_InterstitialVideoZoneKEY, FindObjectOfType<AppAdvisory.Ads.AdsManager>().adIds.ADCOLONY_InterstitialVideoZoneID, ADCVideoZoneTypeCustom.Interstitial);
//			#endif
//
//			#if ENABLE_ADCOLONY
//			// V4VC zones
//			AddZoneToManager(FindObjectOfType<AppAdvisory.Ads.AdsManager>().adIds.ADCOLONY_RewardedVideoZoneKEY, FindObjectOfType<AppAdvisory.Ads.AdsManager>().adIds.ADCOLONY_RewardedVideoZoneID, ADCVideoZoneTypeCustom.V4VC);
//			#endif
//		}
//
//		//---------------------------------------------------------------------------
//		// Default Delegate Methods
//		//---------------------------------------------------------------------------
//		private void OnVideoStarted() {
//			Pause();
//		}
//
//		private void OnVideoFinished( bool adWasShown ) {
//			++onVideoFinishedCounter;
//			Debug.Log("On Video Finished Counter " + onVideoFinishedCounter);
//			Debug.Log("On Video Finished, and Ad was shown: " + adWasShown);
//			Resume();
//		}
//
//		private void OnVideoFinishedWithInfo( AdColony.Ads.ia ad ) {
//			++onVideoFinishedWithInfoCounter;
//			Debug.Log("On Video Finished With Info, ad Played: " + ad.toString() );
//			if(ad.iapEnabled) {
//				AdColony.NotifyIAPComplete("ProductID", "TransactionID", null, 0, 1);
//			}
//			Resume();
//		}
//
//		private void OnV4VCResult(bool success, string name, int amount) {
//			++onV4VCResultCounter;
//			if(success) {
//				Debug.Log("V4VC SUCCESS: name = " + name + ", amount = " + amount);
//				AddToCurrency(amount);
//			} else {
//				Debug.LogWarning("V4VC FAILED!");
//			}
//		}
//
//		private void OnAdAvailabilityChange( bool avail, string zoneId) {
//			++onAdAvailabilityChangeCounter;
//			Debug.Log("Ad Availability Changed to available=" + avail + " In zone: "+ zoneId);
//		}
//
//		//---------------------------------------------------------------------------
//		// AdManager Delegate Wrapper
//		//---------------------------------------------------------------------------
//		public static void AddOnVideoStartedMethod(AdColony.VideoStartedDelegate onVideoStarted) {
//			AdColony.OnVideoStarted += onVideoStarted;
//		}
//		public static void RemoveOnVideoStartedMethod(AdColony.VideoStartedDelegate onVideoStarted) {
//			AdColony.OnVideoStarted -= onVideoStarted;
//		}
//		//-----------------
//		public static void AddOnVideoFinishedMethod(AdColony.VideoFinishedDelegate onVideoFinished) {
//			AdColony.OnVideoFinished += onVideoFinished;
//		}
//		public static void RemoveOnVideoFinishedMethod(AdColony.VideoFinishedDelegate onVideoFinished) {
//			AdColony.OnVideoFinished -= onVideoFinished;
//		}
//		//-----------------
//		public static void AddOnVideoFinishedWithInfoMethod(AdColony.VideoFinishedWithInfoDelegate onVideoFinishedWithInfo) {
//			AdColony.OnVideoFinishedWithInfo += onVideoFinishedWithInfo;
//		}
//		public static void RemoveOnVideoFinishedWithInfoMethod(AdColony.VideoFinishedWithInfoDelegate onVideoFinishedWithInfo) {
//			AdColony.OnVideoFinishedWithInfo -= onVideoFinishedWithInfo;
//		}
//		//-----------------
//		public static void AddOnV4VCResultMethod(AdColony.V4VCResultDelegate onV4VCResult) {
//			AdColony.OnV4VCResult += onV4VCResult;
//		}
//		public static void RemoveOnV4VCResultMethod(AdColony.V4VCResultDelegate onV4VCResult) {
//			AdColony.OnV4VCResult -= onV4VCResult;
//		}
//		//-----------------
//		public static void AddOnAdAvailabilityChangeMethod(AdColony.AdAvailabilityChangeDelegate onAdAvailabilityChange) {
//			AdColony.OnAdAvailabilityChange += onAdAvailabilityChange;
//		}
//		public static void RemoveOnAdAvailabilityChangeMethod(AdColony.AdAvailabilityChangeDelegate onAdAvailabilityChange) {
//			AdColony.OnAdAvailabilityChange -= onAdAvailabilityChange;
//		}
//
//		//---------------------------------------------------------------------------
//		// ADCAdManagerCustom Property/Attribute Interaction
//		//---------------------------------------------------------------------------
//		public static void AddToCurrency(int amountToAddToCurrency) {
//			ADCAdManagerCustom.Instance.regularCurrency += amountToAddToCurrency;
//		}
//
//		public static int GetRegularCurrencyAmount() {
//			return ADCAdManagerCustom.Instance.regularCurrency;
//		}
//
//		//---------------------------------------------------------------------------
//		// Zone Manager General Methods
//		//---------------------------------------------------------------------------
//		public static void ResetADCAdManagerCustomZones() {
//			ADCAdManagerCustom.GetVideoZonesDictionary().Clear();
//		}
//
//		public static void AddZoneToManager(string zoneKey, string zoneId, ADCVideoZoneTypeCustom videoZoneType) {
//			zoneKey = zoneKey.ToLower();
//			if(ContainsZoneKey(zoneKey)) {
//				//			Debug.LogWarning("The ad manager overwrote the previous video zoneId: " + GetZoneIdByKey(zoneKey) + " for the video zone named " + zoneKey + " with the new video zoneId of: " + zoneId);
//			}
//			else {
//				//			Debug.LogWarning("The ad manager has added the video zone named " + zoneKey + " with the video zoneId of: " + zoneId);
//				ADCAdManagerCustom.GetVideoZonesDictionary().Add(zoneKey, new ADCVideoZoneCustom(zoneId, videoZoneType));
//			}
//		}
//
//		public static ADCVideoZoneCustom GetVideoZoneObjectByKey(string key) {
//			key = key.ToLower();
//			if(ContainsZoneKey(key)) {
//				return ADCAdManagerCustom.GetVideoZonesDictionary()[key];
//			}
//			else {
//				return null;
//			}
//		}
//
//		public static string GetZoneIdByKey(string key) {
//			key = key.ToLower();
//			if(ContainsZoneKey(key)) {
//				return ADCAdManagerCustom.GetVideoZonesDictionary()[key].zoneId;
//			}
//			else {
//				return "";
//			}
//		}
//
//		public static bool ContainsZoneKey(string key) {
//			key = key.ToLower();
//			if(GetVideoZonesDictionary().ContainsKey(key)) {
//				return true;
//			}
//			else {
//				return false;
//			}
//		}
//
//		public static void RemoveZoneFromManager(string zoneKey) {
//			zoneKey = zoneKey.ToLower();
//			ADCAdManagerCustom.GetVideoZonesDictionary().Remove(zoneKey);
//		}
//
//		public static string[] GetVideoZoneIdsAsStringArray() {
//			Dictionary<string, ADCVideoZoneCustom> videoZones = GetVideoZonesDictionary();
//			string[] allZones = new string[GetVideoZonesDictionary().Count];
//			int currentKeyValuePair = 0;
//			foreach(KeyValuePair<string, ADCVideoZoneCustom> keyValuePair in videoZones) {
//				allZones[currentKeyValuePair] = keyValuePair.Value.zoneId;
//				currentKeyValuePair++;
//			}
//
//			return allZones;
//		}
//
//		public static Dictionary<string, ADCVideoZoneCustom> GetVideoZonesDictionary() {
//			return ADCAdManagerCustom.Instance.videoZones;
//		}
//
//		public static void ShowVideoAdByZoneKey(string zoneIdKey, bool offerV4VCBeforePlay = false, bool showPopUpAfter = false) {
//			ADCVideoZoneCustom videoZone = GetVideoZoneObjectByKey(zoneIdKey);
//			string zoneId = GetZoneIdByKey(zoneIdKey);
//			if(videoZone.zoneType == ADCVideoZoneTypeCustom.Interstitial && AdColony.IsVideoAvailable(zoneId)) {
//				AdColony.ShowVideoAd(zoneId);
//			}
//			else if(videoZone.zoneType == ADCVideoZoneTypeCustom.V4VC && AdColony.IsV4VCAvailable(zoneId)) {
//				if(offerV4VCBeforePlay) {
//					AdColony.OfferV4VC(showPopUpAfter, zoneId);
//				} else {
//					AdColony.ShowV4VC(showPopUpAfter, zoneId);
//				}
//			} else {
//				Debug.Log("AdColony ---- The zone '" + zoneId + "' was requested to play, but it is NOT ready to play yet.");
//			}
//		}
//		#endif
//	}
//
//	#if ENABLE_ADCOLONY
//	public class ADCVideoZoneCustom {
//
//		public string zoneId = "";
//		public ADCVideoZoneTypeCustom zoneType = ADCVideoZoneTypeCustom.None;
//
//		public ADCVideoZoneCustom(string newZoneId, ADCVideoZoneTypeCustom newVideoZoneType) {
//			zoneId = newZoneId;
//			zoneType = newVideoZoneType;
//		}
//	}
//
//	public enum ADCVideoZoneTypeCustom {
//		None,
//		Interstitial,
//		V4VC
//	}
//	#endif
}