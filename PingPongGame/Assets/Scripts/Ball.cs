using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float speed= 24f;
    Rigidbody _rigidbody;
    Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = Vector3.down*speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = _rigidbody.velocity.normalized * speed;
        _velocity = _rigidbody.velocity;
    }

    // when ball hit the paddle and walls
    private void OnCollisionEnter(Collision collision)
    {
        _rigidbody.velocity = Vector3.Reflect(_velocity,collision.contacts[0].normal);
    }
}
