using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RegimentFollowState : StateMachineBehaviour
{
    AttackController attackController;

    NavMeshAgent agent;
    
    public float attackingMeleeDistance;
    public float attackingRangeDistance;
    private float FollowTime = 2f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       attackController =  animator.GetComponent<AttackController>();
       agent = animator.GetComponent<NavMeshAgent>();
       attackingMeleeDistance = 2.5f;

        attackingRangeDistance = animator.gameObject.GetComponent<Regiment>().unit.model.attackingRangeDistance;

       
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // Should Regiment Teansition to Idle State ?

       if (attackController.targetToAttack == null)
       {
        //Debug.Log("Idle State");
        animator.SetBool("IsFollowing", false);
       }
       else
       {        

        // If there is no other direct command
        if(animator.transform.GetComponent<RegimentMovement>().isCommandedToMove == false && attackController.targetToAttack != null)
        {
        // Moving Regiment Towards Enemy
            if (FollowTime <= 0)
            {
            agent.SetDestination(attackController.targetToAttack.position);
            FollowTime = 2f;
            }
            else
            {
            FollowTime -= Time.deltaTime;
            }
            
            animator.transform.LookAt(attackController.targetToAttack);

            //Should Regiment Transition to Attack State ?
            float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
            if (distanceFromTarget <= attackingMeleeDistance || distanceFromTarget <= attackingRangeDistance)
            {
                //Debug.Log("ATTACK State ");
                agent.SetDestination(animator.transform.position);
                animator.SetBool("IsAttacking",true);
            }
        }
        
        /*
        //Should Regiment Transition to Attack State ?
        if( attackController.targetToAttack != null)
        {
            float distanceFromTarget = Vector3.Distance(attackController.targetToAttack.position, animator.transform.position);
            
            if (distanceFromTarget <= attackingDistance)
            {
                Debug.Log("ATTACK");
                agent.SetDestination(animator.transform.position);
                animator.SetBool("IsAttacking",true);
            }
            else{
                Debug.Log(distanceFromTarget);
            }
            }
        */
       }
       

        

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
      // agent.SetDestination(animator.transform.position);
    //}

    
}
