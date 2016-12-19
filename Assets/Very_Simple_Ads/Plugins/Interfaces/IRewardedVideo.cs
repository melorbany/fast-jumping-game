
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
	public interface IRewardedVideo : IIBase
	{
		bool IsReadyRewardedVideo();
		void CacheRewardedVideo();
		void ShowRewardedVideo(Action<bool> success);
	}
}