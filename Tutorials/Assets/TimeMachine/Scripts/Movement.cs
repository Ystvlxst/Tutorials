using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _speed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = Vector3.forward * _speed * Time.deltaTime;
        }
    }
}
