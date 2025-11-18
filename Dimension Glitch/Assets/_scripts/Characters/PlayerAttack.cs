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



}
