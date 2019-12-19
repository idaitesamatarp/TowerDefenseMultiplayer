using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AutoReplay : MonoBehaviour
{
    float timer = 0;
    public Text info;

    // Start is called before the first frame update
    void Start()
    {
        if (Data.isComplete)
        {
            info.text = "Congratulations \n You Win!";
        }
        else
        {
            info.text = "Game Over \n You Lose!";
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Data.isGameOver = false;
            Data.isComplete = false;
            Data.coin = 0;
            SceneManager.LoadScene("Gameplay");
        }
    }
}
