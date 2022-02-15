using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float fireRate = 20f;
    public float force = 80;
    public GameObject cameraGameObject;
    public ParticleSystem flash;
    public GameObject bulletEffect;
    private Animator animations;
    private float readyToFire;

    private void Start() {
        animations = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if(Time.time >= readyToFire){
            animations.SetInteger("Fire",-1);
            animations.SetInteger("Movement",0);
        }

        if(Input.GetButton("Fire1") && Time.time >= readyToFire ){
            readyToFire = Time.time + 1f/fireRate;                  // Hidastaa ampumisnopeutta
            fire();
            animations.SetInteger("Fire",2);
            animations.SetInteger("Movement",-1);
        }
    }

    private void fire(){
        flash.Play();
        RaycastHit hit;

        if(Physics.Raycast(cameraGameObject.transform.position,cameraGameObject.transform.forward,out hit)){
            if(hit.rigidbody != null)
                hit.rigidbody.AddForce(-hit.normal * force);
            Instantiate(bulletEffect,hit.point,Quaternion.LookRotation(hit.normal));
        }
    }
}
