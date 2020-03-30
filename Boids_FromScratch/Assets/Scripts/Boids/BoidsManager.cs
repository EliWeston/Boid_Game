using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidsManager : MonoBehaviour {

    public static BoidsManager Instance;
    public List<GameObject> CurrentBoids;
    public GameObject player;
    private Vector3 _playerPosition;

    [Header("Set in Inspector: Boids")]
    public float velocity = 30f;
    public float neighborDist = 30f;
    public float collDist = 4f;
    public float velMatching = 0.25f;
    public float flockCentering = 0.2f;
    public float collAvoid = 2f;
    public float attractPull = 2f;
    public float attractPush = 2f;
    public float attractPushDist = 5f;
    public Transform boidAnchor;

    public float normalVelocity;
    private float fastVelocity;



    void Start () {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Init();
    }

    void Init()
    {
        Instance = this;

        //Keep track of OG velocity so we can go back to it
        normalVelocity = velocity;
        fastVelocity = velocity * 1.4f;
    }
	
	// Update is called once per frame
	void Update () {

        //pickup speed if player is
        if (BoidController.Instance.increaseSpeed == true)
        {
            velocity = fastVelocity;
        } else
        {
            //return to normal speed
            velocity = normalVelocity;
        }
		
	}

    public void SpawnYellowBoid()
    {
        //Debug.Log("Should spawn Yellow");
        _playerPosition = player.transform.position;
        GameObject yellowBoid = Instantiate(ItemLoaderManager.Instance.YellowBoid,
            new Vector3(_playerPosition.x, _playerPosition.y, _playerPosition.z - 5),
            Quaternion.identity);
        CurrentBoids.Add(yellowBoid);
        yellowBoid.transform.SetParent(boidAnchor);
    }

    public void SpawnGreenBoid()
    {
        //Debug.Log("Should spawn Green");
        _playerPosition = player.transform.position;
        GameObject greenBoid = Instantiate(ItemLoaderManager.Instance.GreenBoid,
            new Vector3(_playerPosition.x, _playerPosition.y, _playerPosition.z - 5),
            Quaternion.identity);
        CurrentBoids.Add(greenBoid);
        greenBoid.transform.SetParent(boidAnchor);
    }

    public void SpawnBlueBoid()
    {
        //Debug.Log("Should spawn Blue");
        _playerPosition = player.transform.position;
        GameObject blueBoid = Instantiate(ItemLoaderManager.Instance.BlueBoid,
            new Vector3(_playerPosition.x, _playerPosition.y, _playerPosition.z - 5),
            Quaternion.identity);
        CurrentBoids.Add(blueBoid);
        blueBoid.transform.SetParent(boidAnchor);
    }

    public void SpawnRedBoid()
    {
        //Debug.Log("Should spawn Red");
        _playerPosition = player.transform.position;
        GameObject redBoid = Instantiate(ItemLoaderManager.Instance.RedBoid,
            new Vector3(_playerPosition.x, _playerPosition.y, _playerPosition.z - 5),
            Quaternion.identity);
        CurrentBoids.Add(redBoid);
        redBoid.transform.SetParent(boidAnchor);
    }

    public void RemoveBoid(GameObject _boid)
    {
        CurrentBoids.Remove(_boid);
        GameManager.Instance.RemoveBoid();
    }

}
