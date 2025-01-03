using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RegimentAttackState : StateMachineBehaviour
{

    NavMeshAgent agent;

    AttackController attackController;

    public float stopAttackingDistance;
    public float stopAttackingRangeDistance;

    public float attackRate = 2f;
    private float attackTimer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       stopAttackingDistance = 3f;

      stopAttackingRangeDistance = animator.gameObject.GetComponent<Regiment>().unit.model.attackingRangeDistance;
      if (stopAttackingDistance > 0)
      {
         stopAttackingRangeDistance+=1f;
      }
       
       agent = animator.GetComponent<NavMeshAgent>();
       attackController = animator.GetComponent<AttackController>();
      agent.SetDestination(animator.transform.position);
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
      if(animator.transform.GetComponent<RegimentMovement>().isCommandedToMove == true)
      { 
         //Debug.Log("IDLE State ");
         animator.SetBool("IsAttacking",false);
      }

       if(animator.transform.GetComponent<RegimentMovement>().isCommandedToMove == false && attackController != null && attackController.targetToAttack != null)
       {
         
         LookatTarget();
         
         float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);

         // Reste en mvt vers l'ennemi
         /*
         if(animator.GetComponent<Regiment>().dead == false && stopAttackingRangeDistance == 0)
         {
            Vector3 mid = (attackController.targetToAttack.transform.position-animator.transform.position);
            agent.SetDestination(animator.transform.position + mid);
         }
         */
         
         
         
         if (attackTimer <= 0)
         {
            if(distanceFromTarget < stopAttackingDistance) 
            {
               Debug.Log("MeleeAttack");
               MeleeAttack(animator);

            }
            else
            {
               Debug.Log("RangeAttack");
               RangeAttack(animator);
               
            }
            attackTimer = 10f/attackRate;
            
            
         }
         else
         {
            
            attackTimer -= Time.deltaTime;
         }

         // Should unit still attack state
         
         
            
         if ((distanceFromTarget >= stopAttackingDistance && distanceFromTarget >= stopAttackingRangeDistance) || attackController == null  )
         {
            //Debug.Log("Follow State ");
            animator.SetBool("IsAttacking",false);
         }
      }
   }

   private void MeleeAttack(Animator animator)
   {
      var damageToInflict = animator.GetComponent<Regiment>().unit.degatMelee;
      // Actually Attack Unit
      attackController.targetToAttack.GetComponent<Regiment>().TakeDamage(damageToInflict);
   }

   private void RangeAttack(Animator animator)
   {
      var damageToInflict = animator.GetComponent<Regiment>().unit.degatDistance;
      // Actually Attack Unit
      attackController.targetToAttack.GetComponent<Regiment>().TakeDamage(damageToInflict);
   }


    private void LookatTarget()
    {
        Vector3 direction = attackController.targetToAttack.position - agent.transform.position;
        agent.transform.rotation = Quaternion.LookRotation(direction);

        var yRotation = agent.transform.eulerAngles.y;
      agent.transform.rotation = Quaternion.Euler(0,yRotation,0);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
