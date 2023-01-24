using UnityEngine;

public class RoadTar : MonoBehaviour
{
    RoadSpawner roadSpawner;
    // Start is called before the first frame update
    void Start()
    {
        roadSpawner = GameObject.FindObjectOfType<RoadSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        roadSpawner.SpawnRoad();
        Destroy(gameObject, 2);
    }


}
