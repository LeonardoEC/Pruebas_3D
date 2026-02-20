using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Tool_Detector : MonoBehaviour
{
    private GameObject toolDetector;
    public string rol;

    Vector3 weaponPosition = new Vector3(-0.2629998f, -0.423f, 0.262f);
    Vector3 medikitPosition = new Vector3(0.353f, -0.565f, 0.267f);

    private void Awake()
    {
        ToolDectertor();
    }

    private void ToolDectertor()
    {
        if (transform.childCount == 0)
        {
            Debug.LogError("No tool detected | Herramienta no detectada");
        }
        else if (transform.childCount > 1)
        {
            Debug.LogError("Multiple tools detected, only one tool is allowed | Se detectaron varias herramientas, solo se permite una herramienta");
        }
        else
        {
            toolDetector = transform.GetChild(0).gameObject;

            if (!toolDetector.activeSelf)
            {
                Debug.LogWarning("The tool is not active | La herramienta no está activa");
            } else
            {
                if (toolDetector.name == "arma" && toolDetector.tag == "Tool")
                {
                    rol = "shooter";
                    toolDetector.transform.localPosition = weaponPosition;
                    // Debug.Log("Shooter role assigned");
                }
                else if (toolDetector.name == "medkit" && toolDetector.tag == "Tool")
                {
                    rol = "healer";
                    // Debug.Log("Healer role assigned");
                    toolDetector.transform.localPosition = medikitPosition;
                }
                else
                {
                    Debug.LogWarning("No valid tool detected | No se detectó ninguna herramienta válida");
                }
            }
        }
    }


    public void UseTool()
    {
        if(rol == "shooter")
        {
            // Debug.Log("Shooting action performed");
            WeaponRaycast weapon = toolDetector.GetComponent<WeaponRaycast>();
            if (weapon != null)
            {
                weapon.ShootWater();
                weapon.ShootBullet();
            }
            else
            {
                Debug.LogError("No WeaponRaycast component found on the tool");
            }
        }
        else if(rol == "healer")
        {
            // Debug.Log("Healing action performed");
            Medikit_Controller medikit = toolDetector.GetComponent<Medikit_Controller>();
            if (medikit != null)
            {
                medikit.medic();
            }
            else
            {
                Debug.LogError("No Medikit_Controller component found on the tool");
            }
        }
        else
        {
            Debug.LogError("No role assigned, cannot use tool");
        }
    }

}
