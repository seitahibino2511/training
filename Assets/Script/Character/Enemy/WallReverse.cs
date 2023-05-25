using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallReverse : MonoBehaviour
{
    [SerializeField] MoveEnemy _enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")_enemy.ChangeVec();
    }
}
