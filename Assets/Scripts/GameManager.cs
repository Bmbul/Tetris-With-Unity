using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int horizontalMin;
    public int horizontalMax;
    public int verticalMin;
    public float gameSpeed = 2;
    [Space(20)]
    [SerializeField] ColorTemplates template;
    [SerializeField] SpriteRenderer background;
    [SerializeField] SpriteRenderer[] secondBackground;

    internal int currentScore = 0;
    internal int highScore;
    private int reachScore = 3000;
    int themeIndex;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        highScore = PlayerPrefs.GetInt("high_score", 0);
        themeIndex = PlayerPrefs.GetInt("colorTemplate", 0);
        RecolorAssets(themeIndex);
    }

    void RecolorAssets(int index)
    {
        Transform blocksParent;
        GameColors colors = template.colors[index];
        background.color = colors.background;
        secondBackground[0].color = colors.secondBackground;
        secondBackground[1].color = colors.secondBackground;
        for (int i = 0; i < 7; i++)
        {
            blocksParent = SpawnController.Instance.objects[i].transform.GetChild(0);
            foreach (Transform child in blocksParent)
            {
                child.GetComponent<SpriteRenderer>().color = colors.blockColors[i];
            }
            blocksParent = SpawnController.Instance.nextObjects[i].transform.GetChild(0);
            foreach (Transform child in blocksParent)
            {
                child.GetComponent<SpriteRenderer>().color = colors.blockColors[i];
            }
        }
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
        if (currentScore >= reachScore)
        {
            gameSpeed = gameSpeed * 1.5f;
            reachScore = reachScore * 2;
        }
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
