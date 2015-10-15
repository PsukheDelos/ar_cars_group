using UnityEngine;
using System.Collections;

public class GuestState : MonoBehaviour
{
    public State state;
    public float panicDuration;
    public float gossipDuration;
    public float panicCooldown;
    public float gossipCooldown;

    private Animator anim;

    public enum State
    {
        WANDER,
        GOSSIP,
        PANIC
    }

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        switch (state)
        {
            case State.PANIC:
                GetComponent<NavMeshAgent>().speed = 10; break;
            case State.WANDER:
                GetComponent<NavMeshAgent>().speed = 2; break;
            case State.GOSSIP:
                GetComponent<NavMeshAgent>().speed = 0.2f; break;
        }
    }

    void Update()
    {
        if (state == State.PANIC)
        {
            panicCooldown -= Time.deltaTime;
            gossipCooldown -= Time.deltaTime;
            if (panicCooldown < 0)
            {
                setState(State.WANDER);
            }
        }
        if (state == State.GOSSIP)
        {
            panicCooldown -= Time.deltaTime;
            gossipCooldown -= Time.deltaTime;
            if (gossipCooldown < 0)
            {
                setState(State.WANDER);
            }
        }
        switch (state)
        {
            case State.GOSSIP: anim.SetInteger("Mood", 2); break;
            case State.PANIC: anim.SetInteger("Mood", 1); break;
            case State.WANDER: anim.SetInteger("Mood", 0); break;
        }
    }

    public State getState()
    {
        return state;
    }

    public Color getStateColor()
    {
        switch (state)
        {
            case State.PANIC:
                return Color.red;
            case State.WANDER:
                return Color.white;
            case State.GOSSIP:
                return Color.black;
        }
        return Color.blue;
    }

    public void setState(State newState)
    {
        state = newState;
        switch (newState)
        {
            case State.PANIC:
                GetComponent<NavMeshAgent>().speed = 5;
                panicCooldown = panicDuration; break;
            case State.WANDER:
                GetComponent<NavMeshAgent>().speed = 2; break;
            case State.GOSSIP:
                GetComponent<NavMeshAgent>().speed = 0;
                gossipCooldown = gossipDuration; break;
        }
    }
}
