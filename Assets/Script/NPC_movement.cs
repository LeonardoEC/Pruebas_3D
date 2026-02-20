using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC_movement : MonoBehaviour
{

    public Ordendetect ordenDetect;
    public GameObject player;

    float NPCSalud = 0f;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Curado();
        Seguir();

    }
    /*
    public void OrderRecibida()
    {
        if(ordenDetect.iFollowYou)
        {
            Seguir(player.transform.position.x, player.transform.position.z);
        }
        else
        {
            Seguir(0f,0f);
        }

    }
    */

    public void Seguir()
    {
        
        //transform.Translate(new Vector3(0, 0, targetZ) * 1f * Time.deltaTime);

        // Debug.Log("NPC: Esperando orden..." + ordenDetect.iFollowYou);

        if (ordenDetect.iFollowYou)
        {

            transform.LookAt(player.transform);
            // Efecti fuego ?
            // transform.Translate(Vector3.forward * 2f * Time.deltaTime * (transform.position.z - 5));
            transform.Translate(Vector3.forward * 2f * Time.deltaTime);
            Debug.Log("NPC: Te sigo");
        }
        else if(ordenDetect.iFollowYou)
        {
            transform.Translate(Vector3.zero);
            Debug.Log("NPC: No te sigo");
        }
    }

    void Curado()
    {
        if (ordenDetect.curacionRecibida > 0f)
        {
            NPCSalud = ordenDetect.curacionRecibida;
            if (NPCSalud > 100f) NPCSalud = 100f;
            Debug.Log("NPC: Salud actual " + NPCSalud);
        }
    }

}
