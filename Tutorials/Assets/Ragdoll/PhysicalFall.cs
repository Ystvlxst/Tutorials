using UnityEngine;

public class PhysicalFall : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidodies;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _forceImpulse;
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private ParticleSystem _hitEffect;

    private void OnEnable()
    {
        foreach (Rigidbody rigidbody in _rigidodies)
            rigidbody.isKinematic = true;
    }

    public void Hit()
    {
        _boxCollider.enabled = false;
        _hitEffect.Play();

        foreach(Rigidbody rigidbody in _rigidodies)
        {
            rigidbody.isKinematic = false;
            rigidbody.AddForce(Vector3.right * _forceImpulse, ForceMode.Impulse);
        }

        _animator.enabled = false;
    }
}
