using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public Animator anim;
    public bool atacando = false;
    public static PlayerAttack instance;
    public string text;
    public int damage = 0;
    public float distanceDoge = 2f;

    [Header("Efectos y sonidos")]
    public ParticleSystem efectoAtaque1;
    public ParticleSystem efectoDoge;
    public ParticleSystem efectoBlock;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    public void Update()
    {
        
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started && !atacando)
        {
            atacando = true;
            Debug.Log(atacando);
        }
    }

    public void Block(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            anim.SetBool("isBlocking",true);
            Debug.Log("defendiendo");
            FightingController.instance.moveSpeed = 0;
        }

        if (context.canceled)
        {
            anim.SetBool("isBlocking", false);
        }

    }

    public void DogeFront(InputAction.CallbackContext context)
    {

        if (context.started)
        {
            anim.SetTrigger("Doge");

        }


    }

    public void AtackEfect()
    {
        if (efectoAtaque1 != null)
        {
            efectoAtaque1.Play();
        }
    }

    public void DogeEfect()
    {
        efectoDoge.Play();
    }


    public void BlockEfect()
    {
        efectoBlock.Play();
    }

    public void BlockEfectStop()
    {
        efectoBlock.Stop();
    }
}
