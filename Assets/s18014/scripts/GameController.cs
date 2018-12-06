using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    Text gameStatusText;
    Player player;
    Dragon dragon;
    BulletManager bulletManager;
    GameObject APManager;
    bool isGameClear = false;
    bool isGameOver = false;
    bool sceneSwitch = false;

    // Propaty for ResultScene
    public static float time;
    public static int lifePoint;
    public static int angryCount;
    public static bool isFinalAttackClear = false;

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
        if ((isGameOver || isGameClear) && !sceneSwitch)
        {
            lifePoint = player.hp;
            angryCount = dragon.angryCount;
            if (angryCount >= 4)
            {
                isFinalAttackClear = true;
            }
            StartCoroutine("moveResultScene");
            sceneSwitch = true;
        }
    }

    public static int getLife () {
        return lifePoint;
    }

    public static int getAngryCount () {
        return angryCount;
    }

    public static bool getIsFinalAttackClear () {
        return isFinalAttackClear;
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
            bulletManager.enabled = false;
        }
        else if (isGameOver) {
            gameStatusText.text = "GAME OVER";
            bulletManager.enabled = false;
            APManager.SetActive(false);
        }
    }

    IEnumerator moveResultScene ()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Result");
    }
}
