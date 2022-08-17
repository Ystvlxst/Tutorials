using System.Collections.Generic;
using UnityEngine;

public class RewindExplosion : Rewindable
{
    [SerializeField] private ParticleSystem _explosion;

    private List<PointInTime> _pointsInTime;

    private List<float> _time;

    private void Start()
    {
        _pointsInTime = new List<PointInTime>();
        _time = new List<float>();
        _explosion.randomSeed = 1;
    }

    public void PlayExplosion()
    {
        _explosion.Play();
    }

    public override void Record()
    {
        _pointsInTime.Add(new PointInTime(transform.position, transform.rotation));
        _time.Add(_explosion.time);
    }

    public override void Rewind()
    {
        if (_pointsInTime.Count > 0)
        {
            _explosion.Simulate(_time[_time.Count - 1], true, true);
            PointInTime pointInTime = _pointsInTime[_pointsInTime.Count - 1];
            transform.position = pointInTime._position;
            transform.rotation = pointInTime._rotation;
            _pointsInTime.RemoveAt(_pointsInTime.Count - 1);
            _time.RemoveAt(_time.Count - 1);
        }
    }
}