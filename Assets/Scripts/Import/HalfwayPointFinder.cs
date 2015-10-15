using UnityEngine;
using System.Collections;

public class HalfwayPointFinder : MonoBehaviour {
    public GameObject point1;
    public GameObject point2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(point1.transform.position, point2.transform.position, 0.5f);
	}
}
