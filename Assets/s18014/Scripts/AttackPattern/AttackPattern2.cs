﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPattern2 : MonoBehaviour {
    public GameObject fireBreathGeneratorPrefab;
    Animator dragonAnime;


    // Use this for initialization
    private void Awake()
    {
        dragonAnime = GameObject.FindWithTag("Enemy").GetComponent<Animator>();
    }
    void Start () {
    }

    // Update is called once per frame
    void Update () {
    }

    private void OnEnable()
    {
        StartCoroutine("attack");
    }

    private void OnDisable()
    {
        StopCoroutine("attack");
    }

    IEnumerator attack () {
        yield return new WaitForSeconds(1f);
        while (isActiveAndEnabled)
        {
            dragonAnime.SetTrigger("Attack");
            set(200f, 1f);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
            yield return new WaitForSeconds(1.5f);

            dragonAnime.SetTrigger("Attack");
            set(-200f, 1f);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
            yield return new WaitForSeconds(1.5f);
        }
    }

    void set (float angle, float time) {
        FireBreathGenerator fireBreathGenjrator = fireBreathGeneratorPrefab.GetComponent<FireBreathGenerator>();
        fireBreathGenjrator.time = time;
        fireBreathGenjrator.endAngle = angle;
    }
}
