using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPatternManager : MonoBehaviour {
    GameObject[] attackPatterns;
    Dragon dragon;
    Animator dragonAnim;

    // Use this for initialization
    private void Awake()
    {
        attackPatterns = new GameObject[transform.childCount];
        for (int i = 0; transform.childCount > i; i++) {
            attackPatterns[i] = transform.GetChild(i).gameObject;
        }
        setInactive();
    }

    void Start () {
        dragon = GameObject.FindWithTag("Enemy").GetComponent<Dragon>();
        dragonAnim = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (dragon.isAngry) swichingAngryPattern(); else swichingPattern();
        if (dragon.isTired)
        {
            dragon.angryPoint -= 100f * Time.deltaTime;
            if (dragon.angryPoint < 0f) dragon.angryPoint = 0f;
        }
        if (dragon.hungryPoint <= 0f) {
            setInactive();
            enabled = false;
            dragonAnim.SetBool("isSleep", true);
        }

    }

    void setInactive () {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject obj in objs) {
            Destroy(obj);
        }
        foreach (GameObject obj in attackPatterns)
        {
            obj.SetActive(false);
        }
    }


    void swichingPattern() {
        if (dragon.isTired) {
            if (!attackPatterns[8].activeSelf) {
                setInactive();
                attackPatterns[8].SetActive(true);
                dragon.angryPoint = 0f;
            }
            return;
        }
        float ratio = dragon.hungryPoint / dragon.maxHungryPoint;
        if (ratio > 0.8) {
            if (!attackPatterns[0].activeSelf) {
                setInactive();
                attackPatterns[0].SetActive(true);
            }
        } else if (ratio > 0.6) {
            if (!attackPatterns[1].activeSelf) {
                setInactive();
                attackPatterns[1].SetActive(true);
            }
        } else if (ratio > 0.3) {
            if (!attackPatterns[2].activeSelf) {
                setInactive();
                attackPatterns[2].SetActive(true);
            }
        } else {
            if (!attackPatterns[3].activeSelf) {
                setInactive();
                attackPatterns[3].SetActive(true);
            }
        }
    }

    void swichingAngryPattern()
    {
        if (dragon.angryCount == 1)
        {
            if (!attackPatterns[4].activeSelf)
            {
                setInactive();
                attackPatterns[4].SetActive(true);
            }
        }
        else if (dragon.angryCount == 2)
        {
            if (!attackPatterns[5].activeSelf)
            {
                setInactive();
                attackPatterns[5].SetActive(true);
            }
        }
        else if (dragon.angryCount == 3)
        {
            if (!attackPatterns[6].activeSelf)
            {
                setInactive();
                attackPatterns[6].SetActive(true);

            }
        }
        else if (dragon.angryCount == 4)
        {
            if (!attackPatterns[7].activeSelf)
            {
                setInactive();
                attackPatterns[7].SetActive(true);
            }
        }
    }
}
