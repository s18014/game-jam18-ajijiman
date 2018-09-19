using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChageUI : MonoBehaviour {
    RectTransform[] rects;
    RectTransform thisRect;

	// Use this for initialization
	void Start () {
        rects = GetComponentsInChildren<RectTransform>();
        thisRect = GetComponent<RectTransform>();
        fitToParentSize();
	}
	
	// Update is called once per frame
	void Update () {
        test();
	}

    void fitToParentSize () {
        Vector2 rectSize = thisRect.sizeDelta;
        foreach (RectTransform childRect in rects) {
            childRect.sizeDelta = rectSize;
        }
    }

    void test () {
        Image gage = this.transform.Find("Gage").GetComponent<Image>();
        gage.fillAmount -= 0.1f * Time.deltaTime;
    }
}
