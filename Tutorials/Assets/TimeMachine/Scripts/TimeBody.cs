using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBody : MonoBehaviour
{
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
		if (Input.GetKeyDown(KeyCode.Return))
			StartRewind();
		if (Input.GetKeyUp(KeyCode.Return))
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
		if (_pointsInTime.Count > Mathf.Round(_recordTime / Time.fixedDeltaTime))
		{
			_pointsInTime.RemoveAt(_pointsInTime.Count - 1);
		}

		_pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
	}


	private void Rewind()
	{
		if (_pointsInTime.Count > 0)
		{
			PointInTime pointInTime = _pointsInTime[0];
			transform.position = pointInTime._position;
			transform.rotation = pointInTime._rotation;
			_pointsInTime.RemoveAt(0);
		}
		else
		{
			StopRewind();
		}

	}
}