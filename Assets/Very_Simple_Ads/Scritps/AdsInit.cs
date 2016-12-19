
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
using System.Collections.Generic;
using System;

namespace AppAdvisory.Ads
{
	public class AdsInit : MonoBehaviour 
	{
		public ADIDS _ADIDS;

		public void SetADIDS(ADIDS t)
		{
			this._ADIDS = t;
		}

		[SerializeField] public BannerNetwork bannerNetwork = BannerNetwork.NULL ;

		#if ENABLE_ADMOB
		public GoogleMobileAds.Api.AdSize AdmobBannerSize = GoogleMobileAds.Api.AdSize.SmartBanner;
		public GoogleMobileAds.Api.AdPosition AdmobBannerPosition = GoogleMobileAds.Api.AdPosition.Bottom;
		#endif


		[SerializeField] public List<InterstitialNetwork> interstitialNetworks = new List<InterstitialNetwork>(new InterstitialNetwork[] {InterstitialNetwork.NULL});
		[SerializeField] public List<VideoNetwork> videoNetworks = new List<VideoNetwork>(new VideoNetwork[] {VideoNetwork.NULL});
		[SerializeField] public List<RewardedVideoNetwork> rewardedVideoNetworks = new List<RewardedVideoNetwork>( new RewardedVideoNetwork[] {RewardedVideoNetwork.NULL});

		void Awake()
		{
			if(FindObjectOfType<AdsManager>() == null)
			{
				var o = new GameObject();
				o.SetActive(false);
			
				var adsManager = o.AddComponent<AdsManager>();

				adsManager.enabled = false;

				o.name = "_AdsManager";

				adsManager.adIds = this._ADIDS;
				adsManager.randomize = _ADIDS.RandomizeNetworks;
				adsManager.bannerNetwork = this.bannerNetwork;
				adsManager.interstitialNetworks = this.interstitialNetworks;
				adsManager.videoNetworks = this.videoNetworks;
				adsManager.rewardedVideoNetworks = this.rewardedVideoNetworks;

				#if ENABLE_ADMOB
				adsManager.AdmobBannerSize = AdmobBannerSize;
				adsManager.AdmobBannerPosition = AdmobBannerPosition;
				#endif

				adsManager.enabled = true;

				o.SetActive(true);

				adsManager.DOAwake();
				adsManager.DOStart();
			}

			Destroy(gameObject);
		}
	}
}