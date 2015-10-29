using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class HitCount2 : MonoBehaviour{
	public Transform DeathAnimation;
	public Slider healthSlider;
	int health = 100;


void Update(){
		GameObject.Find(PhotonNetwork.playerName).GetPhotonView().RPC("checkhit", PhotonTargets.All);
	}
void OnCollisionEnter(Collision col){
		if (col.gameObject.name.Contains ("Bullet")) {
			Debug.Log ("Bullet Hit");
			health -= 5;
		
		} else if (col.gameObject.tag == "Ram") {
			Debug.Log ("Vehicle Hit");
			health -= 10;
		} 
//		GameObject.Find(PhotonNetwork.playerName).GetPhotonView().RPC("checkhit", PhotonTargets.All);
//		healthSlider.value = health;
		GameObject.Find ("HealthSlider" + PhotonNetwork.playerName).GetComponent<Slider> ().value = health;
	}

[PunRPC]
	void checkhit(){
		if(health == 0 || (transform.position.y < 10 && PhotonNetwork.player.GetTeam () == PunTeams.Team.none)){
			GameObject spawnPoint = GameObject.Find ("Player" + PhotonNetwork.playerName + "SpawnPoint");
			PhotonNetwork.Instantiate(DeathAnimation.name, transform.position, transform.rotation, 0);
			gameObject.transform.position = spawnPoint.transform.position;
			gameObject.transform.rotation = spawnPoint.transform.rotation;
			health = 100;
//			healthSlider.value = health;
			GameObject.Find ("HealthSlider" + PhotonNetwork.playerName).GetComponent<Slider> ().value = health;
			if(PhotonNetwork.gameVersion!="GameOver"){
				PhotonNetwork.player.AddScore(1);
			}
		}
  	}
}