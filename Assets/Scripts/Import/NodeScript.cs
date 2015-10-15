using UnityEngine;
using System.Collections;

public class NodeScript : MonoBehaviour {

	public float duration;
	public GameObject[] nodes = {};

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		for (var i = 0; i < nodes.Length; i++) {
			Debug.DrawLine(transform.position, nodes[i].transform.position);
		}
	}

	public GameObject getNextNode(){
		return nodes[Random.Range(0, nodes.Length)];
	}

	public float getDuration(){
		return duration;
	}

}
