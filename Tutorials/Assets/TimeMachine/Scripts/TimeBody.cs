using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TimeBody : MonoBehaviour
{
	private List<PointInTime> _pointsInTime;

	private Rigidbody _rigidBody;
	private bool _isRewinding = false;

	private void Start()
	{
		_pointsInTime = new List<PointInTime>();
		_rigidBody = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
		if (_isRewinding)
			Rewind();
		else
			Record();
	}

	public void StartRewind()
	{
		_isRewinding = true;
		_rigidBody.isKinematic = false;
	}

	public void StopRewind()
	{
		_isRewinding = false;
		_rigidBody.isKinematic = true;
	}

	private void Record()
	{
		_pointsInTime.Add(new PointInTime(transform.position, transform.rotation));
	}

	private void Rewind()
	{
		if (_pointsInTime.Count > 0)
		{
			PointInTime pointInTime = _pointsInTime[_pointsInTime.Count -1];
			transform.position = pointInTime._position;
			transform.rotation = pointInTime._rotation;
			_pointsInTime.RemoveAt(_pointsInTime.Count -1);
		}
		else
		{
			StopRewind();
		}
	}
}