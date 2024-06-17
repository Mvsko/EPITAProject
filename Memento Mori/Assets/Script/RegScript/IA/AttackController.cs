using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AttackController : MonoBehaviour
{
    public Transform targetToAttack;    // Transform de la cible à attaquer
    public Regiment regiment;
    public int DamageMelee;               // Dégâts infligés par cette unité

    public int DamageDistance; 

    public List<Collider> EnemyCollider = new List<Collider>();
    public List<Collider> AllyCollider = new List<Collider>();
    private List<string> WeakRegimentType = new List<string>(){"Chasseur","Frondeur","Onagre","BalisteRomaine"};
    private List<string> CavRegimentType = new List<string>(){"Equites","Trimarcisia"};
    NavMeshAgent agent;  
    private float timer;


    
    // Méthode appelée lorsque le collider de cet objet entre en collision avec un regiment

    void Start()
    {
        targetToAttack = null;
        agent = GetComponent<NavMeshAgent>();
        timer = 3f;


        
    }
    private void OnTriggerEnter(Collider other)
    {
        DamageMelee  =  regiment.unit.degatMelee; 
        DamageDistance = regiment.unit.degatDistance;

        if(other.gameObject.layer == LayerMask.NameToLayer("Clickable"))
        {
            
            if(other.tag!=gameObject.tag)
            {
                
                if (gameObject.transform.GetComponent<Regiment>().IAEnabled)
                {
                    //Stock en mémoire a court terme l'ennemi
                    EnemyCollider.Add(other);
                    if( targetToAttack == null)
                    {
                        
                        
                        
                        

                        //Si l'ennemi m'attaque
                        if(other.gameObject.transform.GetComponent<AttackController>().targetToAttack == gameObject.transform)
                        {
                            
                            //Contre Attaque
                            if((EnemyCollider.Count <= AllyCollider.Count+1||other.gameObject.transform.GetComponent<Regiment>().unit.degatMelee < regiment.unit.degatMelee)
                             && WeakRegimentType.Contains(regiment.typeRegiment)==false)
                            {
                                Debug.Log("Contre Attack");
                                agent.SetDestination(transform.position) ;
                                targetToAttack = other.transform;

                            }

                            //Battre en retraitre
                            else
                            {
                                Debug.Log("Retraitre");
                                targetToAttack = null;
                                Vector3 getback = (other.transform.position-transform.position);
                                if(getback != null)
                                {
                                    agent.SetDestination(transform.position - getback);
                                }
                            }
                        }
                        
                        //Passe à l'attaque ou contre Attack
                        else
                        { 
                            
                            //Attaque en cas de majorité à proximité
                            if(EnemyCollider.Count <= AllyCollider.Count+2)
                            {
                                Debug.Log("Attaquer");
                                targetToAttack = other.transform;
                            }
                        }
                    }

                    else
                    {       
                        if(WeakRegimentType.Contains(targetToAttack.gameObject.transform.GetComponent<Regiment>().typeRegiment)== false &&
                            WeakRegimentType.Contains(other.gameObject.transform.GetComponent<Regiment>().typeRegiment)&&
                            targetToAttack.gameObject.transform.GetComponent<AttackController>().targetToAttack != gameObject.transform)
                        {
                            Debug.Log("Attaquer Un Choix");
                            targetToAttack = other.transform;
                        }
                    }
                }
                    
            }

            else
            {

                if(AllyCollider.Contains(other)==false)
                {
                    AllyCollider.Add(other);
                }
            }
        }
        
    }

    // Méthode appelée lorsque le collider de cet objet cesse de rentrer en contact avec un autre collider
    private void OnTriggerExit(Collider other)
    {
        //Si l'ennemi va plus vite, l'IA abandonne la course poursuite
        
        if(other.gameObject.layer == LayerMask.NameToLayer("Clickable")&& gameObject.transform.GetComponent<Regiment>().IAEnabled)
        {
            
            if(other.tag!=gameObject.tag)
            {
                EnemyCollider.Remove(other);
                
                //Stop l'attaque
                if(targetToAttack == other.transform)
                {
                    targetToAttack = null;
                }

                //En potition de force
                if(AllyCollider.Count > EnemyCollider.Count &&  other.gameObject.transform.GetComponent<Regiment>().regimentHealth > regiment.regimentHealth )
                {
                    Debug.Log("Tente de ratraper le regiment");
                    agent.SetDestination(other.transform.position +  (transform.position-other.transform.position));
                }
                    
            }
            else
            {
                AllyCollider.Remove(other);
                //Tente de rallier les autres regimetns
                if(AllyCollider.Count == 0 && (CavRegimentType.Contains(regiment.typeRegiment) == false || CavRegimentType.Contains(other.gameObject.transform.GetComponent<Regiment>().typeRegiment)))
                {
                    Debug.Log("Tente de rallier un ami");
                    agent.SetDestination(other.transform.position);
                }
            }
            
        
        }
        
    }

    void Update()
    {
        if(timer<=0f)
        {
            if(EnemyCollider.Count > 2 && targetToAttack == null)
            {
                int i = 0;
                while(i<EnemyCollider.Count && i <2)
                {
                    if(EnemyCollider[i]== null)
                    {
                        EnemyCollider.RemoveAt(i);
                    }
                    i+=1;
                }
                if(EnemyCollider[0]!= null &&EnemyCollider[0].gameObject.layer ==  LayerMask.NameToLayer("Clickable"))
                {
                    targetToAttack= EnemyCollider[0].transform;
                }
                else
                {
                    if(EnemyCollider[1]!= null&&EnemyCollider[1].gameObject.layer ==  LayerMask.NameToLayer("Clickable"))
                    {
                        targetToAttack= EnemyCollider[1].transform;
                    }
                }
                
            }
            timer = 3f;
        }
        else
        {
            timer -=Time.deltaTime;
        }
    }
    // Méthode appelée lors du dessin de gizmos dans l'éditeur
    private void OnDrawGizmos()
    {
       // Gismos de suivi (Follow)
       Gizmos.color = Color.yellow;
       Gizmos.DrawWireSphere(transform.position, 10f);
       // Gismos d'attaque (Attack)
        Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(transform.position, 2.5f);
       // Gismos de fin d'attaque (Attack Stop)
       Gizmos.color = Color.blue;
       Gizmos.DrawWireSphere(transform.position, 3f);

        // Gismos d'attaque à Distance
       if(regiment.unit.degatDistance > 0)
       {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, regiment.unit.attackingRangeDistance);
       }
    }
}
