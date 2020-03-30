using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    public int moveBackCounter = 0;
    public bool holdStillCheck = false;
    public GameObject player;
    private GameOverCanvasController gameOverScript;
    //Public variable to store a reference to the player game object

    private BoidController birdScript;

    private Vector3 offset;
    private Vector3 extraOffset;
    //Private variable to store the offset distance between the player and camera
    public GameObject gameOverMenu;

    void Start()
    {
        //pathScript = PathGenerator2();
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        extraOffset = new Vector3(0, 2, -45);

        offset = transform.position - player.transform.position + extraOffset;

        birdScript = player.GetComponent<BoidController>();
    }

    // LateUpdate is called after Update each frame
    void FixedUpdate()
    {
        if (holdStillCheck == false) {
            FollowBoid();
                }
    }

    void FollowBoid()
    {
        switch (PlayerManager.Instance.CurrentState)
        {
            case PlayerManager.PlayerState.Dead:
                MoveBack();
                break;

            case PlayerManager.PlayerState.Alive:
                transform.position = player.transform.position + offset;
                break;

        }
    }

    void MoveBack()
    {
        transform.Translate(0 , 0, 0);
        moveBackCounter++;

        if (PathGenerator.Instance.pathIsLong)
        {
            if (moveBackCounter == 50 && holdStillCheck == false)
            {
                transform.Translate(0, 0, 0);
                holdStillCheck = true;
                CallGameOver();
            }
        } else
        {
            if (moveBackCounter == 10 && holdStillCheck == false)
            {
                transform.Translate(0, 0, 0);
                holdStillCheck = true;
                CallGameOver();
            }
        }
    }

    void CallGameOver()
    {
        GameUIManager.Instance.GameOver(gameObject);
    }
}