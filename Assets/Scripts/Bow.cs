using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float yCorrection;

    private bool canShoot = true;
    private void Awake()
    {
        GlobalEventManager.OnFinishGame.AddListener(FinishSequence);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
        }
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

    private void FinishSequence(bool isWin)
    {
        canShoot = false;
    }
}
