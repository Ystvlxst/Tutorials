using UnityEngine;

public class PhysicalFall : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidodies;
    [SerializeField] private Shot _shot;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _forceImpulce;
    [SerializeField] private ParticleSystem _hitEffect;

    private void OnEnable()
    {
        foreach (Rigidbody rigidbody in _rigidodies)
            rigidbody.isKinematic = true;

        _shot.Shooted += Hit;
    }

    private void OnDisable()
    {
        _shot.Shooted -= Hit;
    }

    private void Hit()
    {
        foreach(Rigidbody rigidbody in _rigidodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(Vector3.forward * _forceImpulce, ForceMode.Impulse);
        }
        _animator.enabled = false;
        _hitEffect.Play();
    }
}
