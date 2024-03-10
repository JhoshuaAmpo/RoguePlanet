using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] float xMoveSpeed = 1f;
    [SerializeField] float yMoveSpeed = 1f;
    
    // Start is called before the first frame update
    Player_Controls playerControls;
    Rigidbody2D rb;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        playerControls = new();
        playerControls.Movement.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity_Move();
        Force_Move();
    }

    void Force_Move() {
        float moveForceX = playerControls.Movement.Horizontal.ReadValue<float>() * xMoveSpeed;
        float moveForceY = playerControls.Movement.Vertical.ReadValue<float>() * yMoveSpeed;
        rb.AddForce(new(moveForceX, moveForceY), ForceMode2D.Force);
    }
}
