using UnityEngine;

public class BiomeStateManager : MonoBehaviour
{
    BiomeBaseState currentState;
    public DayState DayState = new DayState();
    public TwilightState TwilightState = new TwilightState();
    public NightState NightState = new NightState();

    private void Start()
    {
        currentState = DayState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    public void SwitchState(BiomeBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    




}
