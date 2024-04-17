using UnityEngine;
using UnityEngine.UIElements;

public class GroundSpawner : MonoBehaviour
{


    [SerializeField] GameObject GroundTile;
    Vector3 NextSpawnPoint;
    
    
      public  void SpawnTile (bool spawnItems)
      {

        GameObject temp =  Instantiate(GroundTile, NextSpawnPoint, Quaternion.identity);
        NextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems)
        {

            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }

      }
    
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 3)
            {
                SpawnTile(false);
            }
            else
            {
                SpawnTile(true);
            }
            
            
        }

      

    }

   
}
