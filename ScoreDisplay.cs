using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = gameController.GetScore().ToString();
    }
}
