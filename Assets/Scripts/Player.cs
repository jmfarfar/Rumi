using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _horizontal;
    private bool _isFacingRight;


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

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    bool IsGrounded()
    {
        return !(Mathf.Abs(_rb.velocity.y) > 0.0001f);
    }
}
