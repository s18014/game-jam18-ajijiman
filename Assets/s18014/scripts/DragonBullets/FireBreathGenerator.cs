using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathGenerator : MonoBehaviour {
    Bullet bullet;
    public GameObject fireBreathPrefab;
    public float time;
    public float endAngle;
    float curentTime;

	// Use this for initialization
	void Start () {
        bullet = GetComponent<Bullet>();
        StartCoroutine("shot");
	}
	
	// Update is called once per frame
	void Update () {
        curentTime += Time.deltaTime;
        if (curentTime > time) return;
        transform.Rotate(new Vector3(0, 0, endAngle * Time.deltaTime));
    }

    IEnumerator shot () {
        while(true) {
            if (curentTime > time) break;
            Instantiate(fireBreathPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(bullet.deray);
        }
        Destroy(gameObject);
    }

}
