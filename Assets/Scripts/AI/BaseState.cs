using UnityEngine;

public abstract class BaseState
{
    public TurretController controller;

    public abstract void OnStartState();

    public abstract void OnRunState();

    public abstract void OnExitState();
}
