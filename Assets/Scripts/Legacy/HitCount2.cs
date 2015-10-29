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
		GameObject.Find(PhotonNetwork.playerName).GetPhotonView().RPC("checkhit", PhotonTargets.All);
	}

[PunRPC]
	void checkhit(){
	if(hit == 20){
		GameObject spawnPoint = GameObject.Find ("Player" + PhotonNetwork.playerName + "SpawnPoint");
			gameObject.transform.position = spawnPoint.transform.position;
			//		GameObject.Find(PhotonNetwork.player.name).transform(spawnPoint.transform);
//		PhotonNetwork.Destroy(gameObject);
		PhotonNetwork.Instantiate(DeathAnimation.name, transform.position, transform.rotation, 0);
			hit = 0;
			PhotonNetwork.player.AddScore(1);
		}
  }
}