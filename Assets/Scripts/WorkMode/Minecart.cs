using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minecart : MonoBehaviour
{
    public List<Minecart> minecartStations;
    

    public void Test()
    {
        minecartStations = new List<Minecart>(FindObjectsOfType<Minecart>());
        minecartStations.Remove(GetComponent<Minecart>());

        Minecart stationToExit = minecartStations[0];
        
        Vector3 stationtoExitCords = new Vector3(stationToExit.gameObject.transform.position.x,
            stationToExit.gameObject.transform.position.y, stationToExit.gameObject.transform.position.z);

        FindObjectOfType<PlayerMovement>().transform.position = stationtoExitCords;
    }
}
