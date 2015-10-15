using UnityEngine;
using System.Collections;

public class CharacterControls : MonoBehaviour {
    public float speed;
    public Animator legs;
    public GameObject relativePoint;
    private float moveVert;
    private float moveHoriz;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        moveVert = Input.GetAxisRaw("Vertical");
        moveHoriz = Input.GetAxisRaw("Horizontal");
	}

    void FixedUpdate()
    {
        Vector3 anim = Vector3.ClampMagnitude(new Vector3(moveHoriz, 0, moveVert), 1);
        if (Vector3.Magnitude(anim) > 0.5f)
        { 
            Vector3 rel = Vector3.MoveTowards(Vector3.zero, relativePoint.transform.position - transform.position, 1);
            Vector3 angular = Quaternion.AngleAxis(Vector3.Angle(anim, rel), Vector3.up) * Vector3.forward;
            Debug.DrawRay(transform.position, rel);
            Debug.DrawRay(transform.position, anim);
            Debug.DrawRay(transform.position, angular);
            legs.SetFloat("MoveV", angular.z);
            legs.SetFloat("MoveH", angular.x);
        }
        else
        {
            legs.SetFloat("MoveV", 0);
            legs.SetFloat("MoveH", 0);
        }
        transform.Translate(speed * Vector3.Normalize(new Vector3(moveHoriz, 0, moveVert)), Space.World);
    }
}
