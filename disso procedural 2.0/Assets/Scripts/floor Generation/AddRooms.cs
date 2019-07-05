using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    private RoomLayout differentRooms;
    // Start is called before the first frame update
    void Start()
    {
        differentRooms = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomLayout>();
        differentRooms.Rooms.Add(this.gameObject);
    }
}
