using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject pickEffect;
    private void OnTriggerEnter(Collider other)
    {
        Level.Instance.AddKey();
        Instantiate(pickEffect);
        Destroy(gameObject);
    }
}
