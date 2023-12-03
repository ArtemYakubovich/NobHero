using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _animator;
    
    private Vector2 _moveInput;

    private void Update()
    {
        _moveInput = _joystick.Value;
        _animator.SetBool("Run", _joystick.IsPressed);
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_moveInput.x, 0f, _moveInput.y) * _speed * Time.fixedDeltaTime;

        if (_rigidbody.velocity != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
        }
    }
}
