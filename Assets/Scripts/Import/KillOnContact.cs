using UnityEngine;
using System.Collections;

public class KillOnContact : MonoBehaviour
{
    public bool onceOnly;
    private bool once = false;

    void OnCollisionEnter(Collision c)
    {
        if ((!once && onceOnly) || !onceOnly)
        {
            once = true;
            if (c.gameObject.GetComponent<Death>() != null)
            {
                c.gameObject.GetComponent<Death>().die();
            }
        }
    }
}
