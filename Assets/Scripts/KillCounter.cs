using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillCounter : MonoBehaviour
{

    public int killCount;
    public Text display;
    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
    }

    private void Update()
    {
        display.text = killCount.ToString();
        if (killCount >= 10) {
            SceneManager.LoadScene("MainMenu");
        }
    }


}
