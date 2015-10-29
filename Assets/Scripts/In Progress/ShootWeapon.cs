using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class ShootWeapon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
	    public GameObject tommybullet;
		public GameObject tommypoint;
	    public GameObject pistolbullet;
	    public WeaponType type;

		private float bulletLife = 3;

	    private bool fired;
		private bool firing;
	    private bool locked;
	    private bool switched;
	    private float cooldown;
	
		private int tommy_ammo = 10;

	    public enum WeaponType
	    {
	        PISTOL,
	        TOMMYGUN
		}

		public void FixedUpdate () {
			cooldown += Time.deltaTime;
			if (type == WeaponType.TOMMYGUN && cooldown > 0.1f && tommy_ammo > 0 && firing==true) {
				cooldown = 0;
				GameObject.Find(PhotonNetwork.playerName).GetPhotonView().RPC("fireMachineGun", PhotonTargets.All);
			}
		}

		void OnEnable()
		{

		}

		void OnDisable()
		{

		}
		
		
		public void OnPointerDown(PointerEventData data)
		{
			firing = true;
		}
		
		
		public void OnPointerUp(PointerEventData data)
		{
			firing = false;
		}


	}
}