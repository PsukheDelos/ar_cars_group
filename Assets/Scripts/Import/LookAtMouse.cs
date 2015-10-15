using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour {
    public GameObject reticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(reticle.transform.position);
	}
}
