using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

	public GameObject theJudge;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			theJudge.GetComponent<DetermineOutcome> ().GameOver ();
		}
	}
}
