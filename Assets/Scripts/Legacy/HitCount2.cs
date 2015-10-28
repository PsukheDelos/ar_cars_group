using UnityEngine;
using System.Collections;



public class HitCount2 : MonoBehaviour{
	public Transform Car;


	int hit = 0;



void OnCollisionEnter(Collision col){
		if (col.gameObject.name.Contains ("Bullet")) {
			Debug.Log ("Bullet Hit");
			hit += 1;
		} else if (col.gameObject.tag=="Player"){
			Debug.Log ("Vehicle Hit");
			hit += 5;
		}
		checkhit ();
	}
void checkhit(){
	if(hit == 5){
		Destroy(gameObject);
//		PhotonNetwork.Instantiate (Car, transform.position, transform.rotation, 0);
		Instantiate(Car, transform.position, transform.rotation);
	}
  }
}