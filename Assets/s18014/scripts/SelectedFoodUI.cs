using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedFoodUI : MonoBehaviour {
    RectTransform[] rects;
    RectTransform thisRect;
    Image image;
    bool isSelected = false;
    public bool IsSelected
    {
        set { isSelected = value; }
    }

	// Use this for initialization
	void Start () {
        rects = GetComponentsInChildren<RectTransform>();
        thisRect = GetComponent<RectTransform>();
        image = transform.Find("Gage").GetComponent<Image>();
        fitToParentSize();
	}
	
	// Update is called once per frame
	void Update () {
        if (isSelected)
        {
            image.fillAmount = 0f;
        }
        else
        {
            image.fillAmount = 1f;
        }
	}

    void fitToParentSize () {
        Vector2 rectSize = thisRect.sizeDelta;
        foreach (RectTransform childRect in rects) {
            childRect.sizeDelta = rectSize;
        }
    }
}