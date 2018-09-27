using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryAttackPattern : MonoBehaviour {
    public GameObject multiFireBallPrefab;
    public GameObject burstStreamPrafab;
    GameObject player;
    Animator dragonAnime;
    Bullet bullet;

    // Use this for initialization

    private void Awake()
    {
        bullet = multiFireBallPrefab.GetComponent<Bullet>();
        player = GameObject.FindWithTag("Player");
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        set(20f, 5);
        StartCoroutine("attack");
        StartCoroutine("firstAttack");
    }

    private void OnDisable()
    {
        StopCoroutine("attack");
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(3f);
        while (isActiveAndEnabled)
        {
            // first attack
            dragonAnime.SetTrigger("Attack");
            Quaternion rot = direction();
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(bullet.deray);
                Instantiate(multiFireBallPrefab, transform.position, rot);
            }

            yield return new WaitForSeconds(0.1f);

            // second attack
            dragonAnime.SetTrigger("Attack");
            rot = direction();
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(bullet.deray);
                Instantiate(multiFireBallPrefab, transform.position, rot);
            }

            yield return new WaitForSeconds(0.1f);
        }

    }

    IEnumerator firstAttack() {
        yield return new WaitForSeconds(1f);
        Instantiate(burstStreamPrafab, new Vector2(7f, 1f), Quaternion.Euler(0f, 0f, 90f));
    }

    Quaternion direction()
    {
        Vector2 pos = player.transform.position - transform.position;
        pos.Normalize();
        return Quaternion.FromToRotation(Vector3.up, pos);

    }

    void set(float angle, int num)
    {
        MulitFireBall multiFireBall = multiFireBallPrefab.GetComponent<MulitFireBall>();
        multiFireBall.angle = angle;
        multiFireBall.numberOfBullet = num;
    }
}