using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHP = 100;
    public int HP;

    private void Start()
    {
        HP = maxHP;
    }

    public void ReceiveDamage(int amount)
    {
        HP -= amount;

        Debug.Log(gameObject.name + " recibió " + amount + " daño. HP = " + HP);

        if (HP <= 0)
        {
            HP = 0;
            Die();
        }

        // activar animación de recibir golpe
        GetComponent<Animator>().SetTrigger("Hit");
        FightingController.instance.golpeado = true;
        Debug.Log(gameObject.name + " recibió " + amount + " daño. HP = " + HP);
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " murió.");
        GetComponent<Animator>().SetTrigger("KO");
    }
}
