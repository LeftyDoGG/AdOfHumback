using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    public Transform SpawnPos;
    public GameObject spawner;
    public int BossNumber;
    ScoreManager scoreManager;

    void Update()
    {
        if (ScoreManager.score >= 50)
        {
            while (BossNumber < 1)
            {
                Instantiate(spawner, SpawnPos.position, SpawnPos.rotation);
                BossNumber += 1;
            }

        }
    }
}
