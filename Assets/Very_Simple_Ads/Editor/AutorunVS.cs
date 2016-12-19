#pragma warning disable 0162 // code unreached.
#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.
#pragma warning disable 0618 // obslolete
#pragma warning disable 0108 
#pragma warning disable 0649 //never used
#pragma warning disable 0429 //never used

/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System;
// from the excellent http://answers.unity3d.com/questions/45186/can-i-auto-run-a-script-when-editor-launches-or-a.html

///
/// This must be added to "Editor" folder: http://unity3d.com/support/documentation/ScriptReference/index.Script_compilation_28Advanced29.html
/// Execute some code exactly once, whenever the project is opened, recompiled, or run.
///

namespace AppAdvisory.Ads
{
	[InitializeOnLoad]
	public class AutorunVS
	{
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		private const string VS_SCRIPTING_SYMBOL_TO_ADD_AT_START = "APPADVISORY_ADS";
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/
		/******* TO MODIFY **********/

		static void SetScriptingDefineSymbols () 
		{
			//			if (Directory.Exists ("Assets/Demigiant"))
			//			{
			SetSymbolsForTarget (BuildTargetGroup.Android, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
			SetSymbolsForTarget (BuildTargetGroup.iOS, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START); 
//			SetSymbolsForTarget (BuildTargetGroup.WSA, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			#if !UNITY_5_5_OR_NEWER
//			SetSymbolsForTarget (BuildTargetGroup.Nintendo3DS, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.PS3, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.XBOX360, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			#endif
//			SetSymbolsForTarget (BuildTargetGroup.PS4, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.PSM, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.PSP2, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.SamsungTV, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START); 
//			SetSymbolsForTarget (BuildTargetGroup.Standalone, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.Tizen, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.tvOS, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.WebGL, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
//			SetSymbolsForTarget (BuildTargetGroup.WiiU, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START); 
//			SetSymbolsForTarget (BuildTargetGroup.XboxOne, VS_SCRIPTING_SYMBOL_TO_ADD_AT_START);
		}
		 
		static void SetSymbolsForTarget(BuildTargetGroup target, string scriptingSymbol)
		{

			if(target == BuildTargetGroup.Unknown)
				return;

			var s = PlayerSettings.GetScriptingDefineSymbolsForGroup(target);

			string sTemp = scriptingSymbol;

			if(!s.Contains(sTemp))
			{

				s = s.Replace(scriptingSymbol + ";","");

				s = s.Replace(scriptingSymbol,"");  

				s = scriptingSymbol + ";" + s;

				PlayerSettings.SetScriptingDefineSymbolsForGroup(target,s);
			}
		}

		static AutorunVS()
		{
			EditorApplication.update += RunOnce;
		}

		static void RunOnce() 
		{
			EditorApplication.update -= RunOnce;

			SetScriptingDefineSymbols ();

			int count = EditorPrefs.GetInt(WelcomeVerySimpleAds.PREFSHOWATSTARTUP + "autoshow",0);

			if(count == 30 || count == 100)
			{
				Application.OpenURL("http://u3d.as/oWD");
			}

			// do something here. You could open an EditorWindow, for example.
			WelcomeVerySimpleAds.showAtStartup = EditorPrefs.GetInt(WelcomeVerySimpleAds.PREFSHOWATSTARTUP, 1) == 1;

			if (EditorPrefs.GetInt(WelcomeVerySimpleAds.PREFSHOWATSTARTUP, 1) == 1)
				WelcomeVerySimpleAds.OpenPopupStartup();
		}
	}
}