using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    public GameObject Road;
    Vector3 nextSpawnPoint;

    public void SpawnRoad()
    {
        GameObject temp = Instantiate(Road, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnRoad();
        }
    }

}
