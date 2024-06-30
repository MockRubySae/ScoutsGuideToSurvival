
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject groundTile;
    Vector3 nextSpawn;



   public void SpawnPlane(bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawn, Quaternion.identity);
        nextSpawn = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {
            temp.GetComponent<GroundPlane>().SpawnLog();
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)    
        {
            if (i < 3)
            {
                SpawnPlane(false);
            }
            else{
                SpawnPlane(true);
            }
            
        }    
        

    }

  
}
