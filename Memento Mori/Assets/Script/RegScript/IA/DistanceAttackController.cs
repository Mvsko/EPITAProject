using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DistanceAttackController : MonoBehaviour
{
    public Transform targetToAttack;    // Transform de la cible à attaquer
    public Regiment regiment;
    public int DamageDistance;               // Dégâts infligés par cette unité

    NavMeshAgent agent;  

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.parent.GetComponent<NavMeshAgent>();
        targetToAttack = transform.parent.GetComponent<AttackController>().targetToAttack;
    }

}
