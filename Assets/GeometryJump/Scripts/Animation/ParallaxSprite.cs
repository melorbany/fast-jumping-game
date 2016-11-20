/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace AppAdvisory.GeometryJump
{
	public class ParallaxSprite : MonoBehaviorHelper 
	{

		public Renderer rend = null;
		public Renderer rendChild = null;

		public Vector3 originalPosition;

		bool wasVisible = false;

		float smoothing()
		{
			return transform.localScale.x;
		}

		void OnEnable()
		{
			PlayerManager.OnPlayerJump += OnPlayerJump;
			wasVisible = false;
			transform.DOKill();
		}

		void OnDisable()
		{
			PlayerManager.OnPlayerJump -= OnPlayerJump;

			transform.DOKill();
		}

		public bool IsVisibleByCam()
		{
			return rend.IsVisibleFrom(cam);
		}

		void OnPlayerJump (float animTime, float distX, float distY, float jumpHeight)
		{
			float finalPosY = transform.position.y - smoothing()*distY;
			float finalPosX = transform.position.x - smoothing()*distX;
			float timeJump = animTime / 2f;

			if(!wasVisible)
			{
				wasVisible = IsVisibleByCam();
			}



			transform.DOMoveY(finalPosY - jumpHeight, smoothing()*timeJump)
				.OnComplete(() =>{
					transform.DOMoveY(finalPosY, smoothing()*timeJump)
						.SetEase(Ease.Linear);
				});

			transform.DOMoveX(finalPosX, smoothing()*animTime)
				.OnComplete(() => {
					if (IsVisibleByCam() == false)
					{
						//					Replace();
						gameObject.SetActive(false);
						gameManager.AddNewParallax();

					}
				});
		}
	}
}