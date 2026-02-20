using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Floor_Check : MonoBehaviour
{
    IPlayerDetectorReceiver playerDetectorReceiver;

    private void Awake()
    {
        playerDetectorReceiver = GetComponentInParent<IPlayerDetectorReceiver>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Floor"))
        {
            playerDetectorReceiver?.OnFloorStateChange(true, false, other.tag);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Floor"))
        {
            playerDetectorReceiver?.OnFloorStateChange(false, true, other.tag);
        }
    }
}
