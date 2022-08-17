using System.Collections;
using UnityEngine;

public class RewindExplosion : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;

    private float _time;
    private float _elapsedTime;
    private Coroutine _coroutine;

    private void Start()
    {
        _time = _explosion.main.duration;
        _explosion.randomSeed = 1;
    }

    public void PlayExplosion()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Explosion());
    }

    public void Rewind()
    {
        float time = Mathf.Clamp(_time - _elapsedTime, 0, _time);

        _explosion.Simulate(time, true, true);
        _elapsedTime += Time.deltaTime;
    }

    private IEnumerator Explosion()
    {
        float elapsedTime = _elapsedTime;

        while(elapsedTime < _explosion.main.duration)
        {
            elapsedTime += Time.deltaTime;
            _explosion.Simulate(elapsedTime, true, true);
            yield return null;
        }
    }
}
