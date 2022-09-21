using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Oil : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explode;

    private Rigidbody _rigidbody;

    public Rigidbody Rigidbody => _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Explode()
    {
        _explode.Play();
    }
}
