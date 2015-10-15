using UnityEngine;
using System.Collections;

public class CardSpawn : MonoBehaviour {

	public Transform SpawnArea;
	
	
	
	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "ImageTarget 2") {
			Debug.Log ("Hit");
			Instantiate(SpawnArea, new Vector3(0,20,30), transform.rotation);
		}
	}
}
