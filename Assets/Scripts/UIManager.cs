using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startButton;
    public GameObject quitButton;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public void ToPlayerSelect()
    {
        startButton.SetActive(false);
        quitButton.SetActive(false);
        player2.SetActive(true);
        player3.SetActive(true);
        player4.SetActive(true);
    }

    public void StartGame(int playerCount)
    {
        Parameters.playerCount = playerCount;
        SceneManager.LoadScene("MapScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
