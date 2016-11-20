/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

/// <summary>
/// Class in charge to animate the text "short jump" and "long jump" at start
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class AnimationTextTuto : MonoBehaviorHelper 
	{
		public float delay = 0;

		bool firstTouchDone = false;

		public RectTransform textLeft;
		public RectTransform textRight;

		float animTime
		{
			get
			{
				return playerManager.animTime/2f;
			}
		}

		void OnEnable()
		{
			InputTouch.OnTouchLeft += OnTouchLeft;
			InputTouch.OnTouchRight += OnTouchRight;
			CanvasManager.OnAnimationTransitionOutStart += DoAnimIn;
		}

		void OnDisable()
		{
			InputTouch.OnTouchLeft -= OnTouchLeft;
			InputTouch.OnTouchRight -= OnTouchRight;
			CanvasManager.OnAnimationTransitionOutStart -= DoAnimIn;
		}

		void OnTouchLeft()
		{
			textLeft.DOScale(Vector2.one * 0.8f,animTime)
				.SetEase(Ease.OutBack,0.6f,1)
				.OnComplete( () => {
					textLeft.DOScale(Vector2.one,animTime)
						.SetEase(Ease.InBack,0.6f,1);
				});
			OnTouch();
		}

		void OnTouchRight()
		{
			textRight.DOScale(Vector2.one * 0.8f,animTime)
				.SetEase(Ease.OutBack,0.6f,1)
				.OnComplete( () => {
					textRight.DOScale(Vector2.one,animTime)
						.SetEase(Ease.InBack,0.6f,1);
				});
			OnTouch();
		}

		void OnTouch()
		{
			if(!firstTouchDone)
			{
				firstTouchDone = true;
				Invoke("DoAnimOut",2);
			}
		}

		public void DoAnimIn()
		{
			CanvasManager.OnAnimationTransitionOutStart -= DoAnimIn;

			int mult = 1;

			foreach(Transform t in transform)
			{
				var pos = t.GetComponent<RectTransform>().anchoredPosition;

				float xOrigin = pos.x;

				pos.x = mult *  2 * Screen.width;
				mult *= -1;
				t.GetComponent<RectTransform>().anchoredPosition = pos;
				t.GetComponent<RectTransform>().DOLocalMoveX(xOrigin, 1)
					.SetDelay(delay)
					.SetEase(Ease.OutBack,0.6f,1);
			}
		}

		public void DoAnimOut()
		{
			int mult = 1;

			foreach(Transform t in transform)
			{
				var pos = t.GetComponent<RectTransform>().anchoredPosition;

				float xOrigin = pos.x;


				t.GetComponent<RectTransform>().DOLocalMoveX(mult *  2 * Screen.width, 1)
					.SetDelay(delay)
					.SetEase(Ease.InBack,0.6f,1)
					.OnComplete( () => {
						gameObject.SetActive(false);
						var p = t.GetComponent<RectTransform>().anchoredPosition;
						p.x = xOrigin;
						t.GetComponent<RectTransform>().anchoredPosition = pos;

						gameObject.SetActive(false);
					});

				mult *= -1;
			}
		}
	}
}