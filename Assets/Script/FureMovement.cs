using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FureMovement : MonoBehaviour
{
    public float direction;
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
        transform.Translate(new Vector3(0, 0 ,direction) * speed * Time.deltaTime);
    }

    public void FireRetroced()
    {
        transform.Translate(new Vector3(0, 0, -direction) * speed * Time.deltaTime);
    }


}
