using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;
    protected float _fSpeed;
    protected Vector2 _fVec;

    protected bool _bWall;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = gameObject.GetComponentInParent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _fVec = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        Vector2 vel = rb.velocity;
        vel.x = _fVec.x * _fSpeed;

        rb.velocity = vel;

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") { 
            if(rb.velocity.y <= 0) anim.SetBool("isOnGround", true); 
            _bWall = false; 
        }
    }


    IEnumerator defeat(float animtime)
    {
        _fVec.x = 0;
        anim.SetBool("isDead", true);
        rb.gravityScale = 0;
        rb.velocity = new Vector3(0, 0, 0);

        yield return new WaitForSeconds(animtime);

        Death();
    }

    protected virtual void Death() { }
}
