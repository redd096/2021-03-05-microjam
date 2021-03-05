using UnityEngine;
using redd096;

public class Enemy : MonoBehaviour
{
    public System.Action onDead { get; set; }

    void OnTriggerExit2D(Collider2D collision)
    {
        //exit from floor, call end event
        onDead?.Invoke();

        //check end level
        GameManager.instance.levelManager.EnemyKilled(this);
    }
}
