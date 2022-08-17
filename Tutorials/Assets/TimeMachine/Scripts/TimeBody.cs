using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
	[SerializeField] private RewindExplosion _explosion;

	private bool _isRewinding = false;
	private float _recordTime = 5f;

	private List<PointInTime> _pointsInTime;
	private Rigidbody _rigidBody;

	private void Start()
	{
		_pointsInTime = new List<PointInTime>();
		_rigidBody = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
			StartRewind();
		if (Input.GetMouseButtonUp(0))
			StopRewind();
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
		_rigidBody.isKinematic = true;
	}

	public void StopRewind()
	{
		_isRewinding = false;
		_rigidBody.isKinematic = false;
	}

	private void Record()
	{
		_pointsInTime.Add(new PointInTime(transform.position, transform.rotation));
	}


	private void Rewind()
	{
		if (_pointsInTime.Count > 0)
		{
			_explosion.Rewind();
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