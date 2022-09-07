using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpellMove : MonoBehaviour
{
    Transform enemySpellTarget;
    private void Start()
    {
        enemySpellTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    public void Move()
    {
        transform.parent = enemySpellTarget;
        transform.DOLocalJump(new Vector3(0, 0, 0), 2.0f, 3, 2);

    }

}
