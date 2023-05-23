using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Animator anim;
    [SerializeField] protected float _fSpeed;
    protected Vector2 _fVec;

    protected bool _bWall;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _fVec = new Vector2(0, 0);
    }

    protected void FixedUpdate()
    {
        Vector2 vel = rb.velocity;
        vel.x = _fVec.x * _fSpeed;

        rb.velocity = vel;

    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") { anim.SetBool("isOnGround", true); _bWall = false; }
    }

    protected virtual IEnumerator defeat(float aaa)
    {
        _fVec.x = 0;
        anim.SetBool("isDead", true);

        yield return new WaitForSeconds(aaa);

        Death();
    }

    protected virtual void Death() { }
}
