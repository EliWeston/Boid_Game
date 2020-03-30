using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoidController : MonoBehaviour {

    public static BoidController Instance;

    public GameObject _player;

    private Camera _mainCamera;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public float xMove;
    public float yMove;
    public Vector3 lastPos;
    public Vector3 currentPos;
    public float positionChange = 0;

    //key checks
    public bool increaseSpeed = false;

    void Start()
    {
        //I really need to put position info in the player manager
        Instance = this;

        _mainCamera = Camera.main;
        lastPos = _player.transform.position;

    }



    void FixedUpdate()
    {
        currentPos = _player.transform.position;
        positionChange = currentPos.x - lastPos.x;

        switch (PlayerManager.Instance.CurrentState)
        {
            case PlayerManager.PlayerState.Alive:
                MovePlayer();
                break;
        }

        KeyCheck();

        lastPos = currentPos;
    }

    private void MovePlayer() {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        Vector3 movement = GetMoveSpeed(_player.transform.rotation.x, _player.transform.rotation.y);
        // -y is left, +y is right
        //Debug.Log("x=" + (_player.transform.rotation.x));
        //Debug.Log("y=" + (_player.transform.rotation.y));
        if (increaseSpeed == false)
        {
            transform.position += (transform.forward * 1.85f + movement);
        } else
        {
            transform.position += (transform.forward * 3 + movement);
        }
        
    }

    private Vector3 GetMoveSpeed(float x, float y)

    {

        xMove = Mathf.Min(Mathf.Abs(y * 10), 3);
        yMove = Mathf.Min(Mathf.Abs(x * 10), 3);
        // Figure out which direction our plane should be turning to
        if (x >= 0)
           yMove *= -1;
        if (y< 0)
            xMove *= -1;
        //-yMove = left;
        //Debug.Log("yMove=" + yMove);
        return new Vector3(xMove, yMove, 0f);
    }

    void KeyCheck()
    {
        if (Input.GetKey(KeyCode.Space)){
            increaseSpeed = true;
        } else { 
            increaseSpeed = false;
        }
    }

}

