using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarSpawner : MonoBehaviour
{
    public GameObject[] enemyCars;
    public float xPos;
    public float yPos;
    public float zPos;
    public int enemyCarCount;

    public GameObject mainCar;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        //mainCar = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator EnemySpawn()
    {
        while (true)
        {
            xPos = Random.Range(-2.5f, 2.5f);
            yPos = .5f;
            zPos = mainCar.transform.position.z + 35f;

            int randomCar = Random.Range(0, enemyCars.Length);

            yield return new WaitForSeconds(3);
            Instantiate(enemyCars[randomCar], new Vector3(xPos, yPos, zPos), 
                Quaternion.Euler(0,180,0));
            //enemyCarCount++;

        }
    }
}
