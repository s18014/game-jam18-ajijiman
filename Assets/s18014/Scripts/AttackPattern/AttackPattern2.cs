using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern2 : MonoBehaviour {
    public GameObject fireBreathGeneratorPrefab;
    Animator dragonAnime;
    Bullet bullet;
    bool isAttackabal = true;


    // Use this for initialization
    void Start () {
        bullet = fireBreathGeneratorPrefab.GetComponent<Bullet>();
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (isAttackabal) StartCoroutine("attack");
    }

    IEnumerator attack () {
        isAttackabal = false;

        dragonAnime.SetTrigger("Attack");
        set(200f, 1f);
        Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
        yield return new WaitForSeconds(1.5f);

        dragonAnime.SetTrigger("Attack");
        set(-200f, 1f);
        Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
        yield return new WaitForSeconds(1.5f);

        isAttackabal = true;
    }

    void set (float angle, float time) {
        FireBreathGenerator fireBreathGenjrator = fireBreathGeneratorPrefab.GetComponent<FireBreathGenerator>();
        fireBreathGenjrator.time = time;
        fireBreathGenjrator.endAngle = angle;
    }
}
