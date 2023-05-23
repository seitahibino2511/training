using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseEnemy : MonoBehaviour
{
    [SerializeField] MoveEnemy _enemy;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") _enemy.ChangeVec();
    }
}
