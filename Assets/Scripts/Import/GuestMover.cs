using UnityEngine;
using System.Collections;

public class GuestMover : MonoBehaviour
{
    public float wanderDistance;
    public float panicDistance;
    public float targetThreshold;
    public GameObject room;

    private Animator anim;

    private Vector3 direction;
    private NavMeshAgent nma;
    private bool pathing;
    private GameObject targetNode;
    private float waitTime;
	private float stuckTime;

    // Use this for initialization
    void Start()
    {
		nma = GetComponent<NavMeshAgent> ();
		nma.avoidancePriority = Random.Range (0, 100);

        anim = GetComponentInChildren<Animator> ();
        targetNode = room.GetComponent<RoomScript>().getNearestNode(transform);
		nma.destination = targetNode.transform.position;
		waitTime = targetNode.GetComponent<NodeScript>().getDuration();
    }

    // Update is called once per frame
    void Update()
    {
		//If the character has stopped, and is not waiting, it might be stuck
		//So we'll wait a few seconds then wander
		if (Vector3.Magnitude(nma.velocity) < 0.1f && waitTime > 0) {
			stuckTime += Time.deltaTime;
			if(stuckTime > 5.0f){
				targetNode = room.GetComponent<RoomScript>().getRandomNode();
				waitTime = targetNode.GetComponent<NodeScript>().getDuration();
				stuckTime = 0f;
			}
		}

        if (GetComponent<GuestState>().getState() == GuestState.State.PANIC)
        {
            waitTime = 0;
        }

        if ((Vector3.Magnitude(transform.position - nma.destination) < targetThreshold
            && GetComponent<GuestState>().getState() != GuestState.State.GOSSIP))
        {
			waitTime -=Time.deltaTime;
			if(waitTime < 0){
	            if (GetComponent<GuestState>().getState() == GuestState.State.WANDER)
	            {
	                targetNode = targetNode.GetComponent<NodeScript>().getNextNode();
	            }
	            if (GetComponent<GuestState>().getState() == GuestState.State.PANIC)
	            {
	                targetNode = room.GetComponent<RoomScript>().getWorld().GetComponent<WorldScript>().getNewRoom(room).GetComponent<RoomScript>().getRandomNode();
	            }
	            nma.SetDestination(targetNode.transform.position);
				waitTime = targetNode.GetComponent<NodeScript>().getDuration();
			}
        }
        Debug.DrawLine(transform.position, nma.destination, Color.green);
        anim.SetFloat("Movement", Vector3.Magnitude(nma.velocity));
       
    }

    public void panic(GameObject source)
    {
        direction = (Vector3.Normalize(transform.position - source.transform.position) + Random.insideUnitSphere) * panicDistance;
        direction += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(direction, out hit, wanderDistance, 1);
        nma.SetDestination(hit.position);
    }
}
