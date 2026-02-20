using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medikit_Controller : MonoBehaviour
{
    public bool followMe = false;
    public bool curando = false;

    bool PlayerOrder;
    float NPCSalud;
    float curacion;

    private void OnTriggerStay(Collider other)
    {
        if(other != null)
        {
            
            if (other.CompareTag("NPC"))
            {

                IANPC iANPC = other.GetComponent<IANPC>();

                if (iANPC != null)
                {
                    iANPC.order = PlayerOrder;

                    // Salud actual del personaje
                    NPCSalud = iANPC.NPCSalid;
                    // Curando al personaje
                    iANPC.NPCSalid = curacion;
                }
            }
        }
    }

    public void medic()
    {
        FollowMe();
        Healing();
    }

    void Healing()
    {
        if(Input.GetKey(KeyCode.Mouse0) && NPCSalud >= 0 && NPCSalud <= 100)
        {
            Debug.Log("Player: Te estoy curando");
            curacion += 20 * Time.deltaTime;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0) && NPCSalud >= 100)
        {
            Debug.Log("Player: He dejado de curar");
        }
        else if(Input.GetKey(KeyCode.Mouse0) && NPCSalud <= 100)
        {
            Debug.Log("Player: Ya estas curado");
        }
        
    }

    void FollowMe()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlayerOrder = !PlayerOrder;
            Debug.Log("Orden enviada: " + PlayerOrder);
        }
    }


}

