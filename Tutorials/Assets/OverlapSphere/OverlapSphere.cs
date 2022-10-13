using UnityEngine;

public class OverlapSphere : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radiusDamage;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ParticleSystem _explosion;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            FindBeingInside();
    }

    private void FindBeingInside()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radiusDamage, _layerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out Rigidbody rigidbody))
            {
                _explosion.Play();

                Vector3 direction = (collider.transform.position - transform.position).normalized;
                rigidbody.AddForce(direction * _force, ForceMode.Impulse);
            }
        }
    }
}
