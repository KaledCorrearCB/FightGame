using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DogeBehaivour : StateMachineBehaviour

{
    private int count = 0;
    private bool canMove = false;

    private PlayerAttack attack;
    private FightingController fight;
    private MonoBehaviour runner;   // Para ejecutar la coroutine correctamente

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Obtener referencias del jugador correcto
        attack = animator.GetComponent<PlayerAttack>();
        fight = animator.GetComponent<FightingController>();
        runner = animator.GetComponent<MonoBehaviour>();

        // Efecto de dodge
        attack.DogeEfect();

        // Iniciar coroutine (NO USAR singletons)
        runner.StartCoroutine(EsperarMedioSegundo());

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (canMove && count < 1)
        {
            Vector3 dogeDir = fight.transform.forward * attack.distanceDoge;
            fight.controller.Move(dogeDir);

            count++;
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        count = 0;
        canMove = false;

        // Restaurar trigger (en el jugador correcto)
        attack.anim.ResetTrigger("Doge");
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
