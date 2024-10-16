using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject HealthSpriteTemplate;
    public int StartSpawn;
    public int SpaceBetween;

    List<GameObject> healthSprites;
    int maxHealth;

    public void initializeHealth(int health)
    {
        GameObject sprite;
        Vector3 nextPos;
        
        healthSprites = new List<GameObject>();
        maxHealth = health;
        
        for (int i = 0; i < maxHealth; i++)
        {
            nextPos = new Vector3(transform.position.x + StartSpawn + (SpaceBetween * i), transform.position.y, transform.position.z);
            sprite = Instantiate(HealthSpriteTemplate, transform);
            sprite.transform.position = nextPos;
            sprite.SetActive(true);
            healthSprites.Add(sprite);
        }
    }

    public void loseHealth()
    {
        Destroy(healthSprites[healthSprites.Count - 1]);
        healthSprites.RemoveAt(healthSprites.Count - 1);
    }
}
