using UnityEngine;
using redd096;

public class PlayerAimState : State
{
    Player player;
    Vector2 startPosition;
    Vector2 endPosition;

    public PlayerAimState(Vector2 startPosition)
    {
        //set start position
        this.startPosition = startPosition;
    }

    public override void Enter()
    {
        base.Enter();

        //get references
        player = stateMachine as Player;
    }

    public override void Exit()
    {
        base.Exit();

        //stop line renderer
        player.stopLine?.Invoke();
    }

    public override void Update()
    {
        base.Update();

        //get mouse position
        endPosition = player.cam.ScreenToWorldPoint(Input.mousePosition);

        //update line renderer
        player.updateLine?.Invoke(startPosition, endPosition);

        //if release mouse button, throw player
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Throw();
        }
    }

    void Throw()
    {
        //change state
        stateMachine.SetState(new MovingState(startPosition, endPosition));
    }
}
