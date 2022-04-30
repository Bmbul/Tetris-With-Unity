using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int horizontalMin;
    public int horizontalMax;
    public int verticalMin;
    public float waitTime = 0.1f;
    public int currentScore = 0;
    public int highScore;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        highScore = PlayerPrefs.GetInt("high_score", 0);
    }

    public bool CheckForLose()
    {
        for (int i = 0; i <= 9; i++) {
            if (ManageRows.Instance.blocksTable[21, i] != null)
            {
                return true;
            }
        }
        if (ManageRows.Instance.blocksTable[20, 4] != null)
            return true;
        return false;
    }

    public void OnRowComplete(int rowCount)
    {
        currentScore = currentScore + rowCount * rowCount * 100;
    }

    public void SetHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("high_score", highScore);
        }
    }
}
