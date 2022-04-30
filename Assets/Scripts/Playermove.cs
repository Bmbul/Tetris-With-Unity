using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    float timer = 0;
    Transform[] blocks;
    Transform rotationAxis;

    void Awake()
    {
        rotationAxis = transform.GetChild(0);
        blocks = new Transform[rotationAxis.childCount];
        for (int i = 0; i < blocks.Length; i++)
        {
            blocks[i] = rotationAxis.GetChild(i);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && CheckforMovement(-1))
        {
            transform.Translate(Vector2.left);
        }
        if (Input.GetKeyDown(KeyCode.D) && CheckforMovement(1))
        {
            transform.Translate(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            CheckforRotation();
        }

        timer = timer + Time.deltaTime;
        if (timer >= GameManager.Instance.waitTime)
        {
            transform.Translate(Vector2.down);
            foreach (var block in blocks)
            {
                if ((int)Mathf.Round(block.position.y) <= GameManager.Instance.verticalMin - 1 ||
                    ManageRows.Instance.blocksTable[(int)Mathf.Round(block.position.y), (int)Mathf.Round(block.position.x)] != null)
                {
                    enabled = false;
                    transform.Translate(Vector2.up);
                    RegistertheBlocks();
                    ManageRows.Instance.CheckFilledRow();
                    if (GameManager.Instance.CheckForLose()) 
                    {
                        GameManager.Instance.SetHighScore();
                        UiManager.Instance.YouLoseDisplay();
                        Time.timeScale = 0;
                    }
                    else
                        SpawnController.Instance.SpawnObject();
                    return;
                }
            }
            timer = 0;
        }
    }

    private bool CheckforMovement(int dir)
    {
        foreach (var block in blocks)
        {
            if (dir == 1)
            {
                if ((int)Mathf.Round(block.position.x) < GameManager.Instance.horizontalMin ||
                    (int)Mathf.Round(block.position.x) > GameManager.Instance.horizontalMax - 1 ||
                    ManageRows.Instance.blocksTable[(int)Mathf.Round(block.position.y), (int)Mathf.Round(block.position.x + 1)] != null)
                    return false;
            }
            else
            { 
                if((int)Mathf.Round(block.position.x) < GameManager.Instance.horizontalMin + 1 ||
                    (int)Mathf.Round(block.position.x) > GameManager.Instance.horizontalMax ||
                    ManageRows.Instance.blocksTable[(int)Mathf.Round(block.position.y), (int)Mathf.Round(block.position.x) - 1] != null)
                return false;
            }
        }
        return true;
    }

    private void CheckforRotation()
    {
        rotationAxis.Rotate(Vector3.forward * 90);

        foreach (var block in blocks)
        {
            if(block.position.x < GameManager.Instance.horizontalMin ||
                    block.position.x > GameManager.Instance.horizontalMax || 
                    block.position.y < GameManager.Instance.verticalMin ||
                    ManageRows.Instance.blocksTable[(int)Mathf.Round(block.position.y),(int) Mathf.Round(block.position.x)] != null)
            {
                rotationAxis.Rotate(Vector3.forward * -90);
                break;
            }
        }
    }

    void RegistertheBlocks()
    {
        foreach(var block in blocks)
        {
            ManageRows.Instance.RegisterBlock(block);
        }
    }
    
    public void GiveRandomRotation()
    {
        int randNumber = Random.Range(0, 4);
        rotationAxis.Rotate(randNumber*Vector3.forward* 90);
    }
}
