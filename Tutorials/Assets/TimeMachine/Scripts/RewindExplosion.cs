using System.Collections;
using UnityEngine;

public class RewindExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;

    private void Start()
    {
        _explosion.randomSeed = 1;
    }

    public void PlayExplosion()
    {
        _explosion.Play();
    }

    public void Rewind()
    {
        float time = Mathf.Clamp(_explosion.time - Time.deltaTime, 0, _explosion.main.duration);

        _explosion.Simulate(time, true, true);
    }
}
