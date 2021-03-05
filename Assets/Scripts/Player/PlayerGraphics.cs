using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    [Header("Line Prefab")]
    [SerializeField] LineRenderer linePrefab = default;

    Player player;
    LineRenderer line;

    void Awake()
    {
        //get player and instantiate line
        player = GetComponent<Player>();
        line = Instantiate(linePrefab, transform);
    }

    private void OnEnable()
    {
        //add events
        player.updateLine += UpdateLine;
        player.stopLine += StopLine;
    }

    private void OnDisable()
    {
        //remove events
        player.updateLine -= UpdateLine;
        player.stopLine -= StopLine;
    }

    void UpdateLine(Vector2 startPosition, Vector2 endPosition)
    {
        //update line positions
        line.positionCount = 2;

        //set vars
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, -1);
        Vector3 direction = endPosition - startPosition;

        //from transform position, to direction
        line.SetPosition(0, playerPosition);
        line.SetPosition(1, playerPosition + (direction.normalized * direction.magnitude));
    }

    void StopLine()
    {
        //remove line positions
        line.positionCount = 0;
    }
}
