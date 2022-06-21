using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [Range(0,2)]
    [SerializeField] float transitionTime;
    [SerializeField] Transform themePanel;
    
    ColorTemplates template;

    bool isOpen = false;
    float initialPos;

    private void Awake()
    {
        initialPos = Panel.transform.localPosition.y;
        template = Resources.Load<ColorTemplates>("Colors Template");
    }

    private void Start()
    {
        for(int i = 0; i <= template.colors.Length - 1; i++)
        {
            themePanel.GetChild(i).GetChild(0).GetComponent<Image>().color = template.colors[i].background;
            themePanel.GetChild(i).GetChild(1).GetComponent<Image>().color = template.colors[i].secondBackground;
        }
    }

    public void OnThemeButtonClick()
    {
        if(!isOpen)
            Panel.transform.DOLocalMoveY(-30, transitionTime);
        else
            Panel.transform.DOLocalMoveY(initialPos, transitionTime);
        isOpen = !isOpen;
    }

    public void OnThemeClick(int index)
    {
        OnThemeButtonClick();
        PlayerPrefs.SetInt("colorTemplate", index);
    }
}
