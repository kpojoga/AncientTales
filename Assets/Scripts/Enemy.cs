using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
     [SerializeField] private float hp = 1f;
     [SerializeField] private int reward = 3;
     [SerializeField] private GameObject deathEffect;
   
    public void GetDamage(float damage)
    {
        if (damage <= 0) return;
        hp -= damage;
        if(hp <= 0)
        {
            // death
            Level.Instance.AddReward(reward);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GlobalEventManager.SendEnemyKill();
        }
    }
}
