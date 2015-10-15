using UnityEngine;
using System.Collections;

public class ShareKnowledge : MonoBehaviour {

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.GetComponent<GuestKnowledge>() != null)
        {
            if (c.gameObject.GetComponent<GuestKnowledge>().canAddKnowledge(GetComponent<GuestKnowledge>().getKnowledge()) && GetComponent<GuestState>().getState() != GuestState.State.PANIC)
            {
                c.gameObject.GetComponent<GuestKnowledge>().addKnowledge(GetComponent<GuestKnowledge>().getKnowledge());
                GetComponent<GuestState>().setState(GuestState.State.GOSSIP);
            }
            if (c.gameObject.GetComponent<GuestState>().getState() == GuestState.State.GOSSIP && GetComponent<GuestState>().getState() == GuestState.State.PANIC)
            {
                c.gameObject.GetComponent<GuestState>().setState(GuestState.State.PANIC);
            }
        }
    }
}
