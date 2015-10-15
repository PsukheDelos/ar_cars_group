using UnityEngine;
using System.Collections;

public class SilenceOnEndSound : MonoBehaviour {

    void Start()
    {
        GetComponent<AudioSource>().pitch += Random.Range(-0.01f, 0.01f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<AudioSource>().isActiveAndEnabled)
        {
            if (GetComponent<AudioSource>().time > 0.5f)
            {
                GetComponent<AudioSource>().enabled = false;
            }
        }
	}
}
