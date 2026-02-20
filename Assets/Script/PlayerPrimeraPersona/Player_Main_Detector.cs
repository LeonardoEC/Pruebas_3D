using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPlayerDetectorReceiver
{
    void OnFloorStateChange(bool isOnFloor,bool onAir ,string floorTag);
}


public class Player_Main_Detector : MonoBehaviour, IPlayerDetectorReceiver
{
    public bool isInFloor {  get; private set; }
    public bool inAir { get; private set; }
    public string floorTag { get; private set; }



    public void OnFloorStateChange(bool state, bool air, string tang)
    {
        isInFloor = state;
        
        floorTag = tang;

        inAir = air;
    }
}


