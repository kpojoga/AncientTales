using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float radius = 6f;
    [SerializeField] private float maxDistanseToEnemy;
    [SerializeField] private AudioClip jumpClip;
    private AudioSource audioSource;

    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float yCorrection;

    private GameObject closestEnemy;

    void Awake()
    {
        GlobalEventManager.OnNextPointMove.AddListener(MoveToNextPoint);
        GlobalEventManager.OnEnemyKill.AddListener(KillingEnemySequence);
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if(enemy != null)
        {
            GlobalEventManager.SendFinishGame(false);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, radius);
    //}

    private void MoveToNextPoint()
    {
        audioSource.PlayOneShot(jumpClip);
    }
    private void KillingEnemySequence()
    {
        FindTarget();
    }
    private void FindTarget()
    {
        var enemies = FindObjectsOfType<Enemy>();

        if (enemies.Length <= 0)
        {
            GlobalEventManager.SendNextPointMove();
            return;
        }

        closestEnemy = null;
        var minDist = float.MaxValue;

        foreach (Enemy enemy in enemies)
        {
            var dist = Vector3.Distance(enemy.gameObject.transform.position, transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closestEnemy = enemy.gameObject;
            }
        }
        if (minDist > Level.Instance.CurrentStageRadius)
        {
            GlobalEventManager.SendNextPointMove();
            StartCoroutine(MoveToNextPointCoroutine());
            return;
        }
        ChangeCameraLook();
    }
    private void Shoot()
    {
        Vector3 tapPosition = Input.mousePosition;
        tapPosition.z = 2;

        Vector3 rayA = Camera.main.transform.position;
        Vector3 rayB = Camera.main.ScreenToWorldPoint(tapPosition);
        Vector3 rayDirection = rayB - rayA;

        rayDirection.y += yCorrection;

        rayDirection = rayDirection.normalized;

        Instantiate(arrowPrefab, shootPoint.position, Quaternion.LookRotation(rayDirection));
    }
    
    private IEnumerator MoveToNextPointCoroutine()
    {
        print("MoveToNextPointCoroutine");
        
        Transform activeCamera = Level.Instance.GetActiveCamera().transform;
        Camera.main.transform.LookAt(activeCamera);

        yield return new WaitForSeconds(2f);
        ChangeCameraLook();
    }
    private void ChangeCameraLook()
    {
        if (closestEnemy != null)
        {
            Level.Instance.GetActiveCamera().LookAt = closestEnemy.transform;
        }
    }
}
