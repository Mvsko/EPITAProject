using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;    // Transform de la cible à attaquer
    public int unitDamage;               // Dégâts infligés par cette unité

    public List<Collider> targetsCollider = new List<Collider>();
    
    // Méthode appelée lorsque le collider de cet objet entre en collision avec un regiment

    //GISMO POUR l'IA
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'autre collider n'appartient pas à la même équipe
        if (gameObject.transform.GetComponent<Regiment>().IAEnabled && other.gameObject.layer == LayerMask.NameToLayer("Clickable") && other.tag!=gameObject.tag && targetToAttack == null)
        {
            if(targetsCollider.Contains(other)==false)
            {
                targetsCollider.Add(other);
            }


            Debug.Log("OnTriggerEnter");
            targetToAttack = other.transform;
        }
    }

    // Méthode appelée lorsque le collider de cet objet cesse de rentrer en contact avec un autre collider
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        
        Debug.Log($"{other.tag!=gameObject.tag }{targetToAttack != null}");
        if (other.tag!=gameObject.tag && targetToAttack != null && gameObject.transform.GetComponent<Regiment>().IAEnabled )
        {
            targetToAttack = null;
            targetsCollider.Clear();
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
