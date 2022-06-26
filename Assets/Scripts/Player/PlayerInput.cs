using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private Camera _mainCamera;
    public UnityEvent<Vector2> OnMoveGun = new UnityEvent<Vector2>();
    private void Awake()
    {
        if (_mainCamera == null)
            _mainCamera = Camera.main;
    }
}
