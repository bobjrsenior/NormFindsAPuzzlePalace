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

    public void InitializeGame()
    {
        puzzlesWon = 0;
        puzzlesLost = 0;
        puzzlePowerLevel = 0;
    }

    public void WinPuzzle()
    {
        puzzlesWon += 1;
        if (puzzlesWon % 2 == 0)
        {
            puzzlePowerLevel += 1;
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
