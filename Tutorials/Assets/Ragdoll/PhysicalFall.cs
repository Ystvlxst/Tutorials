using System;
using UnityEngine;

public class PhysicalFall : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidodies;
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        foreach (Rigidbody rigidbody in _rigidodies)
            rigidbody.isKinematic = true;
    }

    public void Hit()
    {
        foreach(Rigidbody rigidbody in _rigidodies)
            rigidbody.isKinematic = false;

        _animator.enabled = false;
    }
}
