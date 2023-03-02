using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class NoteMakerPlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    Rigidbody2D _rb;


    [SerializeField]
    [Range(0f, 50f)]
    float _maxSpeed = 5;


    [SerializeField]
    private float _moveSpeed = 1;


    Vector2 _movement;

    private Vector2 _prevPos;

    [SerializeField]
    private float _acceleration = 0.125f;


    float _deceleration;

    RoundEventManager _eventManager;
    void InjectComponents()
    {
     
        _rb = GetComponent<Rigidbody2D>();

        _eventManager = GameObject.FindGameObjectWithTag("RoundManager").GetComponent<RoundEventManager>() ;
    }


    void Start()
    {
        InjectComponents();

        _deceleration = _acceleration * 1.5f;

        
    }


    void Update()
    {
        float x = Input.GetAxis(HorizontalAxisName);
        float y = Input.GetAxis(VerticalAxisName);

        _movement = new Vector2(x, y);
      
    }

    private void FixedUpdate()
    {

        if (_eventManager.state == RoundEventManager.RoundState.WaitingToStart) return;

        MoveCharacterRigidbody(_movement);

        
    }

    private void MoveCharacterRigidbody(Vector2 movement)
    {

        //No input
        if(movement.x == 0 && movement.y == 0)
        {
            _moveSpeed -= _deceleration;

        }
        else
        {
            //Some input
            if (_moveSpeed < _maxSpeed)
            {
                _moveSpeed += _acceleration;

            }
        }


        _moveSpeed = Mathf.Clamp(_moveSpeed, 0 , _maxSpeed);

        _rb.MovePosition(_rb.position + (movement * _moveSpeed * Time.deltaTime));


      

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Platform"))
        {
            _moveSpeed = 1;
        }
    }

}
