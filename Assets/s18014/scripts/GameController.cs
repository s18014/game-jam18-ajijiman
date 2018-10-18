using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    Player player;
    Dragon dragon;
    bool isGameClear = false;
    bool isGameOver = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        dragon = GameObject.FindWithTag("Enemy").GetComponent<Dragon>();
	}
	
	// Update is called once per frame
	void Update () {
        checkGameStatus();
	}

    void checkGameStatus () {
        if (dragon.hungryPoint <= 0f) {
            isGameClear = true;
        } else if (player.hp <= 0) {
            isGameOver = true;
        }
    }
}
