/***********************************************************************************************************
 * Produced by App Advisory - http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/




using UnityEngine;
using System.Collections;

namespace AppAdvisory.GeometryJump
{
	public class ResizeBackgroundSize : MonoBehaviour 
	{
		void Start()
		{
			SpriteRenderer sr = GetComponent<SpriteRenderer>();
			if (sr == null) return;

			transform.localScale = new Vector3(1,1,1);

			float width = sr.sprite.bounds.size.x;
			float height = sr.sprite.bounds.size.y;

			var worldScreenHeight = Camera.main.orthographicSize * 2.0f;
			var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

			transform.localScale = new Vector3(worldScreenWidth / width, worldScreenHeight / height, 1);
		}
	}
}