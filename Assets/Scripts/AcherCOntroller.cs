using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AcherCOntroller : MonoBehaviour
{
    public Rigidbody arrow;
    public GameObject arrowObject;
    public Transform ArrowPos;
    public float arrowPower;
    public float chargeRate;
    public float maxArrowPower;
    public float reloadTime = 0.5f;
public float playerSpeed = 1f;
    public float focus = 30f;
    public float mouseSens = 1f;
    public bool lookActive = false;

    public bool alive = true;

    public GameObject xhair;

    Transform getarrow;

    Camera cam;
    void Start()
    {
        xhair.gameObject.SetActive(true);
     

        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.lockState = CursorLockMode.Confined;

        cam = GetComponent<Camera>();


        reload();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
		{
            arrowPower = arrowPower + chargeRate * Time.deltaTime;
            if (arrowPower > maxArrowPower)
			{
                arrowPower = maxArrowPower;
			}
		}

            if (Input.GetButtonUp("Fire1"))
		{

            
            getarrow = this.gameObject.transform.GetChild(1);

            Rigidbody cloneRB = getarrow.GetComponent<Rigidbody>();
            cloneRB.isKinematic = false;
         
            cloneRB.AddForce(transform.forward * arrowPower);
            getarrow.transform.parent = null;
            //arrow.isKinematic = false;
            //arrow.AddForce(transform.forward * arrowPower);
            StartCoroutine("reloadDelay");


        }

            if (Input.GetButton("Fire2"))  //zoom on right mouse hold
		{
            cam.fieldOfView = focus;
		}

        if (Input.GetButtonUp("Fire2")) //release zoom
        {
            cam.fieldOfView = 60f;
        }

        if (Input.GetKeyDown("escape"))
        {

            Cursor.lockState = CursorLockMode.None;
        }

        float movementx = Input.GetAxis("Horizontal") * playerSpeed;
        float movementy = Input.GetAxis("Vertical") * playerSpeed;

       
        if (Input.GetButton("Horizontal") || (Input.GetButton("Vertical"))) //AWSD movement 
        {
            if (alive)


                transform.position += transform.forward * Time.deltaTime * movementy;
           transform.position += transform.right * Time.deltaTime * movementx;

        }

        if (lookActive && alive) //mouse look/aim
        {


            transform.Rotate(-Input.GetAxis("Mouse Y") * mouseSens, 0f, 0f, Space.Self);

            transform.Rotate(0f, Input.GetAxis("Mouse X") * mouseSens, 0f, Space.World);

        }


    }
    private void FixedUpdate()
	{
		
	}
   void reload()
	{
        GameObject clonedArrow;
        clonedArrow = Instantiate(arrowObject, ArrowPos.position, ArrowPos.rotation);
        clonedArrow.transform.parent = transform;
        arrowPower = 500f;
    }
    IEnumerator reloadDelay()
    {
       
        yield return new WaitForSeconds(reloadTime);
        reload();
    }

}