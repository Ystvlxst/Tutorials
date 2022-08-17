using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TimeBody : Rewindable
{
	private List<PointInTime> _pointsInTime;

	private Rigidbody _rigidBody;

	private void Start()
	{
		_pointsInTime = new List<PointInTime>();
		_rigidBody = GetComponent<Rigidbody>();
	}

    public override void Record()
    {
		_rigidBody.isKinematic = false;
		_pointsInTime.Add(new PointInTime(transform.position, transform.rotation));
	}

    public override void Rewind()
    {
		if (_pointsInTime.Count > 0)
		{
			_rigidBody.isKinematic = true;
			PointInTime pointInTime = _pointsInTime[_pointsInTime.Count - 1];
			transform.position = pointInTime._position;
			transform.rotation = pointInTime._rotation;
			_pointsInTime.RemoveAt(_pointsInTime.Count - 1);
		}
	}
}