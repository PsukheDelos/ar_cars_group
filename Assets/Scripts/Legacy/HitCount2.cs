using UnityEngine;
using System.Collections;



public class HitCount2 : MonoBehaviour{
	public Transform DeathAnimation;


	int hit = 0;



void OnCollisionEnter(Collision col){
		if (col.gameObject.name.Contains ("Bullet")) {
			Debug.Log ("Bullet Hit");
			hit += 1;
		} else if (col.gameObject.tag == "Ram") {
			Debug.Log ("Vehicle Hit");
			hit += 5;
		} 
//		hit += 5; //for debugging
		GameObject.Find(PhotonNetwork.playerName).GetPhotonView().RPC("checkhit", PhotonTargets.All);

//		checkhit ();
	}

[PunRPC]
void checkhit(){
	if(hit == 20){
		PhotonNetwork.Destroy(gameObject);
//		Destroy(gameObject);
//		PhotonNetwork.Instantiate (Car, transform.position, transform.rotation, 0);
			// might need to do this over the network???
		PhotonNetwork.Instantiate(DeathAnimation.name, transform.position, transform.rotation, 0);
//		Instantiate(Car, transform.position, transform.rotation);
	}
  }
}