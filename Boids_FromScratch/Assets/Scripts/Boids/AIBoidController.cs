using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBoidController : MonoBehaviour {

    [Header("Set Dynamically")]
    public Rigidbody rigid;

    public GameObject _boid;
    private GameObject _player;

    BoidsManager boidsMan;

    //private Camera _mainCamera;

    private Vector3 offset;

    public Vector3 lastPos;
    public Vector3 currentPos;
    public float positionChange = 0;

    //key checks
    public bool increaseSpeed = false;

    void Awake()
    {
        boidsMan = BoidsManager.Instance;
        _player = boidsMan.player;

        //get rigid body
        rigid = GetComponent<Rigidbody>();

        //set a random initial velocity
        Vector3 vel = Random.onUnitSphere * 1;
        rigid.velocity = vel;

        LookAhead();

        //offset = new Vector3(0, 2, -30);
        //_boid = this.GetComponentInChildren<GameObject>();
        
        //_mainCamera = Camera.main;
        lastPos = _boid.transform.position;

    }

    void LookAhead()
    {
        transform.LookAt(pos + rigid.velocity);
    }

    //position for flock behavior
    public Vector3 pos
    {
        get { return transform.position; }
        set { transform.position = value; }
    }



    void FixedUpdate()
    {
        //position stuff for animator I really need to consilidate this
        currentPos = _boid.transform.position;
        positionChange = currentPos.x - lastPos.x;

        //if theres a player lets go
        if (_player != null)
        {
            MoveBoid();
            //Debug.Log("player is not null");
        }

        lastPos = currentPos;
    }

    void MoveBoid()
    {
        //transform.position = _player.transform.position + offset;
        Vector3 vel = rigid.velocity;

        //Move towards player
        Vector3 delta = BoidController.Instance.currentPos - pos;
        //Debug.Log(BoidController.Instance.currentPos);

        //Check wether boid is attracted to player or avoiding
        bool attracted = (delta.magnitude > boidsMan.attractPushDist);
        Vector3 velAttract = delta.normalized * boidsMan.velocity;
        Vector3 velRepel = delta.normalized * boidsMan.normalVelocity;

        //apply all the velocities
        float fdt = Time.fixedDeltaTime;

        if (attracted) {
            //Debug.Log("attracted");
            vel = Vector3.Lerp(vel, velAttract, boidsMan.attractPull * fdt);
        } else
        {
            //Debug.Log("not attracted");
            vel = Vector3.Lerp(vel, -velRepel, boidsMan.attractPush * fdt);
        }

        //Set the vel to the velocity set on the BoidsManager singleton
        vel = vel.normalized * boidsMan.velocity;
        //Finally assign this to the RigidBody
        rigid.velocity = vel;
        //look in the direction of the new velocity
        LookAhead();
    }

}
