using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPrefab : MonoBehaviour {

    public float zSize;
    private GameObject path;

	// Use this for initialization
	void Start () {

        path = this.gameObject;

        //zSize = path.transform.Find("zRuler").GetComponent<Collider>().bounds.size.z;
       // Debug.Log("zSize =" + zSize);
		
	}

    void DestroySelf()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
