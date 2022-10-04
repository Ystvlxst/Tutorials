using System;
using System.Collections;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private Animator _animator;

    public event Action Shooted;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        _animator.SetTrigger("Shot");
        yield return new WaitForSeconds(0.5f);
        _shotEffect.Play();
        Shooted?.Invoke();
    }
}
