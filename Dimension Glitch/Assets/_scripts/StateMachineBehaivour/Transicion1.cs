using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transicion1 : StateMachineBehaviour
{
    private PlayerAttack attack;
    private FightingController fight;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Obtener las referencias del jugador correcto
        attack = animator.GetComponent<PlayerAttack>();
        fight = animator.GetComponent<FightingController>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (attack.atacando)
        {
            attack.anim.SetTrigger("Atack2");
            Debug.Log(attack.atacando);

            attack.damage -= 2;
            fight.moveSpeed = 0f;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attack.atacando = false;
        attack.damage = 0;

        attack.anim.ResetTrigger("Atack1");
    

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
