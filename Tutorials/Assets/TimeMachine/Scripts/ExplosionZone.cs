using UnityEngine;

public class ExplosionZone : MonoBehaviour
{
    [SerializeField] private RewindExplosion _rewindExplosion;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player timeBody))
        {
            _rewindExplosion.PlayExplosion();
            gameObject.SetActive(false);
        }
    }
}
