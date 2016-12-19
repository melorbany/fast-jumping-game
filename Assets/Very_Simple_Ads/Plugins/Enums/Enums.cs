
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


public enum BannerNetwork
{
	#if ENABLE_ADMOB
	Admob,
	#endif

	#if ENABLE_IAD
	iAd,
	#endif

	NULL
}

public enum InterstitialNetwork
{
	#if ENABLE_ADMOB
	Admob,
	#endif

//	#if ENABLE_IAD
//	iAd,
//	#endif

	#if CHARTBOOST
	Chartboost,
	#endif

	NULL
}


public enum RewardedVideoNetwork
{
	#if ENABLE_ADMOB
	Admob,
	#endif

	#if UNITY_ADS
	UnityAds,
	#endif

	#if CHARTBOOST
	Chartboost,
	#endif

	#if ENABLE_ADCOLONY
	ADColony,
	#endif

	NULL
}


public enum VideoNetwork
{
	#if UNITY_ADS
	UnityAds,
	#endif

	#if ENABLE_ADCOLONY
	ADColony,
	#endif

	NULL
}