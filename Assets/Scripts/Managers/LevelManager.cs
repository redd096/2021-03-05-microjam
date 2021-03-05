using System.Collections.Generic;
using UnityEngine;
using redd096;

public class LevelManager : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();

    bool endLevel;

    private void Awake()
    {
        //add every enemy in scene to the list
        foreach (Enemy enemy in FindObjectsOfType<Enemy>())
            enemies.Add(enemy);
    }

    public void EndLevel(bool win)
    {
        //do only one time
        if (endLevel)
            return;

        endLevel = true;

        GameManager.instance.uiManager.EndMenu(true, win);
    }

    public void EnemyKilled(Enemy enemy)
    {
        //remove enemy from the list
        enemies.Remove(enemy);

        //if no enemies in scene, you won
        if (enemies.Count <= 0)
            EndLevel(true);
    }
}
