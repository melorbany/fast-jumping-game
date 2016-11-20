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
using System.Collections.Generic;

/// <summary>
/// Class in charge to manage the game logic
/// </summary>
using SmartLocalization;
using ArabicSupport;


namespace AppAdvisory.GeometryJump
{
	public class GameManager : MonoBehaviorHelper 
	{
		public delegate void _GameStart();
		public static event _GameStart OnGameStart;

		public delegate void _GameOverStart();
		public static event _GameOverStart OnGameOverStarted;

		public delegate void _GameOverEnd();
		public static event _GameOverEnd OnGameOverEnded;

		public delegate void _SetPoint(int point);
		public static event _SetPoint OnSetPoint;

		public delegate void _SetDiamond(int diamond);
		public static event _SetDiamond OnSetDiamond;

		public delegate void _SetLife(int life);
		public static event _SetLife OnSetLife;


		//obstacle prefabs
		public Transform obstacleRectanglePrefab;

		public List<PlatformLogic> obstacleRectanglePrefabList = new List<PlatformLogic>();

		//obstacle prefabs


		//obstacle prefabs
		public Transform paralaxSpritePrefab;

		public List<ParallaxSprite> paralaxSpriteList = new List<ParallaxSprite>();

		//obstacle prefabs

		[SerializeField] private Score SCORE;
		[SerializeField] private Item LIFE;
		[SerializeField] private Item DIAMOND;


		public int AddPoint(int p)
		{
			int temp = this.SCORE.AddPoint(p);

			if(OnSetPoint != null)
				OnSetPoint(temp);

			return temp;
		}

		public int GestBestScore()
		{
			return this.SCORE.GetBest();
		}

		public int GestLastScore()
		{
			return this.SCORE.GetLast();
		}

		public int GetPoint()
		{
			return this.SCORE.GetPoint();
		}

		public bool HaveLife()
		{
			return this.GetLife() > 0;
		}

		public int GetLife()
		{
			return LIFE.GetCount();
		}

		public int AddLife(int n)
		{
			int temp = LIFE.AddToCount(n);

			if(OnSetLife!=null)
				OnSetLife(temp);

			return temp;
		}

		public int GetDiamond()
		{
			return DIAMOND.GetCount();
		}

		public int AddDiamond(int n)
		{

			int temp = DIAMOND.AddToCount(n);

			if(OnSetDiamond!=null)
				OnSetDiamond(temp);

			return temp;
		}



		public int diamond
		{
			get
			{
				int l = PlayerPrefs.GetInt("DIAMOND",0);

				if(l <0)
				{
					l = 0;
					PlayerPrefs.SetInt("DIAMOND",l);
					PlayerPrefs.Save();

					if(OnSetDiamond!=null)
						OnSetDiamond(l);
				}

				return l;
			}

			set
			{
				PlayerPrefs.SetInt("DIAMOND",value);
				PlayerPrefs.Save();

				if(OnSetDiamond!=null)
					OnSetDiamond(value);
			}
		}

		private void Awake()
		{

			this.SCORE = new Score();
			this.LIFE = new Item(ItemType.LIFE,3);
			this.DIAMOND = new Item(ItemType.DIAMOND,0);

			Application.targetFrameRate = 60;

			CreateListRectangle (50);

			CreateListParallax(50);

			InputTouch.OnTouchScreen += OnTouchScreen;

			DoSpawnStart();
			//
			//		DoSpawnParallax();
		}


