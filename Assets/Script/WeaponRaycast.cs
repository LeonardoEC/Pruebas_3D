using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRaycast : MonoBehaviour
{
    public float MaxDistance = 5f;
    public GameObject bulletPrefab;
    public Water_Controller waterController;
    public Transform shootPoint;
    public Camera cameraPoint;


    // Update is called once per frame
    void Update()
    {
        //RayConfig();
        WeaponMovement();
    }
    /*
    public void RayConfig()
    {

        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * MaxDistance, Color.green);

        
        if(Physics.Raycast(ray, out hit, MaxDistance))
        {
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red);

            if(hit.collider.gameObject.GetComponent<FureMovement>() == null)
            {
                return;
            }

            // FureMovement fire = hit.collider.gameObject.GetComponent<FureMovement>();
            Handel_Fire fire = hit.collider.gameObject.GetComponent<Handel_Fire>();

            if (fire != null)
            {

                //hit.transform.Translate(new Vector3(0,0,fire.direction + ray.direction.z) * (fire.speed + 7f) * Time.deltaTime);
                //fire.FireRetroced();
                
            }
            else
            {
                Debug.Log("No se encontro el script FureMovement en el objeto impactado.");
            }

        }
        
    }
    */

    // Control de poscions
    void WeaponMovement()
    {
        transform.rotation = cameraPoint.transform.rotation;
    }
    
    // Agregar tiempo de disparo
    public void ShootBullet()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))

            Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }
    
    

    public void ShootWater()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            waterController.waterByRaycast(true, shootPoint);
        }
        else
        {
            waterController.waterByRaycast(false, shootPoint);
        }
    }


}
