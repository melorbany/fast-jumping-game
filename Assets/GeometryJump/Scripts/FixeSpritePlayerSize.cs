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
/// Class in charge to fix the player size in the game
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class FixeSpritePlayerSize : MonoBehaviour 
	{
		public SpriteRenderer sprite;
		public SpriteRenderer shadow;

		#if UNITY_EDITOR
		void OnDrawGizmos()
		{
			FixSize();
		}
		#endif

		void FixSize()
		{
			if(sprite == null || shadow == null)
				return;

			var sizeSprite = sprite.sprite.bounds.size;

			print("size = " + sizeSprite);

			sprite.transform.localScale = Vector2.one * 1f / sizeSprite.x;

			shadow.transform.localScale = Vector2.one * 1f / sizeSprite.x;
		}
	}
}