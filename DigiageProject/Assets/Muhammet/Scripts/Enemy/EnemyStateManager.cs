using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState _currentState;
    public EnemyRunningState RunningState = new EnemyRunningState();
    public EnemySlowState SlowState = new EnemySlowState();

    void Start()
    {
        _currentState = RunningState;
        _currentState.EnterState(this);
    }


    void Update()
    {
        _currentState.UpdateState(this);
    }

    void OnTriggerEnter(Collider other)
    {
        _currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(EnemyBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
}
