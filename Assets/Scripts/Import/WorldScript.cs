using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour {
    public GameObject[] rooms;

    public GameObject getNewRoom(GameObject room){
        GameObject newroom = rooms[Random.Range(0, rooms.Length)];
        while (newroom == room){
            newroom = rooms[Random.Range(0, rooms.Length)];
        }
        return newroom;
    }
}
