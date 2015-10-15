using UnityEngine;
using System.Collections;

public class ObservedBehaviour : MonoBehaviour
{
    public float fireCooldown;
    public float myVisualCooldown;
    public float myAudioCooldown;
	
	// Update is called once per frame
	void Update () {
        myVisualCooldown -= Time.deltaTime;
        if (myVisualCooldown < 0)
        {
            myVisualCooldown = 0;
        }
        myAudioCooldown -= Time.deltaTime;
        if (myAudioCooldown < 0)
        {
            myAudioCooldown = 0;
        }
	}

    public void firedShot()
    {
        myVisualCooldown = fireCooldown;
        myAudioCooldown = fireCooldown;
    }

    public void swungKnife()
    {
        myVisualCooldown = fireCooldown;
    }

    public bool hearFiredShot()
    {
        return myAudioCooldown > 0;
    }

    public bool seeAttack()
    {
        return myVisualCooldown > 0;
    }
}
