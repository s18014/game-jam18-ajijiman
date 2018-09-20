using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathGenerator : MonoBehaviour {
    Bullet bullet;
    public GameObject fireBreathPrefab;
    public float time;
    float curentTime;

	// Use this for initialization
	void Start () {
        bullet = GetComponent<Bullet>();
        StartCoroutine("shot");
	}
	
	// Update is called once per frame
	void Update () {
        curentTime += Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, -68f * Time.deltaTime));
    }

    IEnumerator shot () {
        while(true) {
            Instantiate(fireBreathPrefab, transform.position, transform.rotation);
            if (curentTime > time) break;
            yield return new WaitForSeconds(bullet.deray);
        }
        Destroy(gameObject);
    }

}
