using UnityEngine;

public class IdleState : BaseState
{
    private PlayerInput player;
    private Transform turretHead;

    public override void OnStartState()
    {
        player = GameManager.Instance.GetPlayer();
        turretHead = controller.transform.Find("HEAD");
    }

    public override void OnRunState()
    {

        if(Vector3.Distance(controller.transform.position, player.transform.position) < 8)
        {
            controller.ChangeState( new AimingState(player.transform) );
        }


        turretHead.rotation = Quaternion.Lerp(turretHead.rotation, Quaternion.identity, Time.deltaTime);
    }

    public override void OnExitState()
    {

    }
}
