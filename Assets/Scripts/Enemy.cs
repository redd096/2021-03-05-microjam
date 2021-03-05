using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision)
    {
        //exit from floor, destroy enemy
        Destroy(gameObject);
    }
}
