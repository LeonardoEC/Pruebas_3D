using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private LayerMask groundMask;
    private Camera mainCamara;

    private void Awake()
    {
        mainCamara = Camera.main;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }


    private(bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamara.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            return( success: true, position: hitInfo.point );
        }
        else
        {
            return( success: false, position: Vector3.zero );
        }
    }

    private void Aim()
    {
        var(succes, position) = GetMousePosition();
        if(succes)
        {
            var direction = position - transform.position;

            direction.y = 0;

            transform.forward = direction;
        }
    }
}
