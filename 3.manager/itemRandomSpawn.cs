using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemRandomSpawn : MonoBehaviour
{
    public GameObject Item;
    public GameObject Plankton;
    public int ItemCount;
    private int posX;
    private int posZ;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (ItemCount < 1)
        {
            posX = Random.Range(-10, 8);
            posZ = Random.Range(-8, 10);
            Instantiate(Item, new Vector3(posX, 1, posZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            ItemCount += 1;
        }

        while (ItemCount < 5)
        {
            posX = Random.Range(-10, 8);
            posZ = Random.Range(-8, 10);
            Instantiate(Plankton, new Vector3(posX, 1, posZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            ItemCount += 1;
        }
    }

}
