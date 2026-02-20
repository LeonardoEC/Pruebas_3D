using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFireScript : MonoBehaviour
{
    public Vector3 fireDirection;


    public void Initialize(Vector3 direction)
    {
        fireDirection = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        minifireMovement();
    }

    void minifireMovement()
    {
        transform.Translate(fireDirection * 15f * Time.deltaTime);
    }
}
