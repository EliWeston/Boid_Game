using UnityEngine;

public class PathItemGenerator : MonoBehaviour {

    public float BoidSpawnRate = 0.9f; //from 0 to 1

    private string containerString = "Container";
    private string spawnPointString = "PUSpawnPoints";
    private int numberOfEmbersToGenerate = 3;
    private int emberDistanceGap = 20;

    private string boidSpawnPointString = "BoidSpawnPoints";
    //string to find our boid spawn points container

    void Start()
    {
        SpawnEmber();
        SpawnBoid();
    }

    private void SpawnEmber()
    {
        Transform spawnPoint = PickSpawnPoint(containerString, spawnPointString);
        //we then create a loop of x items that are Y units apart from eachother
        for (int i = 0; i < numberOfEmbersToGenerate; i++)
        {
            Vector3 newPosition = spawnPoint.transform.position;
            newPosition.z += i * emberDistanceGap;
            Instantiate(ItemLoaderManager.Instance.Ember, newPosition, Quaternion.identity);

        }
    }

    private void SpawnBoid()
    {
        //We randomly generate a number and divide it by 100. If it is lower then the 
        //spawn rate chance we set, we create the boid
        bool generateBoid = Random.Range(0, 100) / 100f < BoidSpawnRate;
        if (generateBoid)
        {
            //Get our spawn poiny and its position.
            Transform spawnPoint = PickSpawnPoint(containerString, boidSpawnPointString);
            Vector3 newPosition = spawnPoint.transform.position;

            //Get our Boids and randomly pick one of them to show.
            GameObject[] boidPickUps = ItemLoaderManager.Instance.BoidPickUps;
            int boidPickUpIndex = Random.Range(0, boidPickUps.Length);
            Instantiate(boidPickUps[boidPickUpIndex], newPosition, Quaternion.identity);
        }
    }

    private Transform PickSpawnPoint(string spawnPointContainerString, string sapwnPointString)
    {
        Transform container = transform.Find(spawnPointContainerString);
        Transform spawnPointContainer = container.Find(spawnPointString);

        Transform[] spawnPoints = new Transform[spawnPointContainer.childCount];

        for (int i = 0; i < spawnPointContainer.childCount; i++)
        {
            spawnPoints[i] = spawnPointContainer.GetChild(i);
        }

        //if we don't have ay spawn points
        if(spawnPointString.Length == 0)
        {
            Debug.Log("We have a path that has no spawn points!");
        }

        //we randomly pick one of our spawn points to use
        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index];
    }

}
