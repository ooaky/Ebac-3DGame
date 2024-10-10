using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerATT : MonoBehaviour
{
    #region Variables
    public Rigidbody myRigidBody;

    [Header("Movement")]

    [Header("Ground Movement")]
    public float speed;
    public Vector3 friction = new Vector3(.1f, 0, .1f);
    private float _currentSpeed;
    private float side = 1f;

    [Header("Jump")]
    public float jumpHeight = 15;

    [Header("Jump Collision Check")]
    public Collider collider;
    public float distToGround = 0;
    public float spaceToGround = .1f;

    #endregion

    private void Awake()
    {
        if (collider != null)
        {
            distToGround = collider.bounds.extents.y;
        }

    }


    private void Update()
    {
        HandleJump();
        HandleMovent();
    }


    private void HandleMovent()
    {

        if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.velocity = Vector3.right * speed;
            //myRigidBody.velocity = new Vector3(speed, myRigidBody.velocity.y, myRigidBody.velocity.z);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.velocity = Vector3.left * speed;
            //myRigidBody.velocity = new Vector3(-speed, myRigidBody.velocity.y, myRigidBody.velocity.z);

        }
        else if (Input.GetKey(KeyCode.W))
        {
            myRigidBody.velocity = Vector3.forward * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            myRigidBody.velocity = Vector3.back * speed;
        }


        if (myRigidBody.velocity.x > 0)
        {
            myRigidBody.velocity -= friction;
        }
        else if (myRigidBody.velocity.x < 0)
        {
            myRigidBody.velocity += friction;
        }
        else if (myRigidBody.velocity.z > 0)
        {
            myRigidBody.velocity -= friction;
        }
        else if (myRigidBody.velocity.z < 0)
        {
            myRigidBody.velocity += friction;
        }
    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector3.up * jumpHeight;
        }
    }
}

