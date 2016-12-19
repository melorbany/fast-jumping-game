
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/


#pragma warning disable 0162 // code unreached.
#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
#pragma warning disable 0618 // obslolete
#pragma warning disable 0108 
#pragma warning disable 0649 //never used

using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System;


namespace AppAdvisory.Ads
{
	[CustomEditor(typeof(ADIDS))]
	public class SDInspectorGUI : Editor
	{
		void SetScriptingSymbols(string symbol, bool isActivate)
		{
			SetScriptingSymbol(symbol, BuildTargetGroup.Android, isActivate);

			#if UNITY_5 || UNITY_5_1 || UNITY_5_2 || UNITY_5_3_OR_NEWER
			SetScriptingSymbol(symbol, BuildTargetGroup.iOS, isActivate);
			#else
			SetScriptingSymbol(symbol, BuildTargetGroup.iPhone, isActivate);
			#endif 
		}

		void SetScriptingSymbol(string symbol, BuildTargetGroup target, bool isActivate)
		{

//			Debug.Log("SetScriptingSymbol : " + symbol + " - " + target.ToString() + " - activate = " + isActivate);
//			if(target == BuildTargetGroup.Unknown)
//				return;

		

//			var type = target.GetType();
//			var memInfo = type.GetMember(target.ToString());
//			var attributes = memInfo[0].GetCustomAttributes(typeof(BuildTargetGroup), false);
//			bool continueBTG = attributes.Length > 0;
//
//			if(!continueBTG)
//				return;

			var s = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);

			if(isActivate && (s.Contains(symbol) || s.Contains(symbol + ";")))
				return;
//			
			s = s.Replace(symbol + ";","");
			
			s = s.Replace(symbol,"");
			
			if(isActivate)
				s = symbol + ";" + s;
			
			PlayerSettings.SetScriptingDefineSymbolsForGroup(target,s);
		}

		string dString
		{
			get
			{
				return PlayerSettings.companyName + "_" + PlayerSettings.productName + "_";
			}
		}

		public bool DEBUG
		{
			get
			{
				
				bool _bool = t.DEBUG;

				return _bool;
			}

			set
			{

				bool _bool = t.DEBUG;

				if(_bool == value)
					return;

				t.DEBUG = value;

				SetScriptingSymbols("AADEBUG", value);
			}
		}

		public bool ANDROID_AMAZON
		{
			get
			{
				bool _bool = t.ANDROID_AMAZON;

				return _bool;
			}

			set
			{
				bool _bool = t.ANDROID_AMAZON;

				if(_bool == value)
					return;

				t.ANDROID_AMAZON = value;
				
				SetScriptingSymbols("ANDROID_AMAZON", value);
			}
		}

		public bool EnableChartboost
		{
			get
			{
				bool _bool = t.EnableChartboost;

				return _bool;
			}

			set
			{

				bool _bool = t.EnableChartboost;

				if(_bool == value)
					return;

				t.EnableChartboost = value;

				SetScriptingSymbols("CHARTBOOST", value);
			}
		}

		public bool EnableAdmob
		{
			get
			{
				bool _bool = t.EnableAdmob;

				return _bool;
			}

			set
			{
				bool _bool = t.EnableAdmob;
		
				if(_bool == value)
					return;

				t.EnableAdmob = value;
				
				SetScriptingSymbols("ENABLE_ADMOB", value);
			}
		}

		public bool EnableAdcolony
		{
			get
			{
				bool _bool = t.EnableAdcolony;

				return _bool;
			}

			set
			{
				bool _bool = t.EnableAdcolony;

				if(_bool == value)
					return;

				t.EnableAdcolony = value;

				SetScriptingSymbols("ENABLE_ADCOLONY", value);
			}
		}

		ADIDS t;



//		void OnEnable()
//		{
//			Debug.Log("Opening Very Simpmle Ads Editor...");
////
////			foreach(BuildTargetGroup foo in Enum.GetValues(typeof(BuildTargetGroup)))
////			{
////				SetScriptingSymbol("APPADVISORY_ADS", foo, true);
////			}
//
//			SetSymbolsForTarget (BuildTargetGroup.Android, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.iOS, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.WSA, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.Nintendo3DS, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.PS3, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.PS4, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.PSM, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.PSP2, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.SamsungTV, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.Standalone, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.Tizen, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.tvOS, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.WebGL, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.WiiU, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.XBOX360, "APPADVISORY_ADS");
//			SetSymbolsForTarget (BuildTargetGroup.XboxOne, "APPADVISORY_ADS");
//		}
//
//		void SetSymbolsForTarget(BuildTargetGroup target, string scriptingSymbol)
//		{
//			var s = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);
//
//			if(!s.Contains(scriptingSymbol))
//			{
//				PlayerSettings.SetScriptingDefineSymbolsForGroup (target, scriptingSymbol);
//
//			}
//		}

