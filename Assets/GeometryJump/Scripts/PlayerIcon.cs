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
using DG.Tweening;

/// <summary>
/// Class in charge to manage the mask icons in the character shop
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class PlayerIcon : MonoBehaviorHelper
	{
		public Text[] texts;
		public Image[] images;

		public Button button;
		public Text buttonText;

		string id = null;

		public int price;

		public Image spriteMask;

		[SerializeField] private Diamond DIAMOND;


		void Awake()
		{
			
			button = GetComponentInChildren<Button>();
			buttonText = button.transform.GetComponentInChildren<Text>();

			Logic();
		}

		void OnEnable()
		{
			Logic();
		}

		void OnDisable()
		{
			button.onClick.RemoveAllListeners();
		}

		void Logic()
		{
			foreach(var t in texts)
			{
				var c = t.color;

				c.a = alpha;

				t.color = c;
			}

			foreach(var t in images)
			{
				var c = t.color;

				c.a = alpha;

				t.color = c;
			}

			buttonText.text = text;

			button.onClick.AddListener(() => {

				this.DIAMOND = new Diamond();

				Debug.Log (this.DIAMOND.GetDiamond() + " " + this.DIAMOND.GetPurchase() );

				if(IsUnlock)
				{
//					this.DIAMOND.SetDiamond(10000);
//					this.DIAMOND.Save();

					ChangePlayerMask();
				}
				else
				{


					//Debug.Log("unlock");
					if(price <= this.DIAMOND.GetDiamond())
					{
						this.DIAMOND.AddDiamond(-price);
						this.DIAMOND.AddPurchase(1);
						this.DIAMOND.Save();

						IsUnlock = true;
						Logic();
						ChangePlayerMask();
					}
					else
					{
						transform.DOShakePosition(1,10,10,90);
					}
				}
			});
		}


		void ChangePlayerMask()
		{
			Transform t = transform.FindChild("Image");
			if(t == null)
			{
				playerManager.SetMask(null);
				return;
			}
			Image i = t.GetComponent<Image>();
			Debug.Log (i);
			Sprite s = i.sprite;
			Debug.Log (s);

			//playerManager.SetMask(s);
		}

		float alpha
		{
			get
			{
				float a = IsUnlock ? 1f : 0.5f;
				return a;
			}
		}

		string text
		{
			get
			{
				string s = IsUnlock ? "SELECT" : ("UNLOCK");

				return s;
			}
		}


		bool IsUnlock
		{
			get
			{
				if(id == null)
					id = gameObject.name;

				if(price == 0)
				{
					PlayerPrefs.SetInt(id,1);
					PlayerPrefs.Save();
				}

				bool isUnlock = PlayerPrefs.GetInt(id,0) == 1;

				return isUnlock;
			}

			set
			{
				if(value == true)
				{
					PlayerPrefs.SetInt(id,1);
					PlayerPrefs.Save();
				}
				else
				{
					PlayerPrefs.SetInt(id,0);
					PlayerPrefs.Save();
				}
			}
		}
	}
}