using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Transform[,] blocksTable;
    public int horizontalMin;
    public int horizontalMax;
    public int verticalMin;
    public float waitTime = 0.1f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        blocksTable = new Transform[23, 10];
    }

    public void RegisterBlock(Transform blockTranform)
    {
        blocksTable[(int)Mathf.Round(blockTranform.position.y), (int)Mathf.Round(blockTranform.position.x)] = blockTranform;
        //Debug.LogError($"Registered at : {blockTranform.position.y} {blockTranform.position.x}");
    }

    public void CheckFilledRow()
    {
        int filledblocks;
        for (int i = 0; i < 20; i++)
        {
            filledblocks = 0;
            for (int j = 0; j < 10; j++)
            {
                if (blocksTable[i, j] != null)
                    filledblocks++;
            }
            if (filledblocks == 10)
            {
                ClearRow(i);
                BringDowm(i + 1);
                Debug.Log($"Row {i} is filled");
                i--;
            }
        }
    }

    void ClearRow(int rowindex)
    {
        for (int i = 0; i < 10; i++)
        {
            Destroy(blocksTable[rowindex, i].gameObject);
            blocksTable[rowindex, i] = null;
        }
    }

    void BringDowm(int rowindex) 
    {
        for (; rowindex < 20; rowindex++)
        {
            for(int i=0; i < 10; i++)
            {
                if(blocksTable[rowindex,i] != null)
                {
                    blocksTable[rowindex, i].Translate(Vector3.down,Space.World);
                    blocksTable[rowindex -1,i] = blocksTable[rowindex, i];
                    blocksTable[rowindex, i] = null;
                }
            }
        }
    }

    public bool CheckForLose()
    {
        for (int i = 0; i <= 9; i++) {
            if (blocksTable[21, i] != null)
            {
                return true;
            }
        }
        if (blocksTable[20, 4] != null)
            return true;
        return false;
    }
}
