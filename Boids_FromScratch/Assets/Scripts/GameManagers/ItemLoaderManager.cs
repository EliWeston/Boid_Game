using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoaderManager : MonoBehaviour
{
    public static ItemLoaderManager Instance;
    public GameObject Ember;
    public GameObject[] BoidPickUps;
    public GameObject YellowBoid;
    public GameObject GreenBoid;
    public GameObject BlueBoid;
    public GameObject RedBoid;

    private void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Init();
    }

    private void Init()
    {
        Instance = this;
    }
}

