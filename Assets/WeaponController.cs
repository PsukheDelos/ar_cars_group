using UnityEngine;

public class WeaponController : MonoBehaviour {
//
	public GameObject bullet;
	public Transform point;
	private float bulletLife = 10;

	[PunRPC]
	void fireMachineGun()
	{
		point = this.GetComponentInChildren<Transform> ().Find ("Weapon");
//		point = GameObject.Find ("Weapon").GetComponent<Weapon> ();;
		GameObject mybullet = GameObject.Instantiate (bullet, point.position, point.rotation) as GameObject;
		mybullet.GetComponent<Rigidbody> ().AddRelativeForce (0, 0, 1f, ForceMode.Impulse);
		Physics.IgnoreCollision (point.GetComponent<Collider>(), mybullet.GetComponentInChildren<Collider> ());
		GameObject.Destroy (mybullet, bulletLife);
	}
//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}
}

