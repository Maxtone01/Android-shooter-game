using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerScript _playerScript;

    public float _speed;

    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    private bool _isMoving = true;

    public Camera _camera;
    public Joystick _joystick;

    private void Update()
    {
        if (_isMoving)
        {
            _moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);
            _moveVelocity = _moveInput.normalized * _speed;

            float _rotateY = 0f;
            if (_moveInput.x < 0)
            {
                _rotateY = 180f;
            }
            transform.eulerAngles = new Vector3(transform.rotation.x, _rotateY, transform.rotation.z);
        }
        if (!_isMoving)
        {
            _moveInput = new Vector2(0, _joystick.Vertical);
            _moveVelocity = _moveInput.normalized * _speed;
        }
    }

    private void FixedUpdate()
    {
        if (_moveInput.x == 0 & _moveInput.y == 0)
            _playerScript.animator.Play("PlayerIDE");
        if (_moveInput.x > 0 & _moveInput.y > -0.3 && _moveInput.x > 0 & _moveInput.y < 0.27 )
            _playerScript.animator.Play("PlayerRun");
        if (_moveInput.y > 0.7)
            _playerScript.animator.Play("RunUp");
        if (_moveInput.y < -0.4)
            _playerScript.animator.Play("PlayerRunDown");
        _playerScript.rb2d.MovePosition(_playerScript.rb2d.position + _moveVelocity * Time.fixedDeltaTime);
    }
}
