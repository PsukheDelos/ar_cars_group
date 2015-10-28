using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {

	public Dropdown lobbies;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (lobbies.value == 0) {
			foreach(Image i in gameObject.GetComponentsInChildren<Image>()){
				i.enabled = true;
			}
			gameObject.GetComponentInChildren<Text>().enabled = true;
		} else {
			foreach(Image i in gameObject.GetComponentsInChildren<Image>()){
				i.enabled = false;
			}
			gameObject.GetComponentInChildren<Text>().enabled = false;		}
	}
}
