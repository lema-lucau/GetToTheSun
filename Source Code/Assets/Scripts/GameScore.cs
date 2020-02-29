using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public Text gameScoreText;
    public static int gameScore;
    public static int levelScore;

    // Update is called once per frame
    void Update()
    {
        if(gameScore <= 0)
        {
            gameScore = 0;
        }

        gameScoreText.text = "" + gameScore;
    }

    public static void AddScore(int score)
    {
        gameScore = gameScore + score;
        levelScore = levelScore + score;
    }

    public static void setLevelScore()
    {
        levelScore = 0;
    }
    public static void SubScore()
    {
        gameScore = gameScore - levelScore;
    }

    public static void MinusScore(int score)
    {
        gameScore = gameScore - score;
    }

    public static void resetScore()
    {
        gameScore = 0;
        levelScore = 0;

    }

    public static void EndPoints(int time)
    {

    }
}
