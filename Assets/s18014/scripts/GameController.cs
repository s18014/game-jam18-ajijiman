using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    Text gameStatusText;
    Player player;
    Dragon dragon;
    BulletManager bulletManager;
    GameObject APManager;
    bool isGameClear = false;
    bool isGameOver = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        dragon = GameObject.FindWithTag("Enemy").GetComponent<Dragon>();
        bulletManager = GameObject.FindWithTag("Player").GetComponent<BulletManager>();
        APManager = GameObject.Find("AttackPatternManager");
        gameStatusText = GameObject.Find("ShowGameStatus").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        checkGameStatus();
        showGameStatus();
	}

    void checkGameStatus () {
        if (dragon.hungryPoint <= 0f) {
            isGameClear = true;
        } else if (player.hp <= 0) {
            isGameOver = true;
        }
    }

    void showGameStatus () {
        if (isGameClear) {
            gameStatusText.text = "GAME CLEAR";
            stopControll();
        } else if (isGameOver) {
            gameStatusText.text = "GAME OVER";
            stopControll();
        }
    }

    void stopControll () {
        bulletManager.enabled = false;
        APManager.SetActive(false);
    }
}
