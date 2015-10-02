using UnityEngine;
using System.Collections;



public class HitCount : MonoBehaviour{
	public Transform Car;


	int hit = 0;



void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Car(Clone)") {
			Debug.Log ("Hit");
			hit += 1;
			checkhit ();
		}
	}
void checkhit(){
	if(hit == 3){
		Destroy(gameObject);
			Instantiate(Car, transform.position, transform.rotation);
	}
  }
}