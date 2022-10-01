using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState _currentState;
    public PlayerRunningState RunningState = new PlayerRunningState();
    public PlayerDeathState DeathState = new PlayerDeathState();

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

    public void SwitchState(PlayerBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
}
