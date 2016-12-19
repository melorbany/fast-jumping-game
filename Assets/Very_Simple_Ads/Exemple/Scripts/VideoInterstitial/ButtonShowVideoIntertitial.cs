
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


using UnityEngine;
using System.Collections;
using AppAdvisory.Ads;

public class ButtonShowVideoIntertitial : ButtonBase 
{
	void Start()
	{
		SetText("Show Video Interstitial");
	}

	public override void OnClicked()
	{
		#if APPADVISORY_ADS
		AdsManager.instance.ShowVideoAds();
		#endif
	}
}
