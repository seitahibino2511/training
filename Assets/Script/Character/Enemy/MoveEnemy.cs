using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : Character
{
    protected override void Start()
    {
        base.Start();

        anim.SetBool("isMoving", true);
        _fSpeed = StatusManager.Instance.GetSpeed(2);
        _fVec.x = -_fSpeed;
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
        Destroy(rb.gameObject);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

}
