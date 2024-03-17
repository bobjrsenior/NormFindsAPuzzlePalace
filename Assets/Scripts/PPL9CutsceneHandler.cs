using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPL9CutsceneHandler : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip cutsceneClip;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource.clip = cutsceneClip;
        //audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            PuzzleManager.instance.LoadPuzzle();
        }
    }
}
