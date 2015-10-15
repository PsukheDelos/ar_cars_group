using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour {
    public float cameraStickiness;
    public GameObject target;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate((target.transform.position - transform.position) * Time.deltaTime * cameraStickiness);
	}
}
