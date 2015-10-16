using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{


	public class TapToStart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{

		private Text _material ;
		private float timer = 0.0f;

		void OnEnable () {
			_material = GetComponent<Text> ();
			_material.color = Color.white;
		}

		public void Update(){
			timer += Time.deltaTime;
			if (timer >= 0.5f)//change the float value here to change how long it takes to switch.
			{
				if(_material.color==Color.white){
					_material.color = Color.yellow;
				}
				else{
					_material.color = Color.white;
				}
				timer = 0;
			}
		}
		
		public void OnPointerDown(PointerEventData data)
		{
		}
		
		
		public void OnPointerUp(PointerEventData data)
		{
			Application.LoadLevel ("OnTriggerTester");
		}
	}
}