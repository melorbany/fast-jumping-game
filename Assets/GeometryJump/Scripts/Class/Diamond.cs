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
/// Class to help us to manager the score in the game
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class Diamond 
	{
		private int count;
		private int video;
		private int purchase;

		public Diamond()
		{
			this.count = PlayerPrefs.GetInt("DIAMOND",0);
			this.video = PlayerPrefs.GetInt("DIAMOND_VIDEO",0);
			this.purchase = PlayerPrefs.GetInt("DIAMOND_PURCHASE",0);
		}

		//return current score
		public int AddDiamond(int p)
		{
			this.count += p;
			return this.count;
		}

		public int SetDiamond(int p)
		{
			this.count = p;
			return this.count;
		}

		public int AddVideo(int p)
		{
			this.video += p;
			return this.video;
		}

		public int AddPurchase(int p)
		{
			this.purchase += p;
			return this.purchase;
		}
			

		public int GetDiamond()
		{
			return this.count;
		}

		public int GetVideo()
		{
			return this.video;
		}

		public int GetPurchase()
		{
			return this.purchase;
		}



		//return true if best
		public bool Save()
		{
			PlayerPrefs.SetInt("DIAMOND",this.count);
			PlayerPrefs.SetInt("DIAMOND_VIDEO",this.video);
			PlayerPrefs.SetInt("DIAMOND_PURCHASE",this.purchase);
			return true;
		}


	}
}