using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInstance : MonoBehaviour
{
    // Prefab
    public GameObject miniFire;

    // zona de Spanw
    float spawnLimitXMin = 0.45f;
    float spawnLimitXMax = -0.45f;
    float spawnLimitYMin = -0.50f;
    float spawnLimitYMax = 0.50f;
    float spawnDirection = 0.7f;

    float minTimeSpawn = 1f;
    float maxTimeSpawn = 5f;

    // Crear un array
    // modificar los local y global
    // Pool

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireInstancie", 1f, Random.Range(minTimeSpawn, maxTimeSpawn));
    }

    

    void FireInstancie()
    {

        Vector3 localSpawnPos = new Vector3(
            Random.Range(spawnLimitXMin, spawnLimitXMax),
            Random.Range(spawnLimitYMin, spawnLimitYMax),
            spawnDirection
        );
        Vector3 localPosition = transform.TransformPoint(localSpawnPos);



        GameObject fire = Instantiate(miniFire, localPosition, Quaternion.identity);
        fire.GetComponentInChildren<MiniFireScript>().Initialize(transform.forward);
    }

}
