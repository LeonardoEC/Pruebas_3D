using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ordendetect : MonoBehaviour
{
    public bool iFollowYou = false;
    public bool RecibiendoCuracion = false;
    public float curacionRecibida;


    private void OnTriggerExit(Collider other)
    {

        if(other.name == "Player")
        {
            Debug.Log("Cientifico: He perdido al jugador");

            Medikit_Controller MedicController = other.GetComponentInChildren<Medikit_Controller>();

            if (MedicController != null)
            {
                iFollowYou = MedicController.followMe;

                if (iFollowYou)
                {
                    Debug.Log("Cientifico: Te estoy siguiendo");
                }
                else if (iFollowYou == false)
                {
                    Debug.Log("Cientifico: No te estoy siguiendo");
                }
            }

        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            Medikit_Controller MedicController = other.GetComponentInChildren<Medikit_Controller>();
            if (MedicController != null)
            {
                RecibiendoCuracion = MedicController.curando;
                if (RecibiendoCuracion && curacionRecibida < 100)
                {
                    Debug.Log("Cientifico: me estan curado");
                    curacionRecibida += 1f;
                    if(curacionRecibida == 100f)
                    {
                        curacionRecibida = 100f;
                    }
                }

                else
                {
                    Debug.Log("Cientifico: No me estan curando");
                }
            }
        }
    }

}
