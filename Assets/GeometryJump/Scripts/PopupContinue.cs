using UnityEngine;
//using UnityEngine.UI;
//using System;
//using System.Collections;
//
//public class PopupContinue : MonoBehaviorHelper
//{
//	
//	[SerializeField] private Transform popupContinueParent;
//	[SerializeField] private Image popupContinueFillImage;
//	[SerializeField] private Button buttonPopupContinue;
//	float speedFillImage = 2f;
//	float  speedScaleParent = 0.5f;
//	public bool m_OnClickedContinue;
//
//	void Awake()
//	{
//		popupContinueParent.gameObject.SetActive (false);
//	}
//
//	private float fillAmountPopupContinue
//	{
//		get 
//		{
//			return popupContinueFillImage.fillAmount;
//		}
//
//		set 
//		{
//			popupContinueFillImage.fillAmount = value;
//		}
//	}
//
//	private float scalePopupContinueParent
//	{
//		get 
//		{
//			return popupContinueParent.localScale.x;
//		}
//
//		set 
//		{
//			popupContinueParent.localScale = Vector3.one*value;
//		}
//	}
//
//	public void OnClickedContinue()
//	{
//		m_OnClickedContinue = true;
//
//		buttonPopupContinue.onClick.RemoveListener (OnClickedContinue);
//	}
//
//	public void OpenPopupContinue (Action<bool> onClick)
//	{
//		m_OnClickedContinue = false;
//
//		popupContinueParent.gameObject.SetActive (true);
//
//		scalePopupContinueParent = 0f;
//
//		fillAmountPopupContinue = 1f;
//
//
//		StartCoroutine (DoLerpImage (onClick));
//	}
//
//	IEnumerator DoLerpImage(Action<bool> onClick)
//	{
//		m_OnClickedContinue = false;
//
//		float timer = 0;
//		while (timer <= speedScaleParent)
//		{
//			timer += Time.deltaTime;
//			scalePopupContinueParent = Mathf.Lerp (0f, 1f, timer / speedScaleParent);
//			yield return null;
//		}
//
//		buttonPopupContinue.onClick.AddListener (OnClickedContinue);
//
//
//		timer = 0;
//		while (timer <= speedFillImage)
//		{
//			timer += Time.deltaTime;
//			fillAmountPopupContinue = Mathf.Lerp (1f, 0f, timer / speedFillImage);
//			yield return null;
//
//			if (m_OnClickedContinue)
//				break;
//		}
//
//		timer = 0;
//		while (timer <= speedScaleParent)
//		{
//			timer += Time.deltaTime;
//			scalePopupContinueParent = Mathf.Lerp (1, 0f, timer / speedScaleParent);
//
//			yield return 0;
//
//			if (m_OnClickedContinue)
//				break;
//		}
//
//		if (m_OnClickedContinue) 
//		{
//
//			timer = 0;
//			while (timer <= speedScaleParent)
//			{
//				timer += Time.deltaTime;
//				scalePopupContinueParent = Mathf.Lerp (1, 0f, timer / speedScaleParent);
//
//				yield return 0;
//			}
//
//
//			popupContinueParent.gameObject.SetActive (false);
//
//			scalePopupContinueParent = 0f;
//
//			fillAmountPopupContinue = 1f;
//		}
//
//		if (m_OnClickedContinue == true) 
//		{
//			adsManager.ShowRewardedVideoGameOver (onClick);
//		}
//		else 
//		{
//			if (onClick != null)
//				onClick (m_OnClickedContinue);
//		}
//	}
//
//
//}
