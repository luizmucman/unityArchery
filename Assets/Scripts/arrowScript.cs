using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    Rigidbody RB;
    public bool inBow;
    GameObject knock;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        inBow = true;
        knock = GameObject.FindGameObjectWithTag("knock");
    }

    // Update is called once per frame
    void Update()
    {
		if (inBow)
		{
            transform.position = knock.transform.position + transform.right * -0.01f;
            transform.rotation = knock.transform.rotation;
            
		}
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
