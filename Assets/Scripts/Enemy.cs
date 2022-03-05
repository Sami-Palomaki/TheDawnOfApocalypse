using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public Transform target;
    public float maxSpeed = 5;
    public float radius = 1;
    public bool isWalking = false;
    public int damage = 15;
    public float attackCD;
    public Transform attackPos;
    private float dist;
    // bool canAttack = false;
    NavMeshAgent agent;
    Animator anim;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        
        if (isWalking)
        {
            agent.speed = maxSpeed / 2;
        }
        else
        {
            agent.speed = maxSpeed;
        }
    }

    void Update()
    {
        dist = Vector3.Distance(target.position, transform.position);


        if (dist <= agent.stoppingDistance)
        {
            anim.Play("attack", 1);
        }
        agent.SetDestination(target.position);

        

        if (anim != null)
        {
            anim.SetFloat("velocity", agent.velocity.magnitude / maxSpeed);
        }
    }

    public void Death()             
    {
        agent.speed = 0f;
        anim.SetTrigger("dying");       // Vihollinen kuolee animaatio-triggeri menee päälle

    }

    public void StartAttack()
    {
        transform.LookAt(target);       // Vihollinen katsoo sinua päin kun hyökkää
        Collider[] colliders = Physics.OverlapSphere(attackPos.position, radius);
        foreach (var col in colliders)
        {
            if(col.GetComponent<Player>())
            {
                DoDamage();
                break;
            }
        }
    }

    public void DoDamage()
    {
        FindObjectOfType<Player>().TakeDamage(15);          // DAMAGE PELAAJALLE
        Debug.Log("Tehty damagea!");
        
    }

    void OnDrawGizmosSelected()                             // Vihollisen hyökkäys-gizmot
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, radius);
    }
}
