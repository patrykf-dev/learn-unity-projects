﻿using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    private UnityEngine.AI.NavMeshAgent nav;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
        nav.SetDestination(player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
