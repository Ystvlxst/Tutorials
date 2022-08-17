using System.Collections.Generic;
using UnityEngine;

public class TimeBodyRoot : MonoBehaviour
{
    [SerializeField] private List<Rewindable> _rewindables;

    private int _mouseButton = 0;
    private bool _isRewinding = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
            _isRewinding = true;

        if (Input.GetMouseButtonUp(_mouseButton))
            _isRewinding = false;
    }

    private void FixedUpdate()
    {
        if (_isRewinding)
            Rewind();
        else
            Record();
    }

    private void Rewind()
    {
        foreach (var timeBody in _rewindables)
            timeBody.Rewind();
    }

    private void Record()
    {
        foreach (var timeBody in _rewindables)
            timeBody.Record();
    }
}