		void DoSpawnParallax()
		{
			for(int i = 0; i < 10; i++)
			{
				var p = GetParallaxSprite();
				float height = 2f * cam.orthographicSize;
				float width = height * cam.aspect;
				p.transform.localScale = Vector2.one * UnityEngine.Random.Range(0.3f,3f);
				if(p.transform.localScale.x <= 1f)
				{
					p.rend.sortingOrder = - ((int)(p.transform.localScale.x*10))/10;
					p.transform.position = new Vector3
						(
							cam.transform.position.x - width/2 + i * p.rend.bounds.size.x,
							cam.transform.position.y + height * UnityEngine.Random.Range(0f,0.5f) - i * UnityEngine.Random.Range(2f,4f),
							transform.position.z
						);
				}
				else
				{
					p.rend.sortingOrder = + ((int)(p.transform.localScale.x*10))/10;
					p.transform.position = new Vector3
						(
							cam.transform.position.x - width/2 + i * p.rend.bounds.size.x,
							cam.transform.position.y - height * UnityEngine.Random.Range(0f,0.5f) + i * UnityEngine.Random.Range(2f,4f),
							transform.position.z
						);
				}


				p.originalPosition = p.transform.position;
				p.gameObject.SetActive(true);

				if(!p.IsVisibleByCam())
				{
					p.gameObject.SetActive(false);
					return;
				}
			}
		}

		public void AddNewParallax()
		{
			var p = GetParallaxSprite();
			float height = 2f * cam.orthographicSize;
			float width = height * cam.aspect;
			p.transform.localScale = Vector2.one * UnityEngine.Random.Range(1f,5f);
			p.transform.position = new Vector3
				(
					playerManager.transform.position.x + UnityEngine.Random.Range(width/2f,width)+ p.transform.localScale.x * p.rend.bounds.size.x,
					playerManager.transform.position.y + height * UnityEngine.Random.Range(0f,0.5f) ,//+  UnityEngine.Random.Range(2f,4f),
					transform.position.z
				);

			p.gameObject.SetActive(true);
		}



		void OnEnable()
		{
			InputTouch.OnTouchScreen += OnTouchScreen;
		}

		void OnDisable()
		{
			InputTouch.OnTouchScreen -= OnTouchScreen;
		}

		void OnTouchScreen()
		{

			InputTouch.OnTouchScreen -= OnTouchScreen;
			OnStart();
		}


		IEnumerator Start()
		{
			Application.targetFrameRate = 60;
			GC.Collect ();

			yield return 0;
		}

		void CreateListRectangle(int i)
		{
			int count = 0;

			while (count < i) 
			{
				CreateRectangle ();
				count++;
			}
		}

		PlatformLogic CreateRectangle()
		{
			var ob = Instantiate (obstacleRectanglePrefab) as Transform;
			ob.SetParent (transform, false);
			ob.gameObject.SetActive (false);
			var pl = ob.GetComponent<PlatformLogic>();
			obstacleRectanglePrefabList.Add (pl);

			return pl;
		}

		PlatformLogic GetRectangle()
		{
			var l = obstacleRectanglePrefabList.Find (o => o.gameObject.activeInHierarchy == false);

			if (l == null) 
			{
				l = CreateRectangle ();
			}

			return l;
		}

		void CreateListParallax(int i)
		{
			int count = 0;

			while (count < i) 
			{
				CreateParallax ();
				count++;
			}
		}

		ParallaxSprite CreateParallax()
		{
			var ob = Instantiate (paralaxSpritePrefab) as Transform;
			ob.SetParent (transform, false);
			ob.gameObject.SetActive (false);
			var pl = ob.GetComponent<ParallaxSprite>();
			paralaxSpriteList.Add (pl);

			return pl;
		}

		ParallaxSprite GetParallaxSprite()
		{
			var l = paralaxSpriteList.Find (o => o.gameObject.activeInHierarchy == false);

			if (l == null) 
			{
				l = CreateParallax ();
			}

			return l;
		}

		public void GameOverStart()
		{
			if (OnGameOverStarted != null)
				OnGameOverStarted ();
		}

		public void GameOverEnd()
		{
			OnGameOverEnded ();

			if (OnGameOverEnded != null)
				SCORE.Save();



		}

		public void OnStart()
		{
			SCORE.SetPoint(0);

			if(OnGameStart != null)
				OnGameStart ();

			if(OnSetPoint != null)
				OnSetPoint(0);

			countSpawn = 0;
		}


