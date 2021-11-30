using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    Rigidbody RB;
    public bool inBow;
    GameObject knock;
    AudioSource inflightSound;
    public bool impacted;
    Collider col;
    public GameObject body;
    void Start()
    {
        col = GetComponent<Collider>();
        RB = GetComponent<Rigidbody>();
        inBow = true;
        knock = GameObject.FindGameObjectWithTag("knock");
        inflightSound = GetComponent<AudioSource>();
        activeCollider(false);

    }

    // Update is called once per frame
    void Update()
    {
		if (inBow)
		{
            transform.position = knock.transform.position + transform.right * -0.01f;
            transform.rotation = knock.transform.rotation;
            
		}


        if(!inBow && !impacted)
		{
            activeCollider(true);
            transform.rotation = Quaternion.LookRotation(RB.velocity * -1);

        }


        if (inflightSound.isActiveAndEnabled)
        {
            if (!inBow && !inflightSound.isPlaying )
            {
                inflightSound.Play(0);
            }
            if (impacted)
			{
                inflightSound.enabled = false;
                //inflightSound.mute = true;
            }
        }
      
    }
	private void OnCollisionEnter(Collision collision)
	{
        
        if (collision.collider.tag == "hit")
		{
            impacted = true;
           
            ContactPoint contact = collision.contacts[0];
            Destroy(RB);
            transform.position = contact.point + (transform.forward * 1.2f);
            transform.parent = collision.collider.transform;
        }

        if (collision.collider.tag == "enermy")
        {
            Destroy(collision.collider.gameObject);
            impacted = true;
            ContactPoint contact = collision.contacts[0];
            Destroy(RB);
            transform.position = contact.point + (transform.forward * 1.2f);
            Instantiate(body, collision.collider.transform.position, Quaternion.identity);
    
        }

    }
	

	void activeCollider(bool alive)
	{

        col.enabled = alive;
    }
}
