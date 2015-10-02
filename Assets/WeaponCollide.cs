using UnityEngine;
using System.Collections;

public class WeaponCollide : MonoBehaviour
{
	void OnCollisionEnter (Collision col)
	{Debug.Log ("Work!!!");

		if(col.gameObject.name == "CubeX")
		{   
			Destroy(col.collider.gameObject);
		}
	}
}

