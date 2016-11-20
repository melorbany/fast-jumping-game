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
/// Class in charge to animate button horizontaly, one to left, then one to right etc...
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class AnimButtonHierarchy : MonoBehaviour 
	{
		public float delay = 0;

		void OnEnable()
		{
			DoAnimIn();

		}

		void OnDisable()
		{

		}

		public void DoAnimIn()
		{
			int mult = 1;

			var buttons = transform.GetComponentsInChildren<ButtonAnimation>();

			foreach(var b in buttons)
			{
				b.interactable = false;
			}

			foreach(Transform t in transform)
			{
				var pos = t.GetComponent<RectTransform>().anchoredPosition;

				float xOrigin = pos.x;

				pos.x = mult *  2 * Screen.width;
				mult *= -1;
				t.GetComponent<RectTransform>().anchoredPosition = pos;
				t.GetComponent<RectTransform>().DOLocalMoveX(xOrigin, 1)
					.SetDelay(delay)
					.SetEase(Ease.OutBack,0.6f,1)
					.OnComplete(() => {
						foreach(var b in buttons)
						{
							b.interactable = true;
						}
					});
			}
		}

		public void DoAnimOut()
		{
			int mult = 1;

			var buttons = transform.GetComponentsInChildren<ButtonAnimation>();

			foreach(var b in buttons)
			{
				b.interactable = false;
			}

			foreach(Transform t in transform)
			{
				var pos = t.GetComponent<RectTransform>().anchoredPosition;

				float xOrigin = pos.x;

				t.GetComponent<RectTransform>().DOLocalMoveX(mult *  2 * Screen.width, 1)
					.SetDelay(delay)
					.SetEase(Ease.OutBack,0.6f,1)
					.OnComplete( () => {
						gameObject.SetActive(false);
						var p = t.GetComponent<RectTransform>().anchoredPosition;
						p.x = xOrigin;
						t.GetComponent<RectTransform>().anchoredPosition = pos;

						foreach(var b in buttons)
						{
							b.interactable = false;
						}
					});

				mult *= -1;
			}
		}
	}
}