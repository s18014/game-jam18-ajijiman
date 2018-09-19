/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public GameObject[] bullets;
    public int equip;
    float[] coolTimes;
    float[] lapTimes;
    bool[] isShotables;

	// Use this for initialization
	void Start () {
        coolTimes = new float[bullets.Length];
        lapTimes = new float[bullets.Length];
        isShotables = new bool[bullets.Length];
        for (int i = 0; i < bullets.Length; i++) {
            Debug.Log(bullets[i].GetComponent<Bullet>());
            lapTimes[i] = 0f;
            isShotables[i] = true;
            coolTimes[i] = bullets[i].GetComponent<Bullet>().coolTime;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void FixedUpdate()
    {
        isShotable();
    }

    public void shot (Transform origin) {
        // 弾を撃つ
        if (!isShotables[equip]) {
            return;
        }
        Instantiate(
            bullets[equip],
            origin.transform.position,
            Quaternion.identity
        );
        lapTimes[equip] = 0f;
        isShotables[equip] = false;
    }

    void isShotable () {
        // クールタイムの状態をチェック
        for (int i = 0; i < bullets.Length; i++)
        {
            lapTimes[i] += Time.deltaTime;
            if (lapTimes[i] >= coolTimes[i]) {
                isShotables[i] = true;
            }
        }

    }
}
*/