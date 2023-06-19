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
    
}
