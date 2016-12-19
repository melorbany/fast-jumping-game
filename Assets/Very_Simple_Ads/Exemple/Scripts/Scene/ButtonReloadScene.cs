
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


using UnityEngine;
using System.Collections;
#if UNITY_5_3_OR_NEWER
using UnityEngine.SceneManagement;
#endif
using AppAdvisory.Ads;

public class ButtonReloadScene : ButtonBase 
{
	void Start()
	{
		SetText("Reload Scene");
	}

	public override void OnClicked()
	{
		#if UNITY_5_3_OR_NEWER
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name,LoadSceneMode.Single);
		#else
		Application.LoadLevelAsync(Application.loadedLevel);
		#endif

		AdsManager.OnVideoInterstitialClosed += OnVideoInterstitialClosed;

	}


	void OnVideoInterstitialClosed()
	{
		//Do your stuff here
	}
}
