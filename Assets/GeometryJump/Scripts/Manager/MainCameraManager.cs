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

/// <summary>
/// Class in charge to animate the camera zoom
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class MainCameraManager : MonoBehaviorHelper
	{
		bool isGameOver;

		public float yDecal = -3.5f;

		void Awake()
		{
			canZoom = false;
		}

		bool canZoom = true;

		void OnEnable()
		{
			PlayerManager.OnPlayerJumpStarted += OnPlayerJumpStarted;
			PlayerManager.OnPlayerJumpEnded += OnPlayerJumpEnded;
			GameManager.OnGameOverStarted += OnGameOverStarted;
			CanvasManager.OnAnimationTransitionOutStart += OnAnimationTransitionOutStart;
		}

		void OnDisable()
		{
			PlayerManager.OnPlayerJumpStarted -= OnPlayerJumpStarted;
			PlayerManager.OnPlayerJumpEnded -= OnPlayerJumpEnded;
			GameManager.OnGameOverStarted -= OnGameOverStarted;
			CanvasManager.OnAnimationTransitionOutStart -= OnAnimationTransitionOutStart;
		}

		void OnAnimationTransitionOutStart()
		{
			var pos = transform.position;
			pos.y = playerManager.transform.position.y + yDecal;
			transform.position = pos;

			canZoom = true;
			DOVirtual.DelayedCall(0.2f,()=>{
				canZoom = false;
				float o = cam.orthographicSize;
				cam.orthographicSize = 1;
				cam.DOOrthoSize(o,1).OnComplete(() => {
					canZoom = true;
				});
				CanvasManager.OnAnimationTransitionOutStart -= OnAnimationTransitionOutStart;
			});

		}

		void OnPlayerJumpStarted()
		{
			isGameOver = false;
		}

		void OnPlayerJumpEnded()
		{
			isGameOver = false;
		}

		void OnGameOverStarted()
		{
			isGameOver = true;
		}

		float GetDistance()
		{
			return 2*(transform.position.x - continuousMove.transform.position.x);
		}

		public void UpdatePos(Vector3 startPos, Vector3 finalPos)
		{
			startPos.y += yDecal;
			finalPos.y += yDecal;
			startPos.z = transform.position.z;
			finalPos.z = transform.position.z;
			transform.DOMove(finalPos, animTime);
		}

		float animTime
		{
			get
			{
				return playerManager.animTime;
			}
		}

		private float maxZoomIn = 15;
		private float zoomSpeed
		{
			get
			{
				return 2f;
			}
		}

		float lastUpdate = float.PositiveInfinity;

		void Update()
		{
			if(!canZoom || continuousMove.BLOCK_ME)
				return;

			if(!isGameOver)
			{
				if(lastUpdate == float.PositiveInfinity)
				{
					lastUpdate = Time.realtimeSinceStartup;

				}

				float temp = Mathf.Max(maxZoomIn, GetDistance());

				float ratio = 2f;

				if(cam.orthographicSize < temp)
					ratio = 5;

				cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,  temp, ratio * zoomSpeed * Time.deltaTime);
			}
			else
			{
				cam.orthographicSize = Mathf.Lerp(cam.orthographicSize,  maxZoomIn, zoomSpeed * Time.deltaTime);
			}
		}
	}
}