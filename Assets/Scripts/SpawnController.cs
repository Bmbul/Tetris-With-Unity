using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnController : MonoBehaviour
{
    public static SpawnController Instance;
    public GameObject[] objects;
    public GameObject[] nextObjects;
    bool GameStarted = false;
    int RandomNumber;
    int RandomRot;

    private void Start()
    {
        RandomNumber = Random.Range(0, objects.Length);
        RandomRot = Random.Range(0, 4);
        nextObjects[RandomNumber].transform.eulerAngles = new Vector3(0,0, RandomRot*90);
        nextObjects[RandomNumber].SetActive(true);
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    void Update()
    {
        if (GameStarted == false && Input.anyKey)
        { 
            SpawnObject();
            UiManager.Instance.TurnOffStartText();
            GameStarted = true;
        }
    }

    public void SpawnObject()
    {
        GameObject BuiltObject = Instantiate(objects[RandomNumber]);
        BuiltObject.GetComponent<Playermove>().GiveRandomRotation(RandomRot);
        UpdateNextObject();
    }

    public void UpdateNextObject()
    {
        nextObjects[RandomNumber].SetActive(false);
        RandomNumber = Random.Range(0, objects.Length);
        RandomRot = Random.Range(0, 4);
        nextObjects[RandomNumber].transform.eulerAngles = new Vector3(0, 0, RandomRot * 90);
        nextObjects[RandomNumber].SetActive(true);
    }
}
