using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDestoy : MonoBehaviour
{
    public bool isPlayer = true;

    private void OnDestroy()
    {
        if (!Data.isGameOver)
            if (isPlayer)
            {
                Data.isGameOver = true;
                Data.isComplete = false;
                Debug.Log("Player Lost");
            }
            else
            {
                Data.isGameOver = true;
                Data.isComplete = true;
                Debug.Log("Player Win");
            }
    }

}
