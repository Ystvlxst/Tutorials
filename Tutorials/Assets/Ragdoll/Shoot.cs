using System;
using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private ParticleSystem _shotEffect;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private PhysicalFall _physicalFall;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _speed;
    [SerializeField] private TimeController _timeController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shot();
    }

    private void Shot()
    {
        _timeController.DoSlowMotion();
        _shotEffect.Play();
        var bullet = Instantiate(_bullet, _spawnPoint);
        bullet.Rigidbody.AddForce(Vector3.right * _speed, ForceMode.Impulse);
    }
}
