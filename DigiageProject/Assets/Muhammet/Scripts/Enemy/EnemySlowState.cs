using UnityEngine;

public class EnemySlowState : EnemyBaseState
{
    private float _slowTimer = 0f;
    private float _speed = 8f;

    public override void EnterState(EnemyStateManager state)
    {

    }

    public override void OnTriggerEnter(EnemyStateManager state, Collider collider)
    {

    }

    public override void UpdateState(EnemyStateManager state)
    {
        _slowTimer += Time.deltaTime;
        Vector3 forwardMove = Vector3.forward * _speed * Time.deltaTime;
        state.GetComponent<Rigidbody>().MovePosition(state.transform.position + forwardMove);
        //
        if(_slowTimer >= 1f)
        {
            _slowTimer = 0f;
            state.SwitchState(state.RunningState);
        }

    }
}
