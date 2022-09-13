using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private float _speed = 10;

    private NavMeshAgent _agent;
    private float _speedRate;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _speedRate = 1;
    }

    private void Update()
    {
        var shift = new Vector3(_joystick.Direction.x, 0, _joystick.Direction.y);
        _agent.SetDestination(transform.position + -shift.normalized);

        _agent.speed = _speed * _speedRate;

    }
}
