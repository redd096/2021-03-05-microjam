using UnityEngine;
using redd096;

public class PlayerWaitInputState : State
{
    Player player;

    public override void Enter()
    {
        base.Enter();

        //get references
        player = stateMachine as Player;
    }

    public override void Update()
    {
        base.Update();

        //on press mouse button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check if hit player
            RaycastHit2D hit = Physics2D.GetRayIntersection(player.cam.ScreenPointToRay(Input.mousePosition));
            if (hit && hit.transform.GetComponentInParent<Player>())
            {
                StartAim(hit.point);
            }
        }
    }

    void StartAim(Vector2 startPosition)
    {
        //start Aim
        stateMachine.SetState(new PlayerAimState(stateMachine.transform.position));
    }
}
