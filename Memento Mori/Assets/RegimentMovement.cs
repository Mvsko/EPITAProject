using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class RegimentMovement : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;
    public LayerMask ground;


    private void Start()
    {
        cam = Camera.main;  // Camera principale

        // initialisation de l'ia pour le pathfinding
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            //Si le raycast arrive au sol :
           if(Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
           {
            agent.SetDestination(hit.point);
           } 
        }
    }
}
