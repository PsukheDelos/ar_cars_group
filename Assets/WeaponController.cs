using UnityEngine;

public class WeaponController : MonoBehaviour {
//
	public GameObject bullet;
	public Transform point;
	private float bulletLife = 3;

	[PunRPC]
	void fireMachineGun()
	{
		point = this.GetComponentInChildren<Transform> ().Find ("Weapon");
		GameObject mybullet = GameObject.Instantiate (bullet, point.position, point.rotation) as GameObject;
		mybullet.GetComponent<Rigidbody> ().AddRelativeForce (0, 0, 1f, ForceMode.Impulse);
		foreach (Collider c in gameObject.GetComponentsInChildren<Collider>()) {
			Physics.IgnoreCollision (c, mybullet.GetComponentInChildren<Collider> ());
		}
		GameObject.Destroy (mybullet, bulletLife);
	}

}

