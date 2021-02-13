using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    private GameController gameController;
    private int finalScore = 0;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        gameController = FindObjectOfType<GameController>();

    }

    void Update()
    {
        finalScore = gameController.GetScore();
    }

    public int GetScore()
    {
        return finalScore;
    }
}
