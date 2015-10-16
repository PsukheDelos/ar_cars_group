using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.EventSystems;

namespace UnityStandardAssets.CrossPlatformInput
{
	public class ShootWeapon : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		// designed to work in a pair with another axis touch button
		// (typically with one having -1 and one having 1 axisValues)
		
	    public GameObject tommybullet;
		public GameObject tommypoint;
	    public GameObject pistolbullet;
	    public WeaponType type;

		private float bulletLife = 10;

	    private bool fired;
		private bool firing;
	    private bool locked;
	    private bool switched;
	    private float cooldown;
	
		private int tommy_ammo = 10;
//		private int pistol_ammo = 12;
	
	    public enum WeaponType
	    {
	        PISTOL,
	        TOMMYGUN
		}

		public void FixedUpdate () {
			cooldown += Time.deltaTime;
			//			tommypoint = GameObject.Find("Car");
			if (type == WeaponType.TOMMYGUN && cooldown > 0.1f && tommy_ammo > 0 && firing==true) {
				cooldown = 0;
//				tommypoint = GameObject.Find(PhotonNetwork.player.ID.ToString());
				tommypoint = GameObject.Find("Weapon");
				GameObject mybullet = GameObject.Instantiate (tommybullet, tommypoint.transform.position, tommypoint.transform.rotation) as GameObject;
				mybullet.GetComponent<Rigidbody> ().AddRelativeForce (0, 0, 1, ForceMode.Impulse);
				Physics.IgnoreCollision (tommypoint.GetComponent<Collider>(), mybullet.GetComponentInChildren<Collider> ());
				GameObject.Destroy (mybullet, bulletLife);
				GetComponent<ObservedBehaviour> ().firedShot ();
				tommy_ammo--;
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