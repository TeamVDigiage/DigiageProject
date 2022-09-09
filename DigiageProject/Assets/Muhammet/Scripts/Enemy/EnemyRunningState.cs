using UnityEngine;

public class EnemyRunningState : EnemyBaseState
{
    private float _speed = 17f;

    public override void EnterState(EnemyStateManager state)
    {

    }

    public override void UpdateState(EnemyStateManager state)
    {
        Vector3 forwardMove = state.transform.forward * _speed * Time.deltaTime;
        state.GetComponent<Rigidbody>().MovePosition(state.transform.position + forwardMove);
    }

    public override void OnTriggerEnter(EnemyStateManager state, Collider other)
    {
        if(other.TryGetComponent(out SpellPower spell))
        {
            state.SwitchState(state.SlowState);
        }
    }
}
