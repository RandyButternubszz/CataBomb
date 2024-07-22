using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    private SmoothNumbers<Vector3> _velocity;
    public float speed;
    public float lerpSpeed;
    void Start()
    {
        _controller = GetComponent<CharacterController>();

        _velocity = new SmoothNumbers<Vector3>(Vector3.zero, lerpSpeed, new Vector3MoveTowards());
    }

    
    void Update()
    {
        _velocity.UpdateNum(Time.deltaTime);
        _controller.Move(_velocity.CurrentNum * Time.deltaTime);
    }
    public void MoveControl(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        _velocity.DesiredNum = new Vector3(dir.x, 0, dir.y) * speed;
    }
}
