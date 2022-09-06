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
        Vector3 forwardMove = Vector3.forward * _speed * Time.deltaTime;
        Vector3 horizontalMove = Vector3.right * horizontalInput * _horizontalSpeed * Time.deltaTime;
        state.GetComponent<Rigidbody>().MovePosition(state.transform.position + forwardMove + horizontalMove); //horizontalMove
    }

    public override void OnTrigger(PlayerStateManager state, Collider collider)
    {

    }
}
