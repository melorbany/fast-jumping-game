
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


using UnityEngine;
using System;
using System.Collections;

namespace AppAdvisory.Ads
{
	public interface IInterstitial : IIBase
	{
		bool IsReadyInterstitial();
		bool IsReadyInterstitialStartup();
		void CacheInterstitial();
		void CacheInterstitialStartup();
		void ShowInterstitial(Action<bool> succes);
		void ShowInterstitialStartup(Action<bool> succes);
		void NotifyInterstitialOpened();
		void NotifyInterstitialClosed();
	}
}