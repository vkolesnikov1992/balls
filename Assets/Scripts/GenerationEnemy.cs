using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationEnemy : MonoBehaviour
{
    public int enemyCount;
    public GameObject enemyPrefab;
    void Start()
    {
        for(int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(3, 140), Random.Range(3, 140)), Quaternion.identity);
        }
    }

   
}
