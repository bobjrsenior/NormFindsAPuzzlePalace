using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormHandler : MonoBehaviour
{
    public Image normImage;
    public Sprite[] puzzleSprites;

    // Start is called before the first frame update
    void Start()
    {
        normImage.sprite = puzzleSprites[PuzzleManager.instance.puzzlePowerLevel];
    }
}
