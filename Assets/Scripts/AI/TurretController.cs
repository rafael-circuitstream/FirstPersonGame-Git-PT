using UnityEngine;

public class TurretController : MonoBehaviour
{
    public BaseState currentState;

    void Start()
    {
        ChangeState( new IdleState() );

    }

    void Update()
    {
        if(currentState != null)
        {
            currentState.OnRunState();
        }
        
    }

    public void ChangeState(BaseState newState)
    {
        if(currentState != null)
        {
            currentState.OnExitState();
        }
        

        currentState = newState;

        currentState.controller = this;
        currentState.OnStartState();
    }
}
