using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject YouLose;
    public static UiManager Instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject pausePanel;
    [SerializeField] Slider SFXslider;
    [SerializeField] Slider Backgroundslider;

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
        SetSliderValue();
    }

    public void SetScore() 
    {
        scoreText.text = $"Score: {GameManager.Instance.currentScore}";
        highScoreText.text = $"High Score: {GameManager.Instance.highScore}";
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartingScreen");
        Time.timeScale = 1;
    }
    
    public void TurnOffStartText()
    {
        startText.SetActive(false);
    }

    public void OnContinueButtonClicked()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnHomeButtonClicked()
    {
        MainMenuButton();
    }

    public void OnPauseButtonClicked()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void SetSliderValue()
    {
        SFXslider.value = PlayerPrefs.GetFloat("SFX_slider", 0.5f);
        Backgroundslider.value = PlayerPrefs.GetFloat("background_slider", 0.25f);
    }

    public void OnSFXValueChange()
    {
        PlayerPrefs.SetFloat("SFX_slider", SFXslider.value);
        AudioManager.Instance.sfx_source.volume = SFXslider.value;
    }

    public void OnBackgroundValueChange()
    {
        PlayerPrefs.SetFloat("background_slider", Backgroundslider.value);
        AudioManager.Instance.background_source.volume = Backgroundslider.value;

    }
}
