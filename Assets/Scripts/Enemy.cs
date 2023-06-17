using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField]
    protected float speed;    

    protected Vector2 dir;
    protected RaycastHit2D[] hitInfo;
    protected Rigidbody2D _rb;
    // Start is called before the first frame update
    //void Start()
    //{
    //    //_rb = GetComponent<Rigidbody2D>();
    //    //dir = new Vector2(8, 0);
    //    //hitInfo = new RaycastHit2D();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //Movement();
    //    //if (IsGrounded())
    //    //{
    //    //    Jump();
    //    //}
    //}

    //public void Movement()
    //{
    //    transform.Translate(speed * Time.deltaTime, 0, 0);
    //    Debug.DrawRay(transform.position, dir, Color.red);

    //    // TODO: Improve this process to detect the player with a Raycast and increments velocity
    //    hitInfo = Physics2D.RaycastAll(transform.position, dir, 8f);

    //    if (hitInfo.Length < 0)
    //    {
    //        return;
    //    }

    //    foreach (var hit in hitInfo)
    //    {
    //        Debug.Log("Enter to not null collider");
    //        Debug.Log($"Value of Collider: {hit.collider} || Value of Tag: {hit.collider.tag}");
    //        if (hit.collider.tag.Equals(TagManager.PLAYER))
    //        {
    //            Debug.Log("Player Detected");
    //            speed = speed < 0f ? -10f : 10f;
    //            return;
    //        }

    //        speed = speed < 0f ? -5f : 5f;

    //    }

    //}

    //public void Jump()
    //{
    //    _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Vector2 localScale = transform.localScale;
    //    localScale.x *= -1f;
    //    transform.localScale = localScale;
    //    speed *= -1f;
    //    dir.x *= -1f;
    //}

    

}
