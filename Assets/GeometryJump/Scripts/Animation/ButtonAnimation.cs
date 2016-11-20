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
using UnityEngine.EventSystems;
using DG.Tweening;

/// <summary>
/// Class in charge to animate button when we press it
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class ButtonAnimation : MonoBehaviour,
	IPointerDownHandler, 
	ISubmitHandler,
	IPointerClickHandler,
	IPointerEnterHandler, 
	IPointerExitHandler,
	ISelectHandler,
	IDeselectHandler
	{

		public bool interactable = true;

		float animTime = 0.2f;

		#if UNITY_IOS || UNITY_ANDROID
		#else
		bool _isClicked = false;
		bool isClicked
		{
		set
		{
		_isClicked = value;

		if(_isClicked == true)
		Invoke("TurnIsClickedFalse",1);
		}

		get
		{
		return _isClicked;
		}
		}
		#endif

		void TurnIsClickedFalse()
		{
			#if UNITY_IOS || UNITY_ANDROID
			#else
			isClicked = false;
			#endif
		}

		public void OnPointerClick (PointerEventData eventData)
		{
			if(!interactable)
				return;

			#if UNITY_IOS || UNITY_ANDROID
			#else
			//print("OnPointerClick");
			if(isClicked)
			return;

			isClicked = true;
			#endif

			DoScale(transform.localScale.x/2f,animTime, () => {
				FindObjectOfType<CanvasManager>().OnClickedButton(gameObject);
				DoScale(transform.localScale.x*2f,animTime, () => {

				});
			});
		}

		public void OnSelect (BaseEventData eventData)
		{
			if(!interactable)
				return;

			#if UNITY_IOS || UNITY_ANDROID
			#else
			//print("OnSelect");
			DoScale(1.3f,animTime, () => {

			});
			#endif
		}

		public void OnDeselect (BaseEventData eventData)
		{
			if(!interactable)
				return;

			#if UNITY_IOS || UNITY_ANDROID
			#else
			//print("OnDeselect");
			DoScale(1.0f,animTime, () => {

			});
			#endif
		}


		public void OnPointerDown (PointerEventData eventData)
		{
			if(!interactable)
				return;

			#if UNITY_IOS || UNITY_ANDROID
			#else
			//print("OnPointerDown");
			if(isClicked)
			return;

			isClicked = true;

			DoScale(transform.localScale.x/2f,animTime, () => {
			FindObjectOfType<CanvasManager>().OnClickedButton(gameObject);
			DoScale(transform.localScale.x*2f,animTime, () => {
			});
			});
			#endif
		}

		public void OnSubmit (BaseEventData eventData)
		{
			#if UNITY_IOS || UNITY_ANDROID
			#else
			//print("OnSubmit");
			if(isClicked)
			return;

			isClicked = true;

			DoScale(transform.localScale.x/2f,animTime, () => {
			FindObjectOfType<CanvasManager>().OnClickedButton(gameObject);
			DoScale(transform.localScale.x*2f,animTime, () => {
			});
			});
			#endif
		}

		public void OnPointerEnter (PointerEventData eventData)
		{
			if(!interactable)
				return;

			#if UNITY_IOS || UNITY_ANDROID
			#else
			//print("OnPointerEnter");
			DoScale(1.3f,animTime, () => {

			});
			#endif
		}

		public void OnPointerExit (PointerEventData eventData)
		{
			if(!interactable)
				return;

			#if UNITY_IOS || UNITY_ANDROID
			#else
			//print("OnPointerExit");
			DoScale(1f,animTime, () => {

			});
			#endif
		}


		void DoScale(float toS, float duration, Action OnCompete)
		{
			//		StopAllCoroutines();
			//		StartCoroutine(_DoScale(toS, duration, OnCompete));
			//
			transform.DOKill();

			transform.DOScale(toS, duration).OnComplete(() => {
				if(OnCompete != null)
					OnCompete();
			});
		}

		IEnumerator _DoScale(float toS, float duration, Action OnCompete)
		{

			float timer = 0;

			float fromS = transform.localScale.x;

			while (timer <= duration)
			{
				timer += Time.deltaTime;
				transform.localScale = Vector2.one * Mathf.Lerp (fromS, toS, timer / duration);
				yield return null;
			}

			transform.localScale = Vector2.one * toS;


			yield return null;


			if(OnCompete != null)
				OnCompete();
		}
	}
}