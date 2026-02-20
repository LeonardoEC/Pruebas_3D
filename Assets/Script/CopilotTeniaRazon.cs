using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopilotTeniaRazon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Ray desde la cámara hacia la posición del mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Si el ray toca algo en la escena
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            // El cilindro rota para mirar ese punto
            transform.LookAt(hit.point);
        }


    }
}
