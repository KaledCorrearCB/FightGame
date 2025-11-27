using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public int damage = 10;
    public string targetTag = "Player";

    private List<Collider> alreadyHit = new List<Collider>();
    private bool active = false;
    [HideInInspector] public GameObject owner;


    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if (other.gameObject == owner) return;

        if (alreadyHit.Contains(other)) return;

        CharacterStats stats = other.GetComponent<CharacterStats>();
        if (stats != null)
        {
            Debug.Log(owner.name + " golpeó a " + other.name);
            stats.ReceiveDamage(damage);
            alreadyHit.Add(other);
        }
    }

    public void Activate()
    {
        active = true;
        alreadyHit.Clear();
        Debug.Log("HITBOX ACTIVADA");
    }

    public void Deactivate()
    {
        Debug.Log("HITBOX DESACTIVADA");
        active = false;
    }
}
