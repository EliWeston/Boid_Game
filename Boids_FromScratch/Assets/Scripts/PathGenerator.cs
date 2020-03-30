using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Paths
{
    public GameObject[] PathVariations;
}




public class PathGenerator : MonoBehaviour {

    public Paths[] Paths;
    List<GameObject> Currentpaths;

    public GameObject Player;
    public GameObject transitionPath;
    public GameObject forestPath1;

    private int pathCount;

    private float _spawnTriggerDistance;
    private float _spawnPointDistance = 500;
    public static PathGenerator Instance;
    //private float _destroyPointDistance;

    public bool pathIsLong;
	void Start ()
    {

        Instance = this;

        _spawnTriggerDistance = 0;
        _spawnPointDistance = 500;
        //_destroyPointDistance = 500;

        Currentpaths = new List<GameObject>();
        pathIsLong = false;


        //Scaling with cubes are different than planes, instead of multiples of 10, it's just multiples of 1
	}

    void Update()
    {
        if (Player != null)
        {
            if (Player.transform.position.z + 500 >=
                _spawnTriggerDistance)
            {
                CreateNewPath();
            }

            DestroyOldPaths();
        }
    }
  
    private void CreateNewPath()
    {
        pathCount++;
        if (pathCount > 15)
        {
            pathCount = 0;
        }
        if (pathCount < 10)
        {
            GameObject path = Instantiate(GetRandomPath(),
                new Vector3(0, -5, _spawnPointDistance),
                Quaternion.identity);//Create our path
            _spawnTriggerDistance = path.transform.position.z;
            //Debug.Log("sspawnTrigger =" + _spawnTriggerDistance);
            //the z position is actually the halfway point of our object
            //_spawnPointDistance = _spawnPointDistance + (path.GetComponent<Path>().zSize);
            //Debug.Log(_spawnPointDistance);
            _spawnPointDistance += 500;
            //figure out the scale of each path
            Currentpaths.Add(path);
        }
        if (pathCount == 10)
        {
            GameObject path = Instantiate(transitionPath,
                new Vector3(0, -5, _spawnPointDistance),
                Quaternion.identity);//Create our path
            _spawnTriggerDistance = path.transform.position.z;
            //Debug.Log("sspawnTrigger =" + _spawnTriggerDistance);
            //the z position is actually the halfway point of our object
            //_spawnPointDistance = _spawnPointDistance + (path.GetComponent<Path>().zSize);
            //Debug.Log(_spawnPointDistance);
            _spawnPointDistance += 500;
            //figure out the scale of each path
            Currentpaths.Add(path);
        }
        if (pathCount >= 11)
        {
            GameObject path = Instantiate(forestPath1,
                new Vector3(0, -5, _spawnPointDistance),
                Quaternion.identity);//Create our path
            _spawnTriggerDistance = path.transform.position.z;
            //Debug.Log("sspawnTrigger =" + _spawnTriggerDistance);
            //the z position is actually the halfway point of our object
            //_spawnPointDistance = _spawnPointDistance + (path.GetComponent<Path>().zSize);
            //Debug.Log(_spawnPointDistance);
            _spawnPointDistance += 500;
            //figure out the scale of each path
            Currentpaths.Add(path);
        }

    }

    private GameObject GetRandomPath()
    {
        int randomPath = Random.Range(0, Paths.Length);
        int randomVariation = Random.Range(0, 
    Paths[randomPath].PathVariations.Length);
        return
    Paths[randomPath].PathVariations[randomVariation];
    }

    void DestroyOldPaths()
    {
        if (Currentpaths.Count >= 8)
        {
            pathIsLong = true;

            GameObject firstPath = Currentpaths[0];

            Currentpaths.Remove(firstPath);

            Destroy(firstPath);
        }
    }
}
