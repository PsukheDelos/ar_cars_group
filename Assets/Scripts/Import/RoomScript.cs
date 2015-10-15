using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour {

	public GameObject[] nodes = {};
    public GameObject world;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public GameObject getRandomNode(){
		return nodes[Random.Range(0, nodes.Length)];
	}

	public GameObject getNearestNode (Transform pos) {
		float closestDistance = float.MaxValue;
		int nearestNodeIndex = 0;
		for (int i = 0; i < nodes.Length; i++) {
			var thisDistance = Vector3.Magnitude(nodes[i].transform.position - pos.position);
			if (thisDistance < closestDistance) {
				closestDistance = thisDistance;
				nearestNodeIndex = i;
			}
		}
		return nodes[nearestNodeIndex];
	}

    public GameObject getWorld()
    {
        return world;
    }
}
