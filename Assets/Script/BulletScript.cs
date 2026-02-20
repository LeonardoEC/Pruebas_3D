using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        BulletDirection();
    }

    void BulletDirection()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 15f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("WallFire") && other.gameObject.name == "WallFire")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.CompareTag("MiniFire") && other.gameObject.name == "MiniFire(Clone)")
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
