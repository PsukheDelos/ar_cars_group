﻿using UnityEngine;
using System.Collections;



public class HitCount : MonoBehaviour{
	public Transform Bomb;


	int hit = 0;



void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Cube") {
			Debug.Log ("Hit");
			hit += 1;
			checkhit ();
		}
		if (col.gameObject.name == "ColliderRam") {
				Debug.Log ("HitX");
				hit += 1;
				checkhit ();
		}
	}
void checkhit(){
	if(hit == 5){
		Destroy(gameObject);
			Instantiate(Bomb, transform.position, transform.rotation);
	}
  }
}