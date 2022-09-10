using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {
        Debug.Log("Player is death");
        state.GetComponent<PlayerAnimation>().DyingAnimation();
        GameOverController.Instance.SetGameOver();
    }

    public override void UpdateState(PlayerStateManager state)
    {

    }

    public override void OnTriggerEnter(PlayerStateManager state, Collider other)
    {

    }
}
