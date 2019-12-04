using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject startText;
    public GameObject playerSelect;

    public void ToPlayerSelect()
    {
        startText.SetActive(false);
        playerSelect.SetActive(true);
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
