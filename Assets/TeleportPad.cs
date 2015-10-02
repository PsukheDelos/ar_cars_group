using UnityEngine;
using System.Collections;

public class TeleportPad : MonoBehaviour {
	public int code;
	float disableTimer = 0;

	void update(){
		if (disableTimer > 0)
			disableTimer = Time.deltaTime; 
	}

	void OnTriggerEnter(Collider collider){
		Debug.Log ("Work!!!");
		if (collider.gameObject.name == "CarRockSteady" && disableTimer<=0)

		
		{

			foreach(TeleportPad tp in FindObjectsOfType<TeleportPad>()){

				if(tp.code==code && tp != this){
					tp.disableTimer=2;
					Vector3 position=tp.gameObject.transform.position;
					position.y+=0;
					collider.gameObject.transform.position=position;

				}

			}

		}

		}
 

}
