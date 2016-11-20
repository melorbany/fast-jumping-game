using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SmartLocalization;
using ArabicSupport;

public class GameUILocalization : MonoBehaviour {


	public Text score, best,last,shortJump,longJump,getLife,getDiamond;
	public Text continueLive,continueDiamond,restart;
	public GameObject lastScoreTriangle,bestScoreTriangle;


	// Use this for initialization
	void Start () {
		string language = LanguageManager.Instance.GetSystemLanguageEnglishName ();
		if (LanguageManager.Instance.IsLanguageSupportedEnglishName (language)) {
			LanguageManager.Instance.ChangeLanguage (LanguageManager.Instance.GetDeviceCultureIfSupported ());
		} else {
			LanguageManager.Instance.ChangeLanguage ("en");
		}

		LanguageManager.Instance.ChangeLanguage ("ar");

		if (true /*LanguageManager.Instance.GetDeviceCultureIfSupported () != null && 
			LanguageManager.Instance.GetDeviceCultureIfSupported ().languageCode.Equals ("ar")*/) {


			best.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("best"));
			last.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("last"));
			shortJump.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("shortJump"));
			longJump.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("longJump"));
			continueLive.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("continue"));
			continueDiamond.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("continue"));
			restart.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("restart"));
			lastScoreTriangle.GetComponent<TextMesh>().text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("lastScore"));
			bestScoreTriangle.GetComponent<TextMesh>().text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("bestScore"));
			getLife.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("get"));
			getDiamond.text = ArabicFixer.Fix (LanguageManager.Instance.GetTextValue ("get"));


		} else {
			
			best.text = LanguageManager.Instance.GetTextValue ("best");
			last.text = LanguageManager.Instance.GetTextValue ("last");
			shortJump.text = LanguageManager.Instance.GetTextValue ("shortJump");
			longJump.text = LanguageManager.Instance.GetTextValue ("longJump");
			continueLive.text = LanguageManager.Instance.GetTextValue ("continue");
			continueDiamond.text = LanguageManager.Instance.GetTextValue ("continue");
			restart.text = LanguageManager.Instance.GetTextValue ("restart");
			lastScoreTriangle.GetComponent<TextMesh>().text = LanguageManager.Instance.GetTextValue ("lastScore");
			bestScoreTriangle.GetComponent<TextMesh>().text = LanguageManager.Instance.GetTextValue ("bestScore");
			getLife.text = LanguageManager.Instance.GetTextValue ("get");
			getDiamond.text = LanguageManager.Instance.GetTextValue ("get");

		}


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
