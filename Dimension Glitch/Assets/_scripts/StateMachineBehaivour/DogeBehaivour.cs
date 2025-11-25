using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DogeBehaivour : StateMachineBehaviour

{
    private int Count = 0;
    private bool canMove = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAttack.instance.StartCoroutine(EsperarMedioSegundo());
        PlayerAttack.instance.DogeEfect();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (canMove && Count < 1)
        {
            Vector3 dogeDirection = FightingController.instance.transform.forward * PlayerAttack.instance.distanceDoge;
            FightingController.instance.controller.Move(dogeDirection);
            Count++;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Count = 0;
        PlayerAttack.instance.anim.ResetTrigger("Doge");
        canMove = false;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}


    IEnumerator EsperarMedioSegundo()
    {
        yield return new WaitForSeconds(0.2f);
        canMove = true;
    }


}
