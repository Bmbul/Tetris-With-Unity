using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject YouLose;
    public static UiManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    public void YouLoseDisplay()
    {
        YouLose.SetActive(true);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Start()
    {
        SetScore();
    }
    public void SetScore() 
    {
        scoreText.text = $"Score: {GameManager.Instance.currentScore}";
        highScoreText.text = $"High Score: {GameManager.Instance.highScore}";
    }
}
