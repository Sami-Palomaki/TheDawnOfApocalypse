using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;
    FirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponentInParent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed",controller.GetCurrentSpeed());
        Debug.Log(controller.GetCurrentSpeed());

        if(Input.GetMouseButtonDown(0))
        {
            anim.PlayInFixedTime("Attack",0);
        }
    }
}
