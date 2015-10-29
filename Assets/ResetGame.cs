using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class ResetGame : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
		public byte Version = 1;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
		
		}
		public void OnPointerDown(PointerEventData data)
		{

		}
		
		
		public void OnPointerUp(PointerEventData data)
		{
			PhotonNetwork.player.SetScore (0);
			Application.LoadLevel (0); 
		}
	}
}
