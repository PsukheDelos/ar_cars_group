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
				if(_material!=null && _material.color.Equals(Color.white)){
					_material.color = Color.yellow;
				}
				else if (_material!=null){
					_material.color = Color.white;
				} else {
					_material = GetComponent<Text> ();
				}
				timer = 0;
			}
		}
		
		public void OnPointerDown(PointerEventData data)
		{
		}
		
		
		public void OnPointerUp(PointerEventData data)
		{
//			GameObject.FindGameObjectWithTag ("TapCanvas").gameObject.GetComponent<Renderer> ().enabled = false;
			GameObject.Find ("TapCanvas").gameObject.GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("JoinCanvas").gameObject.GetComponent<Canvas> ().enabled = true;

		}
	}
}