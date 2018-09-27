using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryAttackPattern2 : MonoBehaviour {
    public GameObject fireBreathGeneratorPrefab;
    public GameObject burstStreamPrafab;


    // Use this for initialization
    private void Awake()
    {
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
        StartCoroutine("firstAttack");
        StartCoroutine("attack");
    }

    private void OnDisable()
    {
        StopCoroutine("attack");
    }

    IEnumerator attack()
    {
        yield return new WaitForSeconds(2f);
        while (isActiveAndEnabled)
        {
            set(5f, 38);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -90f));
            yield return new WaitForSeconds(0.7f);

            set(-5f, 38);
            Instantiate(fireBreathGeneratorPrefab, transform.position, Quaternion.Euler(0f, 0f, -80f));
            yield return new WaitForSeconds(0.7f);
        }
    }

    IEnumerator firstAttack()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(burstStreamPrafab, new Vector2(7f, 3.3f), Quaternion.Euler(0f, 0f, 90f));
        Instantiate(burstStreamPrafab, new Vector2(7f, -3.3f), Quaternion.Euler(0f, 0f, 90f));
    }



    void set(float angle, int num)
    {
        FireBreathGenerator fireBreathGenjrator = fireBreathGeneratorPrefab.GetComponent<FireBreathGenerator>();
        fireBreathGenjrator.angle = angle;
        fireBreathGenjrator.bulletNum = num;
    }
}