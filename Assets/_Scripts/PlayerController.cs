using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private float movementSpeed=10;
    private float rotationSpeed = 30;
    private float force = 5;
    private bool usePhysicsEngine = true;
    
    private float verticalInput,HorizontalInput;

    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        HorizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        movePlayer();
        keepInBounds();
        
    }

    void keepInBounds()
    {
        if (transform.position.x > 45)
        {
            transform.position = new Vector3(45, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -45)
        {
            transform.position = new Vector3(-45, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 45)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 45);
        }
        if (transform.position.z < -45)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -45);
        }
        

    }

    void movePlayer()
    {
        if (usePhysicsEngine)
        {
            _rigidbody.AddForce(Vector3.forward * verticalInput*force,ForceMode.Acceleration);
            _rigidbody.AddForce(Vector3.right*HorizontalInput*force,ForceMode.Acceleration);
        }
        else
        {
            transform.Translate(Vector3.forward*verticalInput*movementSpeed*Time.deltaTime);
            transform.Translate(Vector3.right*HorizontalInput*movementSpeed*Time.deltaTime);
        }

    }
}
