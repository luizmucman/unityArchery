using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introcam : MonoBehaviour
{
    public bool finished;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.anyKey)
		{
            ended();

        }
    }

    public void ended()
	{
        finished = true;
	}
}
