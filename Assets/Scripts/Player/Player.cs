using UnityEngine;
using redd096;

public class Player : StateMachine
{
    public Camera cam {get; private set;}
    public System.Action<Vector2, Vector2> updateLine { get; set; }
    public System.Action stopLine { get; set; }

    void Awake()
    {
        cam = Camera.main;

        //by default set aim state
        SetState(new PlayerWaitInputState());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //exit from floor, end level
    }
}
