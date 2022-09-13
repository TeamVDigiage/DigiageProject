using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SlowAnimation()
    {
        anim.Play("Slow");
    }

    public void DyingAnimation()
    {
        anim.Play("Death");
    }

    public void EvilWinAnimation()
    {
        anim.Play("Win");
    }
}
