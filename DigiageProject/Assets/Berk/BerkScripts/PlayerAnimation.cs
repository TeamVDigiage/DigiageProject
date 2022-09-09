using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ShootAnimation()
    {
        anim.Play("Gun");
    }

    public void DyingAnimation()
    {
        anim.Play("Death");
    }

    public void JumpingAnimation()
    {
        anim.Play("Jump");
    }
}
