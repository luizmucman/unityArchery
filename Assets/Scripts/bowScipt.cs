using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowScipt : MonoBehaviour
{
    public Animator ani;
    public AcherCOntroller Arch;
    void Start()
    {
        //ani = ani.GetComponent<Animator>();
       // Arch = GetComponent<AcherCOntroller>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetFloat("DrawCharge", Arch.arrowPower);
    }
}
