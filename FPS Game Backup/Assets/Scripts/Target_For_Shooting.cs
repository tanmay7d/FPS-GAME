﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_For_Shooting : MonoBehaviour
{
    public float health = 100f;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
