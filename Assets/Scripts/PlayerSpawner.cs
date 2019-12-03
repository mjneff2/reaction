using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Range(1,4)]
    public int playerCount;

    public GameObject[] playerList;
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        playerList = new GameObject[playerCount];
        GameObject spawners = transform.Find("Spawnpoints").gameObject;
        for (int k = 0; k < playerList.Length; k++) {
            GameObject newPlayer = Instantiate(playerPrefab, spawners.transform.GetChild(k).position, Quaternion.identity) as GameObject;
            playerList[k] = newPlayer;
        }
        setViewports(playerList);
        setColors(playerList);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setViewports(GameObject[] players) {
            switch (players.Length) {
                case 2:
                    players[0].GetComponentInChildren<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
                    players[1].GetComponentInChildren<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                    break;
                case 3:
                    players[0].GetComponentInChildren<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                    players[1].GetComponentInChildren<Camera>().rect = new Rect (0.5f, 0.5f, 0.5f, 0.5f);
                    players[2].GetComponentInChildren<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                    break;
                case 4:
                    players[0].GetComponentInChildren<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                    players[1].GetComponentInChildren<Camera>().rect = new Rect (0.5f, 0.5f, 0.5f, 0.5f);
                    players[2].GetComponentInChildren<Camera>().rect = new Rect(0, 0, 0.5f, 0.5f);
                    players[3].GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                    break;
            }
    }

    void setColors(GameObject[] players) {
        for (int k = 0; k < players.Length; k++) {
            Material mat = players[k].GetComponent<Renderer>().material;
            switch (k) {
                case 1:
                    mat.SetColor("_Color", Color.red);
                    break;
                case 2:
                    mat.SetColor("_Color", Color.green);
                    break;
                case 3:
                    mat.SetColor("_Color", Color.yellow);
                    break;
            }
        }
    }
}
