using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 500f;
    Vector2 direction;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() //inputs
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate() //physics
    {
        MovePlayer();
    }

    private void LateUpdate() //animation
    {
        Anim();
    }

    void Anim() //change animation in realtime
    {
        animator.SetFloat("SpeedX", direction.x);
        animator.SetFloat("SpeedY", direction.y);
    }

    void MovePlayer()
    {
        rb.velocity = direction * speed * Time.deltaTime;
    }
}
