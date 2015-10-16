using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class TapToStart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		
		public void OnPointerDown(PointerEventData data)
		{
		}
		
		
		public void OnPointerUp(PointerEventData data)
		{
			Application.LoadLevel ("OnTriggerTester");
		}
	}
}