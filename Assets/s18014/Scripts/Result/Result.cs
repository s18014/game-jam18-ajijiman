using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour {
    Text ClearTimeText;
    Text RemainingLifeText;
    Text AngryTimesText;
    Text BonusText;
    Text BarText;
    Text ScoreText;
    int score = 0;
    float time;
    int life;
    int angryCount;
    bool isFinalAttackClear;

	// Use this for initialization
	void Start () {
        BonusText = transform.Find("BonusText").gameObject.GetComponent<Text>();
        RemainingLifeText = transform.Find("RemainingLifeText").gameObject.GetComponent<Text>();
        ScoreText = transform.Find("ScoreText").gameObject.GetComponent<Text>();
        AngryTimesText = transform.Find("AngryTimesText").gameObject.GetComponent<Text>();
        life = GameController.getLife();
        angryCount = GameController.getAngryCount();
        isFinalAttackClear = GameController.getIsFinalAttackClear();
        if (isFinalAttackClear)
        {
            BonusText.text = "限界を超えた: +10000";
            score += 10000;
        }
        AngryTimesText.text += " " + angryCount + "回     +" + angryCount * 1000;
        score += angryCount * 1000;
        RemainingLifeText.text += " " + life + "個     +" + life * 3000;
        score += life * 3000;
        ScoreText.text += " " + score;
    }
	
	// Update is called once per frame
	void Update () {
	}
}
