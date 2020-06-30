using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomEnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public int EnemyNumber;
    public int posX;
    public int posZ;

    void Start()
    {
        StartCoroutine(EnemySpawn());  
    }

    IEnumerator EnemySpawn()
    {
        while (EnemyNumber < 5)
        {
            posX = Random.Range(-32, 20);
            posZ = Random.Range(20, -24);
            Instantiate(Enemy, new Vector3(posX, 0, posZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            EnemyNumber += 1;
        }
    }
}
