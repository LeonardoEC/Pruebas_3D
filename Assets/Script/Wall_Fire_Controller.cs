using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Wall_Fire_Controller : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FireAvances();
    }

    public void FireAvances()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void FireRetroced()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision != null)
        {
            Debug.Log("No esta pasando nada");
        }

        if(collision.gameObject.CompareTag("Water") && collision.gameObject.name == "Water")
        {
            FireRetroced();
            Debug.Log("Estoy tocando: " + collision.gameObject.name);
        }

    }
}
