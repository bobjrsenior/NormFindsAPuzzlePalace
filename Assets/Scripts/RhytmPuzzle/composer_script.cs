using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class composer_script : MonoBehaviour
{

    private float songPosition;
    public float dspSongTime;
    private AudioSource musicSource;
    private int hitCount;

    private int mutePos = 0;

    private float[,] muteTimes = new float[9, 4]
    {
        { -1f, -1f, -1f, -1f },
        { 1.0f, -1f, -1f, -1f },
        { 2.0f, -1f, -1f, -1f },
        { 3.5f, -1f, -1f, -1f },
        { 1.0f, 2.0f, -1f, -1f },
        { 1.0f, 2.0f, 3.5f, -1f },
        { 1.0f, 3.0f, -1f, -1f },
        { 1.0f, -1f, -1f, -1f },
        { 0f, -1f, -1f, -1f }
    };


    private float[,] unMuteTimes = new float[9, 4]
    {
        { -1f, -1f, -1f, -1f },
        { -1f, 2.0f, -1f, -1f},
        { -1f, 4.0f, -1f, -1f},
        { -1f, 5.5f, -1f, -1f },
        { -1f, 1.5f, 4.0f, -1f},
        { -1f, 1.5f, 3.0f, 5.5f },
        { -1f, 2.0f, -1f, -1f },
        { -1f, -1f, -1f, -1f },
        { -1f, -1f, -1f, -1f }
    };



    private float[] expectedHits = new float[] { 0.463f, 1.947f, 4.023f };
    private List<float> actualHits = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

        songPosition = musicSource.time;

        if(Input.GetMouseButtonDown(0))
        {
            actualHits.Add(songPosition);
            string result = "";
            foreach (var item in actualHits)
            {
                result += item.ToString() + ", ";
            }
            Debug.Log(result);
            hitCount += 1;
        }

        //check if we toggle mute 
        if(Mathf.Abs(songPosition - muteTimes[PuzzleManager.instance.puzzlePowerLevel, mutePos]) < .01f)
        {
            musicSource.volume = 0f;
            mutePos += 1;
        }

        if (Mathf.Abs(songPosition - unMuteTimes[PuzzleManager.instance.puzzlePowerLevel, mutePos]) < .1f)
        {
            musicSource.volume = 1f;
        }

        if (!musicSource.isPlaying)
        {
            evaluateScore();
        }

    }

    void evaluateScore()
    {
        bool evaluation = true;
        if (hitCount != 3)
        {
            evaluation = false;
        }else
        {
            for (int j = 0; j < expectedHits.Length; j++)
            {
                Debug.Log("" + actualHits[j] + ", " +  expectedHits[j]);

                float timing = actualHits[j] - expectedHits[j];
                Debug.Log(timing);
                evaluation = evaluation && Mathf.Abs(timing) < .25;
            }
        }
        if(evaluation == true)
        {
            Debug.Log("puzzle won");
            PuzzleManager.instance.WinPuzzle();
        } else
        {
            Debug.Log("puzzle lost");
            PuzzleManager.instance.LosePuzzle();
        }

    }
    
}
