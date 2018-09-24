using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstStream : MonoBehaviour {
    Bullet bullet;
    public GameObject burstFirePrefab;
    public float time;
    public float deray;
    float curentTime;

    // Use this for initialization
    void Start()
    {
        bullet = GetComponent<Bullet>();
        time += deray;
        StartCoroutine("shot");
    }

    // Update is called once per frame
    void Update()
    {
        curentTime += Time.deltaTime;
    }

    IEnumerator shot()
    {
        yield return new WaitForSeconds(deray);
        while (true)
        {
            Instantiate(burstFirePrefab, transform.position, transform.rotation);
            if (curentTime > time) break;
            yield return new WaitForSeconds(bullet.deray);
        }
        Destroy(gameObject);
    }
}
