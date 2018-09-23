using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour {
    public GameObject dangerAreaPrefab;
    float angleZ;
    float angleY = 90f;

	// Use this for initialization
	void Start () {
        Vector2 pos = transform.position;
        pos.x -= 13f;
        Instantiate(dangerAreaPrefab, pos, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        angleZ += 30f * Time.deltaTime;
        angleY -= 5f * Time.deltaTime;
        if (angleY < 87f) angleY = 87f;
        transform.rotation = Quaternion.Euler(0f, angleY, angleZ);
	}
}
