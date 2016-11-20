/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// Class in charge to popup the rate us system 
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class RateUsManager : MonoBehaviour 
	{
		public int NumberOfLevelPlayedToShowRateUs = 30;
		public string iOSURL = "itms://itunes.apple.com/us/app/apple-store/id1086918021?mt=8";
		public string ANDROIDURL = "http://app-advisory.com";

		public Button btnYes;
		public Button btnLater;
		public Button btnNever;

		public CanvasGroup popupCanvasGroup;

		void Awake()
		{
			popupCanvasGroup.alpha = 0;
			popupCanvasGroup.gameObject.SetActive(false);
		}

		void OnEnable()
		{
			GameManager.OnGameOverStarted += CheckIfPromptRateDialogue;
		}

		void OnDisable()
		{
			GameManager.OnGameOverStarted -= CheckIfPromptRateDialogue;
		}

		void AddButtonListeners()
		{
			btnYes.onClick.AddListener(OnClickedYes);
			btnLater.onClick.AddListener(OnClickedLater);
			btnNever.onClick.AddListener(OnClickedNever);
		}

		void RemoveButtonListener()
		{
			btnYes.onClick.RemoveListener(OnClickedYes);
			btnLater.onClick.RemoveListener(OnClickedLater);
			btnNever.onClick.RemoveListener(OnClickedNever);
		}

		void OnClickedYes()
		{
			#if UNITY_IPHONE
			Application.OpenURL(iOSURL);
			#endif

			#if UNITY_ANDROID
			Application.OpenURL(ANDROIDURL);
			#endif

			PlayerPrefs.SetInt("NUMOFLEVELPLAYED",-1);
			PlayerPrefs.Save();
			HidePopup();
		}

		void OnClickedLater()
		{
			PlayerPrefs.SetInt("NUMOFLEVELPLAYED",0);
			PlayerPrefs.Save();
			HidePopup();
		}

		void OnClickedNever()
		{
			PlayerPrefs.SetInt("NUMOFLEVELPLAYED",-1);
			PlayerPrefs.Save();
			HidePopup();
		}

		void CheckIfPromptRateDialogue()
		{
			int count = PlayerPrefs.GetInt("NUMOFLEVELPLAYED",0);

			if(count == -1)
				return;

			count ++;

			if(count > NumberOfLevelPlayedToShowRateUs)
			{
				PromptPopup();
			}
			else
			{
				PlayerPrefs.SetInt("NUMOFLEVELPLAYED",count);
			}

			PlayerPrefs.Save();
		}

		public void PromptPopup()
		{
			popupCanvasGroup.alpha = 0;
			popupCanvasGroup.gameObject.SetActive(true);
			popupCanvasGroup.DOFade(1,1).OnComplete(()=>{
				AddButtonListeners();
			});

		}

		void HidePopup()
		{
			popupCanvasGroup.alpha = 1;
			popupCanvasGroup.DOFade(0,1).OnComplete(()=>{
				popupCanvasGroup.gameObject.SetActive(false);
				RemoveButtonListener();
			});
		}
	}
}