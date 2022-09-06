using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    private float _speed = 10f;
    private float _horizontalSpeed = 15f;

    public override void EnterState(PlayerStateManager state)
    {
        
    }

    public override void UpdateState(PlayerStateManager state)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 forwardMove = state.transform.forward * _speed * Time.deltaTime;
        Vector3 horizontalMove = state.transform.right * horizontalInput * _horizontalSpeed * Time.deltaTime;
        state.GetComponent<Rigidbody>().MovePosition(state.transform.position + forwardMove + horizontalMove);
    }

    public override void OnTrigger(PlayerStateManager state, Collider collider)
    {

    }
}
