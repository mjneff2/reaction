﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public int playerCount;
    public GameObject[] playerList;
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        playerList = new GameObject[playerCount];
        for (int k = 0; k < playerList.Length; k++) {
            GameObject newPlayer = Instantiate(playerPrefab, transform.position + k * new Vector3(0, 5, 0), Quaternion.identity) as GameObject;
            ControlStrings controlStrings = newPlayer.GetComponent<ControlStrings>();
            controlStrings.switchAxis += (k + 1);
            if (k > 0) {
                controlStrings.xAxis += (k + 1);
                controlStrings.yAxis += (k + 1);
            } else {
                controlStrings.xAxis = "Mouse X";
                controlStrings.yAxis = "Mouse Y";
            }
            controlStrings.shootButton += (k + 1);
            playerList[k] = newPlayer;
        }
        setViewports(playerList);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setViewports(GameObject[] players) {
            switch (players.Length) {
                case 2:
                    players[0].GetComponent<Camera>().rect = new Rect(0, 0.5f, 1, 0.5f);
                    players[1].GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                    break;
                case 3:
                    players[0].GetComponent<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                    players[1].GetComponent<Camera>().rect = new Rect (0.5f, 0.5f, 0.5f, 0.5f);
                    players[2].GetComponent<Camera>().rect = new Rect(0, 0, 1, 0.5f);
                    break;
                case 4:
                    players[0].GetComponent<Camera>().rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                    players[1].GetComponent<Camera>().rect = new Rect (0.5f, 0.5f, 0.5f, 0.5f);
                    players[2].GetComponent<Camera>().rect = new Rect(0, 0, 0.5f, 0.5f);
                    players[3].GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                    break;
            }
    }
}
