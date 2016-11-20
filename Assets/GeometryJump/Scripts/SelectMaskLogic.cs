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
using System.Collections.Generic;
using DG.Tweening;

/// <summary>
/// Class in charge of the logic behind the selection of a new mask in the character shop
/// </summary>
namespace AppAdvisory.GeometryJump
{
	public class SelectMaskLogic : MonoBehaviour 
	{
		public Button buttonNext;
		public Button buttonPrevious;

		public RectTransform MaskListParent;

		public List<RectTransform> listMask = new List<RectTransform>();

		public Vector2 scaleNextAndPrevious = Vector2.one*0.5f;

		public float posPreviousNext = 176;

		public int position = 0;

		public RectTransform previousPrevious;
		public RectTransform previous;
		public RectTransform current;
		public RectTransform next;
		public RectTransform nextNext;

		void Awake()
		{
			for(int i = 0 ; i < MaskListParent.childCount; i++)
			{
				var m = MaskListParent.GetChild(i).GetComponent<RectTransform>();
				listMask.Add(m);
			}
			SetIcons();
			foreach(var r in listMask)
			{
				r.gameObject.SetActive(false);
				r.localScale = Vector2.zero;
			}
		}

		void Start()
		{
			SetPreviousPrevious();
			SetPrevious();
			SetCurrent();
			SetNext();
			SetNextNext();
			previousPrevious.anchoredPosition = new Vector2(-2*posPreviousNext,current.anchoredPosition.y);
			previous.anchoredPosition = new Vector2(-posPreviousNext,current.anchoredPosition.y);
			current.anchoredPosition = new Vector2(0,current.anchoredPosition.y);
			next.anchoredPosition = new Vector2(posPreviousNext,current.anchoredPosition.y);
			nextNext.anchoredPosition = new Vector2(2*posPreviousNext,current.anchoredPosition.y);

			previousPrevious.localScale = Vector2.zero;
			previous.localScale = scaleNextAndPrevious;
			current.localScale = Vector2.one;
			next.localScale = scaleNextAndPrevious;
			nextNext.localScale = Vector2.zero;

		}

		void OnEnable()
		{
			buttonNext.onClick.AddListener(OnClickedNext);
			buttonPrevious.onClick.AddListener(OnClickedPrevious);
		}

		void OnDisable()
		{
			buttonNext.onClick.RemoveAllListeners();
			buttonPrevious.onClick.RemoveAllListeners();
		}


		void SetIcons()
		{


			foreach(var r in listMask)
			{
				r.gameObject.SetActive(false);
			}

			SetPreviousPrevious();
			SetPrevious();
			SetCurrent();
			SetNext();
			SetNextNext();

			foreach(var r in listMask)
			{
				if(r != previousPrevious && r != previous && r != current && r != next && r != nextNext ) 
					r.gameObject.SetActive(false);
			}
		}
		void SetPreviousPrevious()
		{
			var r = GetPosition(position - 2);

			previousPrevious = r;
			previousPrevious.gameObject.SetActive(true);
		}

		void SetPrevious()
		{
			var r = GetPosition(position - 1);


			previous = r;
			previous.gameObject.SetActive(true);
		}

		void SetCurrent()
		{
			var r = GetPosition(position);

			current = r;
			current.gameObject.SetActive(true);
		}

		void SetNext()
		{
			var r = GetPosition(position + 1);

			next = r;
			next.gameObject.SetActive(true);
		}

		void SetNextNext()
		{
			var r = GetPosition(position + 2);

			nextNext = r;
			nextNext.gameObject.SetActive(true);
		}


		RectTransform GetPosition(int p)
		{
			if(p < 0)
				p = p + (1 - p/listMask.Count) * listMask.Count;

			if(p >= listMask.Count)
				p = p - (p/listMask.Count) * listMask.Count;

			return listMask[p];
		}

		public void OnClickedNext()
		{

			DesactiveButton();

			Invoke("ReactiveButton",0.2f);

			DoScale(previousPrevious, 0, scaleNextAndPrevious.x);
			DoPosition(previousPrevious ,-2*posPreviousNext, -posPreviousNext);

			DoScale(previous, scaleNextAndPrevious.x, 1f);
			DoPosition(previous ,-posPreviousNext, 0);


			DoScale(current, 1f, scaleNextAndPrevious.x);
			DoPosition(current, 0, posPreviousNext);


			DoScale(next,scaleNextAndPrevious.x, 0);
			DoPosition(next, posPreviousNext, 2*posPreviousNext);

			position --;

			SetPreviousPrevious();
			SetPrevious();
			SetCurrent();
			SetNext();
			SetNextNext();

		} 

		public void OnClickedPrevious()
		{

			DesactiveButton();

			Invoke("ReactiveButton",0.2f);

			DoScale(previous, scaleNextAndPrevious.x, 0);
			DoPosition(previous ,-posPreviousNext, -2*posPreviousNext);

			DoScale(current, 1f, scaleNextAndPrevious.x);
			DoPosition(current, 0, -posPreviousNext);


			DoScale(next,scaleNextAndPrevious.x, 1);
			DoPosition(next, posPreviousNext, 0);

			DoScale(nextNext, 0f, scaleNextAndPrevious.x);
			DoPosition(nextNext ,+2*posPreviousNext, posPreviousNext);

			position ++;

			SetPreviousPrevious();
			SetPrevious();
			SetCurrent();
			SetNext();
			SetNextNext();
		}

		void DesactiveButton()
		{
			buttonNext.enabled = false;
			buttonPrevious.enabled = false;
		}

		void ReactiveButton()
		{
			buttonNext.enabled = true;
			buttonPrevious.enabled = true;
		}

		void DoScale(RectTransform r, float fromS, float toS)
		{
			DoScale(r,fromS,toS,0.3f);
		}

		void DoScale(RectTransform r, float fromS, float toS, float duration)
		{
			r.localScale = Vector2.one * fromS;

			r.DOScale(toS, duration);
		}

		void DoPosition(RectTransform r, float fromS, float toS)
		{
			DoPosition(r,fromS,toS,0.3f);
		}

		void DoPosition(RectTransform r, float fromS, float toS, float duration)
		{
			r.anchoredPosition = new Vector2(fromS, r.anchoredPosition.y);

			r.DOAnchorPosX(toS, duration);
		}
	}
}