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

#if UNITY_ANDROID && !UNITY_EDITOR
        if (Input.touchCount <= 0)
            return;

        Touch touch = Input.GetTouch(0);

        //on press touch
        if (touch.phase == TouchPhase.Began)
        {
            //check if hit player
            RaycastHit2D hit = Physics2D.GetRayIntersection(player.cam.ScreenPointToRay(touch.position), 10, CreateLayer.LayerOnly("Player"));
            if (hit && hit.transform.GetComponentInParent<Player>())
            {
                StartAim(hit.point);
            }
        }
#else
        //on press mouse button
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check if hit player
            RaycastHit2D hit = Physics2D.GetRayIntersection(player.cam.ScreenPointToRay(Input.mousePosition), 10, CreateLayer.LayerOnly("Player"));
            if (hit && hit.transform.GetComponentInParent<Player>())
            {
                StartAim(hit.point);
            }
        }
#endif
    }

    void StartAim(Vector2 startPosition)
    {
        //start Aim
        //stateMachine.SetState(new PlayerAimState(startPosition));
        stateMachine.SetState(new PlayerAimState(stateMachine.transform.position));
    }
}