		public override void OnInspectorGUI()
		{
			t  = (ADIDS)target;

			if(t.FIRST_TIME)
			{
				Debug.Log("*********** APP_ADVISORY_FIRST_TIME_ADD *********");
				t.FIRST_TIME = false;

				DEBUG = false;

				t.IsADColonySettingsOpened = false;
				t.IsAdmobAMAZONSettingsOpened = false;
				t.IsAdmobANDROIDSettingsOpened = false;
				t.IsAdmobIOSSettingsOpened = false;
				t.IsAdmobSettingsOpened = false;
				t.IsChartboostSettingsOpened = false;
				t.IsUnityAdsSettingsOpened = false;
			}

			var stringIos = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS);
			var stringAndroid = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android);

			if(!stringIos.Contains("APPADVISORY_ADS"))
			{
				stringIos = "APPADVISORY_ADS" + ";" + stringIos;

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.iOS,stringIos);
			}

			if(!stringAndroid.Contains("APPADVISORY_ADS"))
			{
				stringAndroid = "APPADVISORY_ADS" + ";" + stringAndroid;

				PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);
			}

			PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Android,stringAndroid);
	
			#if !UNITY_IOS && !UNITY_ANDROID
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			GUILayout.TextField("PLEASE SWITCH PLATFORM TO iOS OR ANDROID IN THE BUILD SETTINGS");
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			return;
			#endif

			EditorGUILayout.BeginHorizontal();
			if(GUILayout.Button("GET\nADMOB\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
			{
				Application.OpenURL("https://github.com/googleads/googleads-mobile-unity");
			}

			if(GUILayout.Button("GET\nCHARTBOOST\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
			{
				Application.OpenURL("https://answers.chartboost.com/hc/en-us/articles/201219745-Unity-SDK-Download");
			}

			if(GUILayout.Button("GET\nADCOLONY\nSDK",  GUILayout.Width(100), GUILayout.Height(50)))
			{
				Application.OpenURL("https://github.com/AdColony");
			}

			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			DEBUG = EditorGUILayout.BeginToggleGroup(new GUIContent("DEBUG   [?]", "Activate if you want to debug rewarded ads"), DEBUG);
			EditorGUILayout.EndToggleGroup();

			#if AADEBUG
			EditorGUILayout.LabelField("");
			t.rewardedVideoAlwaysReadyInSimulator = EditorGUILayout.BeginToggleGroup(new GUIContent("Rewarded Video Always READY In Simulator    [?]", "Rewarded Video Always READY In Simulators"), t.rewardedVideoAlwaysReadyInSimulator);
			EditorGUILayout.EndToggleGroup();

			EditorGUILayout.LabelField("");
			t.rewardedVideoAlwaysSuccessInSimulator = EditorGUILayout.BeginToggleGroup(new GUIContent("Rewarded Video Always SUCCESS In Simulator    [?]", "Rewarded Video Always SUCCESS In Simulators"), t.rewardedVideoAlwaysSuccessInSimulator);
			EditorGUILayout.EndToggleGroup();
			#endif

			t.LoadNextSceneWhenAdLoaded = EditorGUILayout.BeginToggleGroup(new GUIContent("Load Next Scene When Ad(s) Ready    [?]", "Check it if you want to use a loading scene and launch the game scene when ads are ready"), t.LoadNextSceneWhenAdLoaded);
			EditorGUILayout.EndToggleGroup();

			t.RandomizeNetworks = EditorGUILayout.BeginToggleGroup(new GUIContent("Randomize Networks    [?]", "Check it if you want to randomize the order of the networks"), t.RandomizeNetworks);
			EditorGUILayout.EndToggleGroup();

			EnableChartboost = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Chartboost    [?]", "Check it to use Chartboost. Download the Chartboost SDK here: https://answers.chartboost.com/hc/en-us/"), EnableChartboost);
			EditorGUILayout.EndToggleGroup();

			EnableAdcolony = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Adcolony    [?]", "Check it to use ADColony. Download the Adcolony SDK here: https://github.com/AdColony"), EnableAdcolony);
			EditorGUILayout.EndToggleGroup();

			EnableAdmob = EditorGUILayout.BeginToggleGroup(new GUIContent("Enable Admob    [?]", "Check it to use Admob (iAD will be disabled)"), EnableAdmob);
			EditorGUILayout.EndToggleGroup();

			EditorGUILayout.Space();
			EditorGUILayout.Space();

			#if ENABLE_ADMOB



			t.IsAdmobSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobSettingsOpened, "ADMOB");

			if(t.IsAdmobSettingsOpened)
			{
				t.IsAdmobIOSSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobIOSSettingsOpened, "     iOS ADMOB IDs");
				if(t.IsAdmobIOSSettingsOpened)
				{
					EditorGUILayout.LabelField(new GUIContent("Admob Banner Id iOS    [?]", "Please enter your Admob BANNER Id for iOS"));
					t.AdmobBannerIdIOS = EditorGUILayout.TextArea(t.AdmobBannerIdIOS);
					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id iOS    [?]", "Please enter your Admob INTERSTITIAL Id for iOS"));
					t.AdmobInterstitialIdIOS = EditorGUILayout.TextArea(t.AdmobInterstitialIdIOS);
					EditorGUILayout.LabelField(new GUIContent("Admob Rewarded Video Id iOS    [?]", "Please enter your Admob REWARDED VIDEO Id for iOS"));
					t.AdmobRewardedVideoIdIOS = EditorGUILayout.TextArea(t.AdmobRewardedVideoIdIOS);
				}
				t.IsAdmobANDROIDSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobANDROIDSettingsOpened, "     ANDROID ADMOB IDs");
				if(t.IsAdmobANDROIDSettingsOpened)
				{
					EditorGUILayout.LabelField(new GUIContent("Admob Banner Id Android    [?]", "Please enter your Admob BANNER Id for ANDROID"));
					t.AdmobBannerIdANDROID = EditorGUILayout.TextArea(t.AdmobBannerIdANDROID);
					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Android    [?]", "Please enter your Admob INTERSTITIAL Id for ANDROID"));
					t.AdmobInterstitialIdANDROID = EditorGUILayout.TextArea(t.AdmobInterstitialIdANDROID);
					EditorGUILayout.LabelField(new GUIContent("Admob Rewarded Video Id Android    [?]", "Please enter your Admob REWARDED VIDEO Id for Android"));
					t.AdmobRewardedVideoIdANDROID = EditorGUILayout.TextArea(t.AdmobRewardedVideoIdANDROID);
				}
				t.IsAdmobAMAZONSettingsOpened = EditorGUILayout.Foldout(t.IsAdmobAMAZONSettingsOpened, "     ANDROID AMAZON IDs");
				if(t.IsAdmobAMAZONSettingsOpened)
				{
					EditorGUILayout.LabelField(new GUIContent("Admob Banner Id Amazon    [?]", "Please enter your Admob BANNER Id for AMAZON - Could be the same as Android"));
					t.AdmobBannerIdAMAZON = EditorGUILayout.TextArea(t.AdmobBannerIdAMAZON);
					EditorGUILayout.LabelField(new GUIContent("Admob Interstitial Id Amazon    [?]", "Please enter your Admob INTERSTITIAL Id for AMAZON - Could be the same as Android"));
					t.AdmobInterstitialIdAMAZON = EditorGUILayout.TextArea(t.AdmobInterstitialIdAMAZON);
					EditorGUILayout.LabelField(new GUIContent("Admob Rewarded Video Id Amazon    [?]", "Please enter your Admob REWARDED VIDEO Id for Amazon"));
					t.AdmobRewardedVideoIdAMAZON = EditorGUILayout.TextArea(t.AdmobRewardedVideoIdAMAZON);
				}
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();


			#endif


			#if UNITY_ADS

			t.IsUnityAdsSettingsOpened = EditorGUILayout.Foldout(t.IsUnityAdsSettingsOpened, "UNITY ADS");

			if(t.IsUnityAdsSettingsOpened)
			{
				EditorGUILayout.LabelField(new GUIContent("Rewarded video zonèe unity ads    [?]", "If you don't know what it is, have a look to the Unity Ads documentation: https://unityads.unity3d.com"));
				t.rewardedVideoZoneUnityAds = EditorGUILayout.TextField(t.rewardedVideoZoneUnityAds);
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			#endif





			#if CHARTBOOST

			t.IsChartboostSettingsOpened = EditorGUILayout.Foldout(t.IsChartboostSettingsOpened, "Chartboost");

			if(t.IsChartboostSettingsOpened)
			{
				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent("Chartboost App ID iOS  [?]", "Find it on Chartboost.com"));
				EditorGUILayout.LabelField(new GUIContent("Chartboost App Signature iOS   [?]", "Find it on Chartboost.com"));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				t.ChartboostAppIdIOS = EditorGUILayout.TextField(t.ChartboostAppIdIOS);
				t.ChartboostAppSignatureIOS = EditorGUILayout.TextField(t.ChartboostAppSignatureIOS);
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.Space();
				EditorGUILayout.Space();

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent("Chartboost App ID Android  [?]", "Find it on Chartboost.com"));
				EditorGUILayout.LabelField(new GUIContent("Chartboost App Signature Android   [?]", "Find it on Chartboost.com"));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				t.ChartboostAppIdAndroid = EditorGUILayout.TextField(t.ChartboostAppIdAndroid);
				t.ChartboostAppSignatureAndroid = EditorGUILayout.TextField(t.ChartboostAppSignatureAndroid);
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.Space();
				EditorGUILayout.Space();

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField(new GUIContent("Chartboost App ID Amazon  [?]", "Find it on Chartboost.com"));
				EditorGUILayout.LabelField(new GUIContent("Chartboost App Signature Amazon   [?]", "Find it on Chartboost.com"));
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.BeginHorizontal();
				t.ChartboostAppIdAmazon = EditorGUILayout.TextField(t.ChartboostAppIdAmazon);
				t.ChartboostAppSignatureAmazon = EditorGUILayout.TextField(t.ChartboostAppSignatureAmazon);
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.Space();
				EditorGUILayout.Space();
			}
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			#endif





			#if ENABLE_ADCOLONY
			t.IsADColonySettingsOpened = EditorGUILayout.Foldout(t.IsADColonySettingsOpened, "ADCOLONY");

			if(t.IsADColonySettingsOpened)
			{

			#if ENABLE_ADCOLONY
		
			EditorGUILayout.LabelField(new GUIContent("ADColony App ID iOS    [?]", "Please enter your ADColony App ID for iOS"));
			t.AdColonyAppID_iOS = EditorGUILayout.TextField(t.AdColonyAppID_iOS);
			
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			
			
			EditorGUILayout.LabelField(new GUIContent("ADColony App ID ANDROID    [?]", "Please enter your ADColony App ID for ANDROID"));
			t.AdColonyAppID_ANDROID = EditorGUILayout.TextField(t.AdColonyAppID_ANDROID);
			
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone Key iOS   [?]", "ADColony Interstitial Video Zone Key iOS"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone ID iOS   [?]", "ADColony Interstitial Video Zone ID iOS"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			t.AdColonyInterstitialVideoZoneKEY_iOS = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneKEY_iOS);
			t.AdColonyInterstitialVideoZoneID_iOS = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneID_iOS);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone Key Android   [?]", "ADColony Interstitial Video Zone Key Android"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Interstitial Video Zone ID Android   [?]", "ADColony Interstitial Video Zone OD Android"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			t.AdColonyInterstitialVideoZoneKEY_ANDROID = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneKEY_ANDROID);
			t.AdColonyInterstitialVideoZoneID_ANDROID = EditorGUILayout.TextField(t.AdColonyInterstitialVideoZoneID_ANDROID);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			
			
			
			
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone Key iOS   [?]", "ADColony Rewarded Video Zone Key iOS"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone ID iOS   [?]", "ADColony Rewarded Video Zone ID iOS"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			t.AdColonyRewardedVideoZoneKEY_iOS = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneKEY_iOS);
			t.AdColonyRewardedVideoZoneID_iOS = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneID_iOS);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			
			
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone Key Android   [?]", "ADColony Rewarded Video Zone Key Android"));
			EditorGUILayout.LabelField(new GUIContent("ADColony Rewarded Video Zone ID Android   [?]", "ADColony Rewarded Video Zone OD Android"));
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.BeginHorizontal();
			t.AdColonyRewardedVideoZoneKEY_ANDROID = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneKEY_ANDROID);
			t.AdColonyRewardedVideoZoneID_ANDROID = EditorGUILayout.TextField(t.AdColonyRewardedVideoZoneID_ANDROID);
			EditorGUILayout.EndHorizontal();
			EditorGUILayout.Space();
			EditorGUILayout.Space();
			

			#endif
				
			}


			#endif


			#if ENABLE_ADMOB || CHARTBOOST || IAD || ADCOLONY_INTERSTITIAL

			EditorGUILayout.Space();
			EditorGUILayout.Space();


			EditorGUILayout.Space();
			t.ShowIntertitialAtStart = EditorGUILayout.BeginToggleGroup(new GUIContent("Show interstitial at start  [?]", "Check it if you want to display interstitals ads at launch"), t.ShowIntertitialAtStart);
			EditorGUILayout.EndToggleGroup();

			EditorGUILayout.Space();
			EditorGUILayout.Space();
			EditorGUILayout.Space();

			ANDROID_AMAZON = EditorGUILayout.BeginToggleGroup(new GUIContent("AMAZON PLATFORM  [?]", "Check it if you build your game for the Amazon App Shop"), ANDROID_AMAZON);
			EditorGUILayout.EndToggleGroup();

			#endif

			if (GUI.changed)
			{
				EditorUtility.SetDirty(t); 
				
			}
		}
	}
}