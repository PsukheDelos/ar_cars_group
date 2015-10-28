using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{


	public class TapToStart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		void OnEnable () {

		}

		public void Update(){

		}
	
		public void OnPointerDown(PointerEventData data)
		{
		}
		
		
		public void OnPointerUp(PointerEventData data)
		{
			GameObject.Find ("TapCanvas").gameObject.GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("JoinCanvas").gameObject.GetComponent<Canvas> ().enabled = true;
		}
	}
}