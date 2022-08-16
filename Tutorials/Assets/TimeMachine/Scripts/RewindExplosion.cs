using UnityEngine;

public class RewindExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;

    private float _time;
    private float _elapsedTime;

    private void Start()
    {
        _time = _explosion.main.duration;
        _explosion.randomSeed = 1;
    }

    public void PlayExplosion()
    {
        _explosion.Play();
    }

    public void Rewind()
    {
        float time = Mathf.Clamp(_time - _elapsedTime, 0, _time);

        _explosion.Simulate(time, true, true);
        _elapsedTime += Time.deltaTime;
    }
}
