using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;    // Transform de la cible à attaquer
    public int unitDamage;               // Dégâts infligés par cette unité
    
    // Méthode appelée lorsque le collider de cet objet entre en collision avec un regiment
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(gameObject.tag);
        Debug.Log(other.tag);

        // Vérifie si l'autre collider n'appartient pas à la même équipe
        if (other.CompareTag(gameObject.tag)!=true && targetToAttack == null)
        {
            targetToAttack = other.transform;
        }
    }

    // Méthode appelée lorsque le collider de cet objet cesse de colliser avec un autre collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(gameObject.tag) && targetToAttack != null)
        {
            targetToAttack = null;
        }
    }
    // Méthode appelée lors du dessin de gizmos dans l'éditeur
    private void OnDrawGizmos()
    {
       // Gismos de suivi (Follow)
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, 5f);
       // Gismos d'attaque (Attack)
        Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, 2.5f);
       // Gismos de fin d'attaque (Attack Stop)
       Gizmos.color = Color.blue;
       Gizmos.DrawWireSphere(transform.position, 3f);
    }
}
