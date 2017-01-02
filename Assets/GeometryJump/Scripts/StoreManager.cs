using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using SmartLocalization;
using ArabicSupport;

public class StoreManager : MonoBehaviour {


	[SerializeField] private Text diamondText;
	[SerializeField] private Text buttonBack;


	// Use this for initialization
	void Start () {
	
		int l = PlayerPrefs.GetInt("DIAMOND",0);

		Debug.Log (l);
		diamondText.text = "x " + l;


		string language = LanguageManager.Instance.GetSystemLanguageEnglishName ();
		if (LanguageManager.Instance.IsLanguageSupportedEnglishName (language)) {
			LanguageManager.Instance.ChangeLanguage (LanguageManager.Instance.GetDeviceCultureIfSupported ());
		} else {
			LanguageManager.Instance.ChangeLanguage ("en");
		}

		LanguageManager.Instance.ChangeLanguage ("ar");

		if (true /*LanguageManager.Instance.GetDeviceCultureIfSupported () != null && 
			LanguageManager.Instance.GetDeviceCultureIfSupported ().languageCode.Equals ("ar")*/) {

			buttonBack.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("back"));
	
		} else {
			
			buttonBack.text = LanguageManager.Instance.GetTextValue ("back");
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnClickedButtonPlay()
	{
		SceneManager.LoadScene("Main");
	}

}
