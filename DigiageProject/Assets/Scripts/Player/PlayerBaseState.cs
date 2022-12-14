using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager state);
    public abstract void UpdateState(PlayerStateManager state);
    public abstract void OnTriggerEnter(PlayerStateManager state, Collider collider);
}
