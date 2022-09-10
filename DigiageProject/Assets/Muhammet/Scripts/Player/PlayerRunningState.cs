using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    private Rigidbody _playerRigidbody;
    private bool _isGrounded = true;
    private float _speed = 15f;
    private float _jumpForce = 4f;
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

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
            state.GetComponent<PlayerAnimation>().JumpingAnimation();
            _isGrounded = false;
        }

        Ray ray = new Ray(state.transform.position, Vector3.down);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1.0f))
        {
            if (hit.collider != null)
                _isGrounded = true;
        }
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
