using System.Collections;
using UnityEngine;
using redd096;

public class EnemyGraphics : MonoBehaviour
{
    [Header("Death Animation")]
    [SerializeField] bool stopRigidbody = false;
    [SerializeField] float durationDeath = 2;

    Enemy enemy;

    void Awake()
    {
        //get references
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        //add events
        enemy.onDead += OnDead;
    }

    private void OnDisable()
    {
        //remove events
        enemy.onDead -= OnDead;
    }

    void OnDead()
    {
        //stop rigidbody
        if(stopRigidbody)
            enemy.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

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
