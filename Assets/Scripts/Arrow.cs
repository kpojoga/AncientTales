using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float force = 10f;
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Destroy(gameObject, 5f);
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null) return;
        enemy.GetDamage(damage);
        Destroy(gameObject);
    }
}
