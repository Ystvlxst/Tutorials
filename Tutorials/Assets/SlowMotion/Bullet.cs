using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public Rigidbody Rigidbody { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PhysicalFall physicalFall))
        {
            physicalFall.Hit();
            Destroy(gameObject);
        }
    }
}
