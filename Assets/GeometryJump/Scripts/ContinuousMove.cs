/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

/// <summary>
/// Class in charge to move the big hazard on the left continuously during the game
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class ContinuousMove : MonoBehaviorHelper 
	{

		public bool BLOCK_ME = false;

		public Transform spikes;
		public Transform spikeToClone;


		void OnEnable()
		{
			GameManager.OnGameStart += DoMove;
			GameManager.OnGameOverStarted += StopMove;
			GameManager.OnSetPoint += OnSetPoint;
			PlayerManager.OnPlayerJumpStarted += DoMove;
		}

		void OnDisable()
		{
			GameManager.OnGameStart -= DoMove;
			GameManager.OnGameOverStarted -= StopMove;
			GameManager.OnSetPoint -= OnSetPoint;
			PlayerManager.OnPlayerJumpStarted -= DoMove;
		}

		bool isMoving = false;

		public void StopMove()
		{
			isMoving = false;
		}

		public void DoMove()
		{
			isMoving = true;
		}


		float speed = 1;

		void OnSetPoint(int p)
		{
			speed++;
		}

		public 	List<Transform> l;

		void Start()
		{
			Reposition();



			l = new List<Transform>();

			int i = 1;

			l.Add(spikeToClone.transform);

			while(spikes.childCount < 200)
			{
				var t1 = Instantiate(spikeToClone.gameObject) as GameObject;
				var t2 = Instantiate(spikeToClone.gameObject) as GameObject;

				t1.transform.parent = spikes;
				t2.transform.parent = spikes;

				l.Add(t1.transform);
				l.Add(t2.transform);

				t1.transform.localScale = spikeToClone.localScale;
				t2.transform.localScale = spikeToClone.localScale;

				t1.transform.localPosition = new Vector3(i * -0.0163f, 0, 0);
				t2.transform.localPosition = new Vector3(i * +0.0163f, 0, 0);

				t1.transform.localRotation = spikeToClone.localRotation;
				t2.transform.localRotation = spikeToClone.localRotation;

				i++;
			}

			l.Sort(delegate(Transform c1, Transform c2){
				//			return Vector3.Distance(this.transform.position, c1.transform.position).CompareTo
				//				((Vector3.Distance(this.transform.position, c2.transform.position)));   
				return c1.position.y.CompareTo(c2.position.y);
			});


			for(int j = 0; j < spikes.childCount; j++)
			{
				Transform t = l[j];
				t.SetSiblingIndex(j);
				t.GetComponent<SpriteRenderer>().sortingOrder = 5 + t.GetSiblingIndex();
			}

			DoMoveSpikes();

		}



		float GetDistance()
		{
			float d = playerManager.transform.position.x - transform.position.x;
			return d;
		}

		void Update() 
		{

			if(BLOCK_ME)
			{
				return;
			}

			if(!isMoving)
				return;

			transform.Translate((GetDistance() + 5 + speed / 100f) * Time.deltaTime, 0, 0, Camera.main.transform);


			Vector2 pos = transform.position;

			pos.y = Mathf.Lerp(transform.position.y, playerManager.transform.position.y, Time.deltaTime);


			transform.position = pos;
		}

		public void Reposition()
		{
			float height = 2f * cam.orthographicSize;
			float width = height * cam.aspect;

			var p = transform.position;
			p.x = cam.transform.position.x - width/2f;
			transform.position = p;
		}

		void OnTriggerEnter2D(Collider2D other) 
		{
			var platform = other.GetComponent<PlatformLogic>();

			if(platform != null)
			{
				platform.DoMove();
				return;
			}

			var player = other.GetComponent<PlayerManager>();
			if(player != null)
			{
				player.LaunchGameOver();
				return;
			}
		}


		public void DoContinueRestart()
		{
			transform.position += 2 * Vector3.down;
		}

		void DoMoveSpikes()
		{
			var startposition = -0.0163f/3f;

			var endPosition = +0.0163f/3f;

			float timeMove = 0.3f;

			var pos = spikes.localPosition;
			pos.x = startposition;
			spikes.localPosition = pos;

			spikes.DOKill();
			spikes.DOLocalMoveX(endPosition, timeMove)
			//			.SetEase(Ease.Linear)
				.SetLoops(-1,LoopType.Yoyo);

		}
	}
}