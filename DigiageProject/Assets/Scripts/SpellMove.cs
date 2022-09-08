using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpellMove : MonoBehaviour
{
    [SerializeField]
    enum MoveStyle
    {
        Jump,
        Move
    }
    [SerializeField] MoveStyle moveStyle;
    Transform enemySpellTarget;
    private void Start()
    {
        enemySpellTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    public void UseMove()
    {
        switch (moveStyle)
        {
            case MoveStyle.Jump:
                Jump();
                break;
            case MoveStyle.Move:
                break;
                Move();
            default:
                break;
        }
    }

    void Jump()
    {
        transform.parent = enemySpellTarget;
        transform.DOLocalJump(new Vector3(0, 0, 0), 2.0f, 3, 2).OnComplete(() => SlowDownEnemy());

    }
    void Move()
    {
        transform.parent = enemySpellTarget;
        transform.DOMove(new Vector3(0, 0, 0), 2).OnComplete(()=>SlowDownEnemy());
    }
    void SlowDownEnemy()
    {
        //slowdown enemy
    }


}
