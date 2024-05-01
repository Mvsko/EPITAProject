using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;
    public int unitDamage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(gameObject.tag)!=true && targetToAttack == null)
        {
            targetToAttack = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(gameObject.tag) && targetToAttack != null)
        {
            targetToAttack = null;
        }
    }

    private void OnDrawGizmos()
    {
       // Gismos Follow
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, 5f);
       // Gismos Attack
        Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, 2.5f);
       // Gismo Attack Stop
       Gizmos.color = Color.blue;
       Gizmos.DrawWireSphere(transform.position, 3f);
    }
}
