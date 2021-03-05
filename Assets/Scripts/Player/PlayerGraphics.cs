using System.Collections;
using UnityEngine;
using redd096;

public class PlayerGraphics : MonoBehaviour
{
    [Header("Line Prefab")]
    [SerializeField] LineRenderer linePrefab = default;

    [Header("Death Animation")]
    [SerializeField] bool stopRigidbody = false;
    [SerializeField] float durationDeath = 2;

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
        player.onDead += OnDead;
    }

    private void OnDisable()
    {
        //remove events
        player.updateLine -= UpdateLine;
        player.stopLine -= StopLine;
        player.onDead -= OnDead;
    }

    void UpdateLine(Vector2 startPosition, Vector2 endPosition)
    {
        //update line positions
        line.positionCount = 2;

        //set vars
        Vector3 playerPosition = new Vector3(transform.position.x, transform.position.y, -1);
        Vector3 direction = startPosition - endPosition;

        //from transform position, to direction
        line.SetPosition(0, playerPosition);
        line.SetPosition(1, playerPosition + (direction.normalized * direction.magnitude));
    }

    void StopLine()
    {
        //remove line positions
        line.positionCount = 0;
    }

    void OnDead()
    {
        //stop rigidbody
        if (stopRigidbody)
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        //start coroutine
        StartCoroutine(DeathAnimation());
    }

    IEnumerator DeathAnimation()
    {
        //set vars
        Vector3 startScale = transform.localScale;

        //animation
        float delta = 0;
        while(delta < 1)
        {
            delta += Time.deltaTime / durationDeath;

            //set scale
            transform.localScale = Vector3.Lerp(startScale, Vector3.zero, delta);

            yield return null;
        }

        //destroy
        Pooling.Destroy(gameObject);
    }
}
