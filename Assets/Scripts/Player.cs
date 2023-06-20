using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Player : MonoBehaviour, ICharacter, IJumpable
{
    private Rigidbody2D _rb;
    private float _horizontal;
    private bool _isFacingRight;
    private bool _hasDoubleJump;
    private Vector2 delayedForce;

    [Header("Character Physics")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [Header("Animator")]
    [SerializeField] private Animator animator;

    [Header("Dash")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashCD;
    [SerializeField] private float dashDuration;
    private float dashCDTimer;
    private bool _isDashing;


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

    public void Movement()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");

        transform.Translate(_horizontal * speed * Time.deltaTime, 0, 0);
        animator.SetBool("isWalking", true);

        if (_horizontal < 0f && _isFacingRight || _horizontal > 0f && !_isFacingRight)
        {
            _isFacingRight = !_isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            dashForce *= -1f;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dash();
        }
        if (dashCDTimer > 0)
        {
            dashCDTimer -= Time.deltaTime;
        }
    }

    private void Dash()
    {
        if (dashCDTimer > 0)
        {
            return;
        }
        else
        {
            dashCDTimer = dashCD;
        }

        _isDashing = true;

        Vector2 force = dashForce * transform.right;
        delayedForce = force;

        Invoke(nameof(DelayedDashForce), 0.025f);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private void DelayedDashForce()
    {
        _rb.AddForce(delayedForce, ForceMode2D.Impulse);
    }

    private void ResetDash()
    {
        _isDashing = false;
    }

    public void Jump()
    {
        _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    bool IsGrounded()
    {
        return !(Mathf.Abs(_rb.velocity.y) > 0.0001f);
    }
}
