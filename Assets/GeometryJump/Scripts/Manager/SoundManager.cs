/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using System.Collections;

/// <summary>
/// Class in charge to manage the sound in the game
/// </summary>
using UnityEngine.UI;


namespace AppAdvisory.GeometryJump
{
	public class SoundManager : MonoBehaviorHelper
	{

		public AudioSource music;
		public AudioSource fx;

		public AudioClip musicGame;

		public AudioClip musicGameOver;
		public AudioClip jumpFX;
		public AudioClip coinFX;

		[SerializeField] public Button buttonSound;
		[SerializeField] public Sprite[] soundBtnSprites; //1 for off and 0 for on


		void OnEnable()
		{
			GameManager.OnSetDiamond += PlayCoinFX;
		}

		void OnDisable()
		{
			GameManager.OnSetDiamond -= PlayCoinFX;
		}

		void Start()
		{
			
			if ( PlayerPrefs.GetInt("MUTE_SOUND",0) == 0)
			{
				AudioListener.volume = 1;
				//MusicController.instance.PlayBgMusic();
				PlayMusicGame();
				buttonSound.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[1];

			}
			else
			{
				AudioListener.volume = 0;
				//MusicController.instance.StopBgMusic();
				MuteAllMusic();
				buttonSound.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[0];

			}

		}

		private void PlayMusicGame()
		{
			PlayMusic (musicGame);
		}

		public void PlayMusicGameOver()
		{
			playFX (musicGameOver);
		}

		public void PlayJumpFX()
		{
			playFX (jumpFX,0.5f);
		}

		private void PlayCoinFX(int p)
		{
			playFX (coinFX,1f);
		}

		private void PlayMusic(AudioClip a)
		{
			if (music != null && music.clip != null)
				music.Stop ();


			music.clip = a;
			music.Play ();
		}

		private void playFX(AudioClip a)
		{
			playFX(a,1);
		}

		private void playFX(AudioClip a, float volumeScale )
		{
			if (fx != null && fx.clip != null)
				fx.Stop ();

			fx.PlayOneShot (a, volumeScale);
		}


		public void MuteAllMusic()
		{
			music.Pause();
			fx.Pause();
		}

		public void UnmuteAllMusic()
		{
			music.Play();
			fx.Play();
		}
			

		public void SoundBtn()
		{

			//		PlayBtn();
			//        sound.Play();

			if (PlayerPrefs.GetInt("MUTE_SOUND",0) == 0)
			{
				Debug.Log ("sound mute");
				AudioListener.volume = 0;
				buttonSound.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[0];
				PlayerPrefs.SetInt ("MUTE_SOUND", 1);
				PlayerPrefs.Save ();
				MuteAllMusic ();
			}
			else
			{
				Debug.Log ("sound play");
				AudioListener.volume = 1;
				buttonSound.transform.GetChild(0).GetComponent<Image>().sprite = soundBtnSprites[1];
				PlayerPrefs.SetInt ("MUTE_SOUND", 0);
				PlayerPrefs.Save ();
				PlayMusicGame();

			}
		}
	}
}