using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _velocity;
    public float speed;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _controller.Move(_velocity * Time.deltaTime);
        Debug.Log(_velocity);
    }
    public void MoveControl(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        _velocity = new Vector3(dir.x, 0, dir.y) * speed;
    }
}
