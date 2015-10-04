using UnityEngine;
using System.Collections;

public class TriggerCardSpawn : MonoBehaviour {

	public Transform SpawnArea;
	
	
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "ImageTarget2XY") {
			Debug.Log ("Hit");
			Instantiate(SpawnArea, new Vector3(0,15,30), transform.rotation);
		}
	}
}
