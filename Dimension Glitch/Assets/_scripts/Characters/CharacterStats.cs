using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHP = 100;
    public int HP;

    PlayerAttack pa;


    private void Start()
    {
        HP = maxHP;
        pa = GetComponent<PlayerAttack>();
    }

    public void ReceiveDamage(int amount)
    {
        
        bool blocking = pa != null && pa.isBlocking;
        int finalDamage = amount;

        // Si está bloqueando → reducir daño
        if (blocking)
        {
            finalDamage = Mathf.FloorToInt(amount * 0.3f); // 70% reducción
            Debug.Log(" Bloqueo! Daño reducido de " + amount + " a " + finalDamage);
        }

        HP -= finalDamage;

        // activar animación de recibir golpe
        if (!blocking)
        {
            GetComponent<Animator>().SetTrigger("Hit");
            FightingController.instance.golpeado = true;
        }
        else
        {
            // si está bloqueando, no entra golpeado
            FightingController.instance.golpeado = false;
        }
        Debug.Log(gameObject.name + " recibió " + amount + " daño. HP = " + HP);
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " murió.");
        GetComponent<Animator>().SetTrigger("KO");
    }

}
