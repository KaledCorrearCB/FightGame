using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public string text;
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log(text);
        }
    }
}
