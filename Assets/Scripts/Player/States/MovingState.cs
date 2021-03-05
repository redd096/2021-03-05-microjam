using UnityEngine;
using redd096;

public class MovingState : State
{
    Rigidbody2D rb;
    Vector2 startPosition;
    Vector2 endPosition;

    public MovingState(Vector2 startPosition, Vector2 endPosition)
    {
        //set vars
        this.startPosition = startPosition;
        this.endPosition = endPosition;
    }

    public override void Enter()
    {
        base.Enter();

        //get references
        rb = stateMachine.GetComponent<Rigidbody2D>();

        //add force
        Vector2 velocity = startPosition - endPosition;
        rb.AddForce(velocity, ForceMode2D.Impulse);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        //if rigidbody sleeping, come back to wait input
        if(rb.velocity.magnitude < GameManager.instance.velocitySleepingRigidbody)
        {
            BackToInput();
        }
    }

    void BackToInput()
    {
        //back to player wait input
        stateMachine.SetState(new PlayerWaitInputState());
    }
}
