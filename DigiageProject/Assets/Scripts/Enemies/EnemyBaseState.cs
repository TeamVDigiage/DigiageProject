using UnityEngine;

public abstract class EnemyBaseState
{
    public abstract void EnterState(EnemyStateManager state);
    public abstract void UpdateState(EnemyStateManager state);
    public abstract void OnTriggerEnter(EnemyStateManager state, Collider collider);
}
