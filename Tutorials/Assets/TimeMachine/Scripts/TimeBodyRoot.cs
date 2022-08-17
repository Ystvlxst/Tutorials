using System.Collections.Generic;
using UnityEngine;

public class TimeBodyRoot : MonoBehaviour
{
    [SerializeField] private List<TimeBody> _timeBodies;

    private int _mouseButton = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(_mouseButton))
            StartRewind();

        if (Input.GetMouseButtonUp(_mouseButton))
            StopRewind();
    }

    private void StartRewind()
    {
        foreach (var timeBody in _timeBodies)
            timeBody.StartRewind();
    }

    private void StopRewind()
    {
        foreach (var timeBody in _timeBodies)
            timeBody.StopRewind();
    }
}
