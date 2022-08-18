using UnityEngine;

public class RotationWorld : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        gameObject.transform.Rotate(0, 0, _speed * Time.deltaTime);
    }
}
