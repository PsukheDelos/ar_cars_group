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

		public Text timerText;
		public Text countDownText;

		private float bulletLife = 10;

	    private bool fired;
		private bool firing;
	    private bool locked;
	    private bool switched;
	    private float cooldown;
	
		private int tommy_ammo = 10;
//		private int pistol_ammo = 12;

		private bool first = true;
	
		private float startTime;
		private float currentTime;
		private float gameDuration = 13.0f;// added 3 for the 3s count down

		public enum WeaponType
	    {
	        PISTOL,
	        TOMMYGUN
		}

		void start()
		{
			startTime = Time.time;
			currentTime = startTime;
			countDownText.text = "";
			timerText.text = "";
		}
		
		void update()
		{
			currentTime = Time.time;
			float elapsedTime = currentTime - startTime;
			if (elapsedTime > 3.0 && elapsedTime <= gameDuration) {
				float timeRemaining = (float)gameDuration - elapsedTime;
				countDownText.text = "";
				timerText.text = "Time Left " + timeRemaining + "s";
//				Debug.Log (timerText.text);
			} else if (elapsedTime <= 3.0) {
				string txt = "Game starting in\n" + (int)(4 - elapsedTime);
				countDownText.text = txt;
				timerText.text = "";
			} else { // game ends
				timerText.text = "";
				// TODO: add in game logic to determine winner here
				countDownText.text = "Game Ended.\nThe Winner is...";
				// TODO: probably should add in logic to disable controls here
			}
		}
		
		public void FixedUpdate () {
			if (PhotonNetwork.playerList.Length > 1) {
				if (first) {
					start ();
					first = false;
				} else {
					update ();
				}				
			} else {
				// resets game
				countDownText.text = "Waiting for\nplayer...";
				timerText.text = "";
			}
			cooldown += Time.deltaTime;
//			Debug.Log ("Shooting Weapon");
			//			tommypoint = GameObject.Find("Car");
			if (type == WeaponType.TOMMYGUN && cooldown > 0.1f && tommy_ammo > 0 && firing==true) {
				cooldown = 0;
				GameObject.Find(PhotonNetwork.playerName).GetPhotonView().RPC("fireMachineGun", PhotonTargets.All);
//				this.myPhotonView.RPC("fireMachineGun", PhotonTargets.All);

//				tommypoint = GameObject.Find(PhotonNetwork.player.ID.ToString());

//				fire ();
//				PhotonView.Get(this).RPC("fire", PhotonTargets.All, null);				
//				GetComponent<ObservedBehaviour> ().firedShot ();
//				tommy_ammo--;
			}
		}

		void OnEnable()
		{
		}

//		[PunRPC]
		void fire(){

			tommypoint = GameObject.Find("Weapon");
			GameObject mybullet = GameObject.Instantiate (tommybullet, tommypoint.transform.position, tommypoint.transform.rotation) as GameObject;
			mybullet.GetComponent<Rigidbody> ().AddRelativeForce (0, 0, 0.1f, ForceMode.Impulse);
			Physics.IgnoreCollision (tommypoint.GetComponent<Collider>(), mybullet.GetComponentInChildren<Collider> ());
			GameObject.Destroy (mybullet, bulletLife);
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