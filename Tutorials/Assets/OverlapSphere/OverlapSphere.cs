using UnityEngine;

public class OverlapSphere : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radiusDamage;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem _explodeEffect;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusDamage, _layerMask);

        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent(out Oil oil))
            {
                _explodeEffect.Play();
                _animator.SetTrigger("ARR");
                oil.Explode();
                Vector3 direction = (collider.transform.position - transform.position).normalized;
                oil.Rigidbody.AddForce(direction * _force, ForceMode.Impulse);
            }
        }
    }
}
