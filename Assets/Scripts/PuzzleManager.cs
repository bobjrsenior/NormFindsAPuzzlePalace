using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public int[] puzzleSceneIds = {2, 5};
    public int puzzlesWon = 0;
    public int puzzlesLost = 0;
    public int puzzlePowerLevel = 0;
    public bool playingAudioBeforePuzzle = false;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip ppl1Clip;
    public AudioClip ppl2Clip;
    public AudioClip ppl3Clip;
    public AudioClip ppl4Clip;
    public AudioClip ppl5Clip;
    public AudioClip ppl6Clip;
    public AudioClip ppl7Clip;
    public AudioClip ppl8Clip;
    public AudioClip ppl9Clip;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (playingAudioBeforePuzzle)
        {
            if (!audioSource2.isPlaying)
            {
                playingAudioBeforePuzzle = false;
                LoadPuzzle();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void InitializeGame()
    {
        puzzlesWon = 0;
        puzzlesLost = 0;
        puzzlePowerLevel = 0;
        audioSource1.volume = (puzzlePowerLevel / 9.0f);
        playingAudioBeforePuzzle = false;
    }

    public void WinPuzzle()
    {
        puzzlesWon += 1;
        if (puzzlesWon % 2 == 0)
        {
            if (puzzlePowerLevel == 9)
            {
                SceneManager.LoadScene(4);
                return;
            }
            puzzlePowerLevel += 1;
            audioSource1.volume = (puzzlePowerLevel / 9.0f);
            switch (puzzlePowerLevel)
            {
                case 1:
                    audioSource2.Stop();
                    audioSource2.clip = ppl1Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 2:
                    audioSource2.Stop();
                    audioSource2.clip = ppl2Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 3:
                    audioSource2.Stop();
                    audioSource2.clip = ppl3Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 4:
                    audioSource2.Stop();
                    audioSource2.clip = ppl4Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 5:
                    audioSource2.Stop();
                    audioSource2.clip = ppl5Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 6:
                    audioSource2.Stop();
                    audioSource2.clip = ppl6Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 7:
                    audioSource2.Stop();
                    audioSource2.clip = ppl7Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 8:
                    audioSource2.Stop();
                    audioSource2.clip = ppl8Clip;
                    audioSource2.Play();
                    playingAudioBeforePuzzle = true;
                return;
                case 9:
                    //audioSource2.Stop();
                    //audioSource2.clip = ppl9Clip;
                    //audioSource2.Play();
                    SceneManager.LoadScene(3);
                return;
            }
        }
        LoadPuzzle();
    }

    public void LosePuzzle()
    {
        puzzlesLost += 1;
        LoadPuzzle();
    }

    public void LoadPuzzle()
    {
        var random = new System.Random((int) (System.DateTime.Now.Ticks % System.Int32.MaxValue));
        SceneManager.LoadScene(puzzleSceneIds[random.Next(0, puzzleSceneIds.Length)]);
    }
}
