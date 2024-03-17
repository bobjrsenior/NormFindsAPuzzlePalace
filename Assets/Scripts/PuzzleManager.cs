using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager instance;

    public int[] puzzleSceneIds = {2};
    public int puzzlesWon = 0;
    public int puzzlesLost = 0;
    public int puzzlePowerLevel = 0;
    public bool playingAudioBeforePuzzle = false;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip ppl1Clip;

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
                LoadPuzzle();
            }
        }
    }

    public void InitializeGame()
    {
        puzzlesWon = 0;
        puzzlesLost = 0;
        puzzlePowerLevel = 0;
        playingAudioBeforePuzzle = false;
    }

    public void WinPuzzle()
    {
        puzzlesWon += 1;
        if (puzzlesWon % 2 == 0)
        {
            audioSource1.volume = (puzzlePowerLevel / 9);
            puzzlePowerLevel += 1;
            switch (puzzlePowerLevel)
            {
                case 1:
                    audioSource2.Stop();
                    audioSource2.clip = ppl1Clip;
                    audioSource2.Play();
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
