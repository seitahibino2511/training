using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : Character
{
    protected override void Start()
    {
        base.Start();
        _fVec.x = -_fSpeed;
        anim.SetBool("isMoving", true);

    }

    public void ChangeVec()
    {
        _fVec.x *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Damage()
    {
        gameObject.layer = LayerMask.NameToLayer("DEnemy");
        StartCoroutine("defeat", 0.3f);
    }

    protected override void Death()
    {
        Destroy(this.gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

}
