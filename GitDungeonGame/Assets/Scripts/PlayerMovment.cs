using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;
    public Camera cam;
    public Animator playerAnimator;
    public Animator rodAnimator;
    Vector2 mousePos;
    public GameObject playerFirePoint;

    void Update()
    {
        ProcessInputs();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        Move();

        Vector2 lookDir = (mousePos - rb.position).normalized;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        playerFirePoint.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector2(moveX, moveY).normalized;
        playerAnimator.SetFloat("Horizontal", moveDirection.x);
        playerAnimator.SetFloat("Vertical", moveDirection.y);
        rodAnimator.SetFloat("Horizontal", moveDirection.x);
        rodAnimator.SetFloat("Vertical", moveDirection.y);

        playerAnimator.SetFloat("Speed", moveDirection.sqrMagnitude);

    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
