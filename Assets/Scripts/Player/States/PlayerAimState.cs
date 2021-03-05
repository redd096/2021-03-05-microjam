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

#if UNITY_ANDROID && !UNITY_EDITOR
        if (Input.touchCount <= 0)
            return;

        Touch touch = Input.GetTouch(0);

        //get touch position
        endPosition = player.cam.ScreenToWorldPoint(touch.position);

        //update line renderer
        player.updateLine?.Invoke(startPosition, endPosition);

        //if release touch, throw player
        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            Throw();
        }
#else
        //get mouse position
        endPosition = player.cam.ScreenToWorldPoint(Input.mousePosition);

        //update line renderer
        player.updateLine?.Invoke(startPosition, endPosition);

        //if release mouse button, throw player
        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            Throw();
        }
#endif
    }

    void Throw()
    {
        //change state
        stateMachine.SetState(new MovingState(startPosition, endPosition));
    }
}
