using UnityEngine;
using System.Collections;



public class HitCount2 : MonoBehaviour{
	public Transform Car;


	int hit = 0;



void OnCollisionEnter(Collision col){
		if (col.gameObject.name.Contains ("Bullet")) {
			Debug.Log ("Bullet Hit");
			hit += 1;
		} else if (col.gameObject.tag == "Player") {
			Debug.Log ("Vehicle Hit");
			hit += 5;
		} 
		hit += 5; //for debugging
		checkhit ();
	}
void checkhit(){
	if(hit == 5){
		Destroy(gameObject);
//		PhotonNetwork.Instantiate (Car, transform.position, transform.rotation, 0);
			// might need to do this over the network???
		Instantiate(Car, transform.position, transform.rotation);
	}
  }
}