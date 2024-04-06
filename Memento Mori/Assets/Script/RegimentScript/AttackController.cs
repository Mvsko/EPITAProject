using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;
    
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
}
