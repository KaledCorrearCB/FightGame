using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion1 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       if (PlayerAttack.instance.atacando)
        {
            PlayerAttack.instance.anim.SetTrigger("Atack2");
            Debug.Log(PlayerAttack.instance.atacando);
            PlayerAttack.instance.damage -= 2;
            FightingController.instance.moveSpeed = 0;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerAttack.instance.atacando = false;
        PlayerAttack.instance.damage = 0;
        PlayerAttack.instance.anim.ResetTrigger("Atack1");
        
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
}
