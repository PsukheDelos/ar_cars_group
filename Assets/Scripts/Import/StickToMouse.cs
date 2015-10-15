using UnityEngine;
using System.Collections;

public class StickToMouse : MonoBehaviour {
    public float camDist;
    public float lag;
    public Camera cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        Vector3 worldPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDist);
        worldPos = cam.ScreenToWorldPoint(worldPos);
        transform.position = Vector3.Lerp(transform.position, worldPos, lag);
	}
}
