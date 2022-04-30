using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject YouLose;
    public static UiManager Instance;

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
}
