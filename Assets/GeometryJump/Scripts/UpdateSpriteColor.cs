/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace AppAdvisory.GeometryJump
{
	public class UpdateSpriteColor : MonoBehaviorHelper {


		public SpriteRenderer image;



		IEnumerator Start()
		{
			while (true) {
				Color32 c = cam.backgroundColor;

				image.color = new Color32(c.r,c.g,c.b,c.a);

				yield return 0;
			}
		}
	}
}