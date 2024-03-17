using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutroHandler : MonoBehaviour
{
    public AudioSource audioSource;
    public int state = 0;
    public AudioClip audioClip1;
    public AudioClip audioClip2;
    public AudioClip audioClip3;
    public Image normImage;
    public Image pickImage;
    public Image normMaskImage;

    public float normFadeSpeed = 0.16f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();
        state += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            state += 1;
            if (state == 2)
            {
                normImage.enabled = false;
                normMaskImage.enabled = true;
                audioSource.clip = audioClip2;
                audioSource.Play();
            }
            if (state == 3)
            {
                audioSource.clip = audioClip3;
                audioSource.Play();
            }
            if (state == 4)
            {
                SceneManager.LoadScene(0);
            }
        }
        if (state == 3)
        {
            normMaskImage.color = new UnityEngine.Color(normImage.color.r, normImage.color.g, normImage.color.b, normMaskImage.color.a - normFadeSpeed * Time.deltaTime);
            pickImage.color = new UnityEngine.Color(normImage.color.r, normImage.color.g, normImage.color.b, pickImage.color.a - normFadeSpeed * Time.deltaTime);
        }
    }
}
