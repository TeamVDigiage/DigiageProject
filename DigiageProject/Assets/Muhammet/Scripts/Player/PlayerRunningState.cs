using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    private Rigidbody _playerRigidbody;
    private float _speed = 15f;
    private float _horizontalSpeed = 4f;

    public override void EnterState(PlayerStateManager state)
    {
        _playerRigidbody = state.GetComponent<Rigidbody>();
    }

    public override void UpdateState(PlayerStateManager state)
    {
        float horizontalInput = 1 * Input.GetAxis("Horizontal");
        Vector3 forwardMove = state.transform.forward * _speed * Time.deltaTime;
        Vector3 horizontalMove = state.transform.right * horizontalInput * _horizontalSpeed * Time.deltaTime;
        _playerRigidbody.MovePosition(state.transform.position - forwardMove + horizontalMove);
    }

    public override void OnTriggerEnter(PlayerStateManager state, Collider other)
    {
        if (other.TryGetComponent(out EnemyStateManager enemy))
        {
            Debug.Log("Enemy hit");
            state.SwitchState(state.DeathState);
            Object.Destroy(other.gameObject);
        }
    }
}
