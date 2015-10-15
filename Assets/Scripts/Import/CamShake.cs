using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour {
    public float shake;
    public float reduction;

    private Vector3 prevShake;

	// Use this for initialization
	void Start () {
        prevShake = Vector3.zero;
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.position -= prevShake;
        shake *= reduction;
        prevShake = Random.insideUnitSphere * shake;
        transform.position += prevShake;
	}

    public void addShake(float amount)
    {
        shake += amount;
    }
}
