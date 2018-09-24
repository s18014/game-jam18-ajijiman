using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern1 : MonoBehaviour {
    public GameObject multiFireBallPrefab;
    GameObject player;
    Animator dragonAnime;
    Bullet bullet;
    bool isAttackabal = true;

	// Use this for initialization
	void Start () {
        bullet = multiFireBallPrefab.GetComponent<Bullet>();
        player = GameObject.FindWithTag("Player");
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
        set();
	}
	
	// Update is called once per frame
	void Update () {
        if (isAttackabal) StartCoroutine("attack");
	}

    IEnumerator attack () {
        isAttackabal = false;

        // first attack
        dragonAnime.SetTrigger("Attack");
        Quaternion rot = direction();
        for (int i = 0; i < 3; i++) {
            yield return new WaitForSeconds(bullet.deray);
            Instantiate(multiFireBallPrefab, transform.position, rot);
        }

        yield return new WaitForSeconds(1f);

        // second attack
        dragonAnime.SetTrigger("Attack");
        rot = direction();
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(bullet.deray);
            Instantiate(multiFireBallPrefab, transform.position, rot);
        }

        yield return new WaitForSeconds(1f);

        isAttackabal = true;
    }

    Quaternion direction () {
        Vector2 pos = player.transform.position - transform.position;
        pos.Normalize();
        return Quaternion.FromToRotation(Vector3.up, pos);

    }

    void set () {
        MulitFireBall multiFireBall = multiFireBallPrefab.GetComponent<MulitFireBall>();
        multiFireBall.angle = 30;
        multiFireBall.numberOfBullet = 3;
    }
}
