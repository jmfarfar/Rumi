using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontal;
    private bool _isFacingRight;
    private bool _hasDoubleJump;


    [SerializeField] private float speed = 0;
    [SerializeField] private float jumpForce = 0;


    // Start is called before the first frame update
    void Start()
    {
        _isFacingRight = true;
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && _hasDoubleJump)
        {
            Jump();
            _hasDoubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
            _hasDoubleJump = true;
        }
    }

    void Movement()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        transform.Translate(_horizontal * speed * Time.deltaTime, 0, 0);

        if (_horizontal < 0f && _isFacingRight || _horizontal > 0f && !_isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void Jump()
    {
        _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        return !(Mathf.Abs(_rb.velocity.y) > 0.0001f);
    }
}
