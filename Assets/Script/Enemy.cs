using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health;

    public void TakeDamage(int damge)
    {
        health -= damge;

        if (health < 0)
        {
            Destroy(gameObject);
        }
    }
}
