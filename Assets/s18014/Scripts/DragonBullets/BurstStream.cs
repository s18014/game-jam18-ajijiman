using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstStream : MonoBehaviour {
    Bullet bullet;
    public GameObject burstFirePrefab;
    public float time;
    float curentTime;

    // Use this for initialization
    void Start()
    {
        bullet = GetComponent<Bullet>();
        time += 1f;
        StartCoroutine("shot");
    }

    // Update is called once per frame
    void Update()
    {
        curentTime += Time.deltaTime;
    }

    IEnumerator shot()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            Instantiate(burstFirePrefab, transform.position, Quaternion.identity);
            if (curentTime > time) break;
            yield return new WaitForSeconds(bullet.deray);
        }
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
