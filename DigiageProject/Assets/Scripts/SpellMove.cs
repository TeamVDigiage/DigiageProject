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
        enemySpellTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
       
        transform.GetChild(0).gameObject.SetActive(true);
        transform.DOLocalJump(enemySpellTarget.transform.position, 0.6f, 3, 2).OnComplete(() => SlowDownEnemy());

    }
    void Move()
    {
        enemySpellTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
        transform.GetChild(0).gameObject.SetActive(false);
      
        transform.DOMove(enemySpellTarget.transform.position, 0.6f).OnComplete(()=>SlowDownEnemy());
    }
    void SlowDownEnemy()
    {
    }


}
