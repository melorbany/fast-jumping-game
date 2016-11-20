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

/// <summary>
/// Class to managed transition animations
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class AnimationTransitionManager : MonoBehaviour 
	{
		public AnimationTransition animationTransition;

		void Awake()
		{
			animationTransition.gameObject.SetActive(true);
		}

		void Start()
		{
			animationTransition.gameObject.SetActive(true);
			animationTransition.DoAnimationOut(null);
		}

		public void DoAnimIn(Action callback)
		{
			animationTransition.gameObject.SetActive(true);
			animationTransition.DoAnimationIn(callback);
		}

	}
}