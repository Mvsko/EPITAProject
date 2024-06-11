using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using JetBrains.Annotations;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class RegimentMovement : MonoBehaviour
{
    Camera cam;                 // Référence à la caméra principale
    NavMeshAgent agent;         // Référence à l'agent de navigation
    public LayerMask ground;       // Masque de collision pour le sol
    //bool formation;

    private RaycastHit hitInfoDown;
    private RaycastHit hitInfoUp;
    
    // Variables pour déterminer si le régiment est commandé de bouger et quel type de mouvement il doit effectuer
    public bool isCommandedToMove;
    public RegimentSelectionManager.mouvementTypeList mouvementTypeRegiment;

    private void Start()
    {
        mouvementTypeRegiment = RegimentSelectionManager.mouvementTypeList.Line;
        
        cam = Camera.main;  // Camera principale
        //formation = false;

        // initialisation de l'ia pour le pathfinding
        agent = GetComponent<NavMeshAgent>(); 
    }
    public void AIMovement(UnityEngine.Vector3 vector)
    {
        agent.SetDestination(vector);
    }
    private void Update()
    {
        // Si le joueur clique avec le bouton droit de la souris
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            int regimentselectnumber = RegimentSelectionManager.Instance.regimentsSelected.Count;

            //Si le raycast arrive au sol :
           if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
           {
            isCommandedToMove = true;

            if (regimentselectnumber > 1)
            {
                mouvementTypeRegiment = RegimentSelectionManager.Instance.MouvementTypeGet();

                for (int i = 0; i < regimentselectnumber; i++)
                {
                    if (RegimentSelectionManager.Instance.regimentsSelected[i] == gameObject)
                    {

                        float horizontalInput = Input.GetAxis("Horizontal");
                        float verticalInput = Input.GetAxis("Vertical");
                        // Détermine le mouvement en fonction du type de formation choisi
                        if (mouvementTypeRegiment is RegimentSelectionManager.mouvementTypeList.Line)
                        {
                            //le regiment se place en fontion de la direction de la camera en ligne
                            agent.SetDestination(hit.point + cam.transform.right* 4 * i );
                        }

                        if(mouvementTypeRegiment is RegimentSelectionManager.mouvementTypeList.DoubleLine)
                        {
                            //Le regiment se place en une formation manipule
                            int milieu = regimentselectnumber/2;
                            if (i<milieu)
                            {
                                agent.SetDestination(hit.point + cam.transform.right* 4 * i );
                            }
                            else
                            {
                                agent.SetDestination(hit.point + cam.transform.right* 4 * (i-milieu) + cam.transform.forward*3 );
                            }
                            
                        }

                        if(mouvementTypeRegiment is RegimentSelectionManager.mouvementTypeList.Colonne)
                        {
                            agent.SetDestination(hit.point - cam.transform.forward*3*i );
                        }

                        if(mouvementTypeRegiment is RegimentSelectionManager.mouvementTypeList.Triangle)
                        {
                            int rang1 = i;
                            int rang2 = i;
                            if(i%2==0 && i > 0)
                            {
                                rang2 = -i+1;
                                rang1 = i-1;
                            }
                            agent.SetDestination(hit.point - cam.transform.forward*3*rang1 + cam.transform.right*3*rang2 );
                        }

                        if(mouvementTypeRegiment is RegimentSelectionManager.mouvementTypeList.Cercle)
                        {
                            
                            float angle = (360f / regimentselectnumber)*i;
                            UnityEngine.Vector3 compenser = new UnityEngine.Vector3(3f * Mathf.Cos(angle * Mathf.Deg2Rad), 0f, 3f * Mathf.Sin(angle * Mathf.Deg2Rad));
                            agent.SetDestination(hit.point + compenser*(regimentselectnumber/4) );
                        }

                    
                        // Oriente le régiment dans la direction de la caméra
                        agent.updateRotation = true;
                        agent.transform.rotation = cam.transform.rotation;
                        agent.updateRotation = false;
                         
                        
                        
                    }
                }
            }
            else
            {
                // Déplace un seul régiment vers le point cliqué
                agent.updateRotation = true;
                agent.SetDestination(hit.point);
                isCommandedToMove = false;
                
            }
            
           } 

        }
        // Si le régiment n'a pas de chemin ou s'il est à destination, il n'est plus commandé de bouger
        if(agent.hasPath == false || agent.remainingDistance <= agent.stoppingDistance)
        {
            isCommandedToMove = false;
        }
        
    }
}
