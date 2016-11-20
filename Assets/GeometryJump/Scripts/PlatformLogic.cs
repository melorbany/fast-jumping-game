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
	/// <summary>
	/// Class in charge to animate the platform when the player jump
	/// </summary>
	public class PlatformLogic : MonoBehaviorHelper
	{
		public DiamondLogic diamond;

		public GameObject lastScore;

		public GameObject bestScore;

		public Vector2 position
		{
			set
			{
				transform.position = value;
			}
		}

		Collider2D col = null;

		void Awake()
		{
			col = GetComponent<Collider2D>();
			lastScore.SetActive(false);
			bestScore.SetActive(false);
			diamond.gameObject.SetActive(false);
		}

		void OnEnable()
		{
			col.enabled = true;
			transform.DOKill();
		}

		void OnDisable()
		{
			lastScore.SetActive(false);
			bestScore.SetActive(false);
			diamond.gameObject.SetActive(false);
			transform.DOKill();
		}

		public void ActivateDiamond()
		{
			diamond.gameObject.SetActive(true);
		}

		public void DoMove()
		{
			float height = 2f * cam.orthographicSize;
			//		float width = height * cam.aspect;

			float startPosY = transform.position.y;
			float finalPosY = startPosY - height;

			float timeMove = 2f;

			//		transform.DOShakePosition(0.2f,0.2f,10,90)
			//			.OnComplete( () => {
			transform.DOMoveY(finalPosY, timeMove)
				.OnComplete( () => {
					gameObject.SetActive(false);
					gameManager.DoSpawn();
					transform.DOKill();
				});
			//			});

		}
	}
}