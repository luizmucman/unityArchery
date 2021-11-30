using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    Rigidbody RB;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter(Collision collision)
	{
        if(collision.collider.tag == "hit")
		{
            Quaternion flightRotation = transform.rotation;
            ContactPoint contact = collision.contacts[0];
            Destroy(RB);
            transform.position = contact.point + (transform.forward * 1.2f);
            
            //transform.rotation = flightRotation;


            Debug.Log("busted");
            transform.parent = collision.collider.transform;
        }
        
	}
}
