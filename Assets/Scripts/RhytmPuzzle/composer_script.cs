using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class composer_script : MonoBehaviour
{

    private float songPosition;
    private float dspSongTime;
    private AudioSource musicSource;
    private int hitCount;

    private float[] expectedHits = new float[] { 1.322f, 2.75f, 4.77f };
    private List<float> actualHits = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            actualHits.Add((float)(AudioSettings.dspTime - dspSongTime));
            string result = "";
            foreach (var item in actualHits)
            {
                result += item.ToString() + ", ";
            }
            Debug.Log(result);
            hitCount += 1;
        }

        if(!musicSource.isPlaying)
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
