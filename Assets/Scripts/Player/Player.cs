using UnityEngine;
using redd096;

[System.Serializable]
public struct ForceStruct
{
    public float distance;
    public float force;
    public Gradient colorLine;
    public float size;

    public ForceStruct(float distance, float force, Gradient colorLine, float size)
    {
        this.distance = distance;
        this.force = force;
        this.colorLine = colorLine;
        this.size = size;
    }
}

public class Player : StateMachine
{
    [Header("Force")]
    [SerializeField] ForceStruct[] possibleForces = default;

    public Camera cam {get; private set;}
    public System.Action<Vector2, Vector2> updateLine { get; set; }
    public System.Action stopLine { get; set; }
    public System.Action onDead { get; set; }

    void Awake()
    {
        cam = Camera.main;

        //by default set aim state
        SetState(new PlayerWaitInputState());
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //exit from floor, call end event
        onDead?.Invoke();

        //call end level
        GameManager.instance.levelManager.EndLevel(false);
    }

    public ForceStruct GetForce(Vector2 startPosition, Vector2 endPosition)
    {
        ForceStruct forceStruct = new ForceStruct(-1, 0, default, 0);
        float magnitude = (endPosition - startPosition).magnitude;

        //check every distance in the array
        foreach (ForceStruct possible in possibleForces)
        {
            //find nearest to magnitude
            if(magnitude > possible.distance && possible.distance > forceStruct.distance)
            {
                forceStruct = possible;
            }
        }

        return forceStruct;
    }
}
