using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private PlayerScript _playerScript;
    public float _speed = 0.5f;
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;
    public Camera _camera;
    public Joystick _joystick;
    private void Update()
    {
        float _rotateY = 0f;
        _moveInput = new Vector2(_joystick.Horizontal, _joystick.Vertical);

        _moveVelocity = _moveInput.normalized * _speed;
        if (_moveInput.x < 0)
        {
            _rotateY = 180f;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, _rotateY, transform.rotation.z);
    }

    private void FixedUpdate()
    {
        if (_moveInput.x == 0 & _moveInput.y == 0)
            _playerScript.animator.Play("Player_idle2");
        if (_moveInput.x > 0 & _moveInput.y > -0.3 && _moveInput.x > 0 & _moveInput.y < 0.27 )
            _playerScript.animator.Play("Player_walk_2");
        if (_moveInput.y > 0.7)
            _playerScript.animator.Play("Back_walk");
        if (_moveInput.y < -0.4)
            _playerScript.animator.Play("Player_front_walk");
        _playerScript.rb2d.MovePosition(_playerScript.rb2d.position + _moveVelocity * Time.fixedDeltaTime);
        //_playerScript.spriteRenderer[1].flipX = _moveInput.x < 0.0f;
        //_playerScript.spriteRenderer[0].flipX = _moveInput.x < 0.0f;
    }
}
