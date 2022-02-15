using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    public ParticleSystem muzzleflash;          
    void Update()
    {
        if (Input.GetMouseButtonDown(0))        // Hiiren ykköspainikkeella
        {                                       // 
            muzzleflash.Play();                 // tämä välähdys toistetaan
        }
    }
}
