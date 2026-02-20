using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Interaction : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("NPC"))
        {
            PlayerMovement player = GetComponentInParent<PlayerMovement>();
            if(player != null)
            {
                player.InteracticWith(other.gameObject);
            }
        }
    }
}
