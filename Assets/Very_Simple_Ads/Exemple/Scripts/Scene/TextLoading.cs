
/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AppAdvisory.Ads
{
	public class TextLoading : MonoBehaviour 
	{
		Text text;

		void Awake()
		{
			this.text = GetComponent<Text>();
		}

		void Start()
		{
			StartCoroutine(ChangeText());
		}

		void OnDisable()
		{
			StopAllCoroutines();
		}

		IEnumerator ChangeText()
		{
			int count = 0;

			while(true)
			{
				if(count == 0)
				{
					this.text.text = "Loading.";
					count = 1;
				}
				else if(count == 1)
				{
					this.text.text = "Loading..";
					count = 2;
				}
				else if(count == 2)
				{
					this.text.text = "Loading...";
					count = 3;
				}
				else if(count == 3)
				{
					this.text.text = "Loading";
					count = 0;
				}

				yield return new WaitForSeconds(0.3f);
			}
		}
	}
}