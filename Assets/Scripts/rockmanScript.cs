using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockmanScript : MonoBehaviour
{
    Vector3 direction;
    public float speed= 5f;
    void Start()
    {
        direction = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = transform.position + direction * speed * Time.deltaTime; 
    }
}
