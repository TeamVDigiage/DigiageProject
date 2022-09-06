using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager state)
    {

    }

    public override void UpdateState(PlayerStateManager state)
    {

    }

    public override void OnTrigger(PlayerStateManager state, Collider other)
    {
        if(other.TryGetComponent(out EnemyStateManager enemy))
        {
            Debug.Log("Player is death");
        }
    }
}
