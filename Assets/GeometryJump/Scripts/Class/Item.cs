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
using UnityEngine.Events;

/// <summary>
/// Class who modelise the different itemps in the game
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class Item 
	{
		private int count;

		private ItemType itemType;

		public Item(ItemType itemType, int defaultSize)
		{
			this.itemType = itemType;
			this.count = PlayerPrefs.GetInt(this.itemType.ToString(),defaultSize);
		}

		public int GetCount()
		{
			return this.count;
		}

		public int SetCount(int c)
		{
			this.count = c;
			PlayerPrefs.SetInt(this.itemType.ToString(),this.count);
			return this.count;
		}

		public int AddToCount(int c)
		{
			this.count += c;
			PlayerPrefs.SetInt(this.itemType.ToString(),this.count);
			return this.count;
		}

		public ItemType GetItemType()
		{
			return this.itemType;
		}
	}
}