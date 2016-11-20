/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using DG.Tweening;

/// <summary>
/// Class to animate the transition windows at start and at restart
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class AnimationTransition : MonoBehaviorHelper 
	{
		public Image leftImage;
		public Image rightImage;


		float ratio = 1;

		float timeAnim = 0.6f;
		float divide = 2f;

		void OnEnable()
		{
			Color c = cam.backgroundColor;

			leftImage.color = c;
			rightImage.color = c;

			var posL = leftImage.rectTransform.anchoredPosition;
			posL.x = 0;
			leftImage.rectTransform.anchoredPosition = posL;

			var posR = rightImage.rectTransform.anchoredPosition;
			posR.x = 0;
			rightImage.rectTransform.anchoredPosition = posR;
		}

		public void DoAnimationIn(Action callback)
		{
			gameObject.SetActive(true);
			canvasManager._AnimationTransitionInStart();

			Color c = cam.backgroundColor;

			leftImage.color = c;
			rightImage.color = c;

			var posL = leftImage.rectTransform.anchoredPosition;
			posL.x = - ratio * Screen.width/divide;
			leftImage.rectTransform.anchoredPosition = posL;

			var posR = rightImage.rectTransform.anchoredPosition;
			posR.x = + ratio * Screen.width/divide;
			rightImage.rectTransform.anchoredPosition = posR;

			leftImage.rectTransform.DOLocalMoveX(0,timeAnim)
				.SetEase(Ease.InQuad)
				.OnComplete( () => {
					GC.Collect();
					Application.targetFrameRate = 60;
					DOVirtual.DelayedCall(0.2f, () => {
						canvasManager._AnimationTransitionInEnd();

						if(callback != null)
							callback();
					});

				});

			rightImage.rectTransform.DOLocalMoveX(0,timeAnim)
				.SetEase(Ease.InQuad);
		}


		public void DoAnimationOut(Action callback)
		{
			canvasManager._AnimationTransitionOutStart();

			Color c = cam.backgroundColor;

			leftImage.color = c;
			rightImage.color = c;

			var posL = leftImage.rectTransform.anchoredPosition;
			posL.x = 0;
			leftImage.rectTransform.anchoredPosition = posL;

			var posR = rightImage.rectTransform.anchoredPosition;
			posR.x = 0;
			rightImage.rectTransform.anchoredPosition = posR;

			leftImage.rectTransform.DOLocalMoveX(- ratio * Screen.width/divide,timeAnim)
				.SetDelay(0.3f)
				.SetEase(Ease.OutQuad);

			rightImage.rectTransform.DOLocalMoveX(+ ratio * Screen.width/divide,timeAnim)
				.SetDelay(0.3f)
				.SetEase(Ease.OutQuad)
				.OnComplete( () => {

					canvasManager._AnimationTransitionOutEnd();

					gameObject.SetActive(false);

					if(callback != null)
						callback();
				});
		}
	}
}