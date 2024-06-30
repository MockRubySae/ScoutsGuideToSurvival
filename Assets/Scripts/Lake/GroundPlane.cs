
using UnityEngine;

public class GroundPlane : MonoBehaviour
{


    GroundSpawner groundSpawner;


    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
    }

private void OnTriggerExit(Collider other)
{
    groundSpawner.SpawnPlane(true);
    Destroy(gameObject, 2);
}
    // Update is called once per frame
    void Update()
    {
        
    }



    public GameObject logPrefab;

   public void SpawnLog()
    {
        int logSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(logSpawnIndex).transform;


        Instantiate(logPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}
