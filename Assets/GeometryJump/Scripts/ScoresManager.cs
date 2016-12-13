using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoresManager : MonoBehaviour {


	[SerializeField] private CanvasGroup canvasGroupRegister;
	[SerializeField] private InputField inputFieldRegister;
	[SerializeField] private Button buttonRegister;

	// Use this for initialization
	void Start () {
	
		int isRegistered = PlayerPrefs.GetInt ("IS_REGISTERED", 0);
		canvasGroupRegister.gameObject.SetActive(isRegistered>0?false:true);

		buttonRegister.GetComponent<Button>().onClick.AddListener(() => { RegisterBtn(); });    //play



	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void RegisterBtn()
	{
		string name = inputFieldRegister.text;
		string userName = "";

		int best = PlayerPrefs.GetInt ("SCORE_BEST", 0);
		//Debug.Log (name);


		string platform = "EDITOR";
		#if UNITY_IPHONE
		platform = "IOS";
		#endif

		#if UNITY_ANDROID
		platform = "ANDROID";
		#endif


		if (name.Length > 1) {

			userName = Highscores.instance.FormatUserName (name,platform);
			Highscores.instance.AddNewHighscore (userName ,best );

			PlayerPrefs.SetInt ("IS_REGISTERED", 1);
			PlayerPrefs.SetString ("USER_NAME", userName);
			PlayerPrefs.Save ();

		}

		canvasGroupRegister.gameObject.SetActive(false);

	}


}
