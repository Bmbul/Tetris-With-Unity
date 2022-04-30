using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController Instance;
    [SerializeField] GameObject[] objects;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObject()
    {
        int RandomNumber = Random.Range(0, objects.Length);
        GameObject BuiltObject = Instantiate(objects[RandomNumber]);
        BuiltObject.GetComponent<Playermove>().GiveRandomRotation();
    }
}
