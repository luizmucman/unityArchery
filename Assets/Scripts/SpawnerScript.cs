using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enermy;
    void Start()
    {
        GameObject clone = Instantiate(enermy);
        clone.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