		[NonSerialized] public float smallSpace = 3f;
		public Vector2 lastPos ;
		int countSpawn = 0;
		int diamondSpawnCount = 0;


		bool lastIsBig = false;

		int positionDisplayedBest = -1;
		int positionDisplayedLast = -1;

		public void DoSpawn()
		{
			lastPos += new Vector2(smallSpace, 2);

			int best = SCORE.GetBest();

			int last = SCORE.GetLast();

			bool displayBestOrLast = false;

			if(countSpawn == best || countSpawn == last)
				displayBestOrLast = true;


			if(displayBestOrLast || countSpawn < UnityEngine.Random.Range(5,15) || lastIsBig || UnityEngine.Random.Range(0,2) == 0)
			{
				lastIsBig = false;

				var ob = GetRectangle ();
				ob.position = lastPos;
				ob.gameObject.SetActive (true);


				if (displayBestOrLast) {

					string language = LanguageManager.Instance.GetSystemLanguageEnglishName ();
					if (LanguageManager.Instance.IsLanguageSupportedEnglishName (language)) {
						LanguageManager.Instance.ChangeLanguage (LanguageManager.Instance.GetDeviceCultureIfSupported ());
					} else {
						LanguageManager.Instance.ChangeLanguage ("en");
					}

					LanguageManager.Instance.ChangeLanguage ("ar");

					if (true /*LanguageManager.Instance.GetDeviceCultureIfSupported () != null && 
			LanguageManager.Instance.GetDeviceCultureIfSupported ().languageCode.Equals ("ar")*/) {
						ob.lastScore.GetComponent<TextMesh>().text ="  " +ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("lastScore")) +"  ";
						ob.bestScore.GetComponent<TextMesh>().text = "  " +ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("bestScore"))+"  ";

					} else {
						ob.lastScore.GetComponent<TextMesh>().text = "  " +LanguageManager.Instance.GetTextValue ("lastScore") +"  ";
						ob.bestScore.GetComponent<TextMesh>().text = "  " +LanguageManager.Instance.GetTextValue ("bestScore")+"  ";
					}

				}



				int diveuc = countSpawn % 30;

				if(diamondSpawnCount < diveuc)
				{
					if(UnityEngine.Random.Range(0,5) == 0)
					{
						ob.ActivateDiamond();
					}
				}

				if(countSpawn == best && positionDisplayedBest == -1)
				{
					ob.bestScore.SetActive(true);
					positionDisplayedBest = countSpawn;
				}
				else
				{
					ob.bestScore.SetActive(false);
				}

				if(countSpawn == last && last != best && positionDisplayedLast == -1)
				{
					Debug.Log (ob.lastScore.GetComponent<TextMesh> ().text);
					ob.lastScore.SetActive(true);
					positionDisplayedLast = countSpawn;
				}
				else
				{
					ob.lastScore.SetActive(false);
				}
			}
			else
			{
				if(lastIsBig)
					Debug.LogError("ERROR !!");

				lastIsBig = true;
			}

			countSpawn++;

			if(GetCount() < 50)
				DoSpawn();

		}

		void DoSpawnStart()
		{
			while(countSpawn < 50)
			{
				DoSpawn();
			}
		}

		int GetCount()
		{
			int count = 0;

			count += obstacleRectanglePrefabList.FindAll (o => o.gameObject.activeInHierarchy == true).Count;



			return count;
		}

		void OnApplicationQuit()
		{
			PlayerPrefs.Save();
		}

		public void Pause() 
		{
			SoundManager a = FindObjectOfType<SoundManager>();
			if(a != null) 
			{
				a.MuteAllMusic();
			}

			Time.timeScale = 0;
		}

		public void Resume()
		{
			SoundManager a = FindObjectOfType<SoundManager>();
			if(a != null) 
			{
				a.UnmuteAllMusic();
			}

			Time.timeScale = 1;
			GC.Collect();
			Application.targetFrameRate = 60;
		}
	}
}