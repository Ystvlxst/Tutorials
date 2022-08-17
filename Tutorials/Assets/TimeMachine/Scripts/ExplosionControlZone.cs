using UnityEngine;

public class ExplosionControlZone : MonoBehaviour
{
    [SerializeField] private RewindExplosion _explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TimeBody timeBody))
        {
            _explosion.PlayExplosion();
            gameObject.SetActive(false);
        }
    }
}
