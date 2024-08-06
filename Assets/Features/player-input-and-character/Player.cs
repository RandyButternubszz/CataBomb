using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody _body;
    private Vector3 _velocity;
    public float speed;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _body.AddForce(_velocity);
    }
    public void MoveControl(InputAction.CallbackContext context)
    {
        Vector2 dir = context.ReadValue<Vector2>();
        _velocity = new Vector3(dir.x, 0, dir.y) * speed;
    }
}
