using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartingSceneUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI startText;
    [SerializeField] Color enterColor;
    [SerializeField] Color exitColor;

    public void OnPointer()
    {

        startText.color = enterColor;
    }

    public void offPointer() 
    {
        startText.color = exitColor;
    }

    public void SwitchScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
