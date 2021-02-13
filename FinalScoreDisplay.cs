using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScoreDisplay : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    GameInfo gameinfo;

    void Start()
    {
        gameinfo = FindObjectOfType<GameInfo>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = gameinfo.GetScore().ToString();
    }
}
