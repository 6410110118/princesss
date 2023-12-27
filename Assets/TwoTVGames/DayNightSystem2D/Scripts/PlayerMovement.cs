using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        Animate();
    }
    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float AnimationMoveX = Input.GetAxisRaw("Horizontal");
        float AnimationMoveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(AnimationMoveX, AnimationMoveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    void Animate()
    {
        Anim.SetFloat("AnimationMoveX", moveDirection.x);
        Anim.SetFloat("AnimationMoveY", moveDirection.y);
    }
}
