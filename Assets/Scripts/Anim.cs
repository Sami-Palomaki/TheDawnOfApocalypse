using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    [SerializeField]
    public Animator anim;
    public Rigidbody playerRB;
    
    void Update()
    {
        float playerSpeed = playerRB.velocity.magnitude;
        anim.SetFloat("Walk_Mag", playerSpeed);
    }
}
