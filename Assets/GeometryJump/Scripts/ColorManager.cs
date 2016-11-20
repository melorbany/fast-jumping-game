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
/// Class in charge to manage the background colors
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class ColorManager : MonoBehaviorHelper 
	{
		public Color[] colors;

		public float timeChangeColor = 10;

		bool isGameOver = false;

		void Awake()
		{
			Color c = PlayerPrefsX.GetColor("BACKGROUND_COLOR", colors[0]);
			cam.backgroundColor = c;
		}

		void OnEnable()
		{
			GameManager.OnGameStart += OnGameStart;

			GameManager.OnGameOverStarted += OnGameOverStarted;

			Color c = PlayerPrefsX.GetColor("BACKGROUND_COLOR", colors[0]);
			cam.backgroundColor = c;
		}

		void OnDisable()
		{
			GameManager.OnGameStart -= OnGameStart;

			GameManager.OnGameOverStarted -= OnGameOverStarted;

		}

		void OnGameStart()
		{
			isGameOver = false;
			ChangeColor();
		}

		void OnGameOverStarted()
		{
			isGameOver = true;
		}

		void ChangeColor(){


			Color colorTemp = colors [UnityEngine.Random.Range (0, colors.Length)];

			cam.DOColor(colorTemp,3f).SetEase(Ease.Linear)
				.SetDelay(timeChangeColor)
				.OnComplete(() => {
					PlayerPrefsX.SetColor("BACKGROUND_COLOR", cam.backgroundColor);

					if(!isGameOver)
					{
						ChangeColor();
					}
				});

		}

		void OnApplicationQuit()
		{
			PlayerPrefs.Save();
		}
	}
}