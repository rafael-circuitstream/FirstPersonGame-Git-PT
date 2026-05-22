using UnityEngine;

public class AimingState : BaseState
{
    private Transform target;
    private Transform turretHead;

    private LineRenderer laserEffect;

    public override void OnStartState()
    {
        laserEffect = controller.GetComponentInChildren<LineRenderer>();

        laserEffect.enabled = true;

        turretHead = controller.transform.Find("HEAD");
    }

    public override void OnRunState()
    {
        turretHead.transform.LookAt( target.position + Vector3.up);

        if(Vector3.Distance(controller.transform.position, target.position) > 8)
        {
            controller.ChangeState(new IdleState());
        }
    }

    public override void OnExitState()
    {
        laserEffect.enabled = false;
    }

    public AimingState(Transform newTarget)
    {
        target = newTarget;
    }
}
