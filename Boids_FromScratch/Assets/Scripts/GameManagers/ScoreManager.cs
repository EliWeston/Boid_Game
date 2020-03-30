using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    private float _score = 0;
    private int _boidCount;

    void Start()
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
        _score = 0;

    }

    void CheckPlayerStatus()
    {
        switch (PlayerManager.Instance.CurrentState)
        {
            case PlayerManager.PlayerState.Dead:
                break;

            case PlayerManager.PlayerState.Alive:
                ScoreChanger();
                break;

        }
    }

    void ScoreChanger()
    {
        //gets the number of boids from the Game Manager as _boidCount
        _boidCount = GameManager.Instance.GetBoid();

        //if theres at least one boid, multiply score by boid count
        if (_boidCount <= 0)
        {
            _score += Time.deltaTime * 10;
        }
        else
        {
            _score += (Time.deltaTime * 10) * _boidCount;
        }

        GameUIManager.Instance.SetScoreText((int)_score);
    }

    void Update()
    {
        CheckPlayerStatus();
    }
}

