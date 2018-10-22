using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {
    public float maxHungryPoint;
    public float hungryPoint;
    public float maxAngryPoint;
    public float angryPoint;
    public bool isAngry;
    public bool isTired;
    public int angryCount;
    public GameObject burnEffectPrefab;
    public AudioClip dragonScreemSE;
    public AudioClip dragonExprosionSE;
    private AudioSource audioSource;
    Animator animator;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        hungryPoint = maxHungryPoint;
        angryPoint = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        checkAngry();
	}


    void checkAngry () {
        if (angryPoint >= maxAngryPoint && !isAngry) {
            audioSource.PlayOneShot(dragonScreemSE);
            AudioSource.PlayClipAtPoint(dragonExprosionSE, Vector2.zero);
            isAngry = true;
            angryCount += 1;
            animator.SetBool("isAngry", true);
            Instantiate(burnEffectPrefab, transform.position, Quaternion.identity);
            angryPoint = maxAngryPoint;
            if (hungryPoint > maxHungryPoint) hungryPoint = maxHungryPoint;
        }

        if (angryPoint <= 0f && isAngry) {
            isAngry = false;
            animator.SetBool("isAngry", false);
            angryPoint = 0f;
        }
    }

    public void playSleepSound() {
        audioSource.pitch = 0.5f;
        audioSource.PlayOneShot(dragonScreemSE);
    }
}
