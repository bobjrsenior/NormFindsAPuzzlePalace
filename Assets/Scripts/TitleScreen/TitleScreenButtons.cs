using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtons : MonoBehaviour
{
    public RectTransform normImage;
    private int goingLeft = 1;
    private int goingUp = 1;

    public float moveSpeed = 50.0f;

    void Start()
    {
        var random = new System.Random((int) (DateTime.Now.Ticks % Int32.MaxValue));
        goingLeft = random.NextDouble() >= 0.5 ? 1 : -1;
        goingUp = random.NextDouble() >= 0.5 ? 1: -1;
    }

    void Update()
    {
        normImage.anchoredPosition = normImage.anchoredPosition + new UnityEngine.Vector2(moveSpeed * Time.deltaTime * goingLeft, moveSpeed * Time.deltaTime * goingUp);
        if (normImage.anchoredPosition.x < -885 || normImage.anchoredPosition.x > 885)
        {
            normImage.anchoredPosition = new UnityEngine.Vector2(885 * Mathf.Sign(normImage.anchoredPosition.x), normImage.anchoredPosition.y);
            goingLeft *= -1;
        }

        if (normImage.anchoredPosition.y < 75)
        {
            normImage.anchoredPosition = new UnityEngine.Vector2(normImage.anchoredPosition.x, 75.0f);
            goingUp = 1;
        }
        else if (normImage.anchoredPosition.y > 1004.5f)
        {
            normImage.anchoredPosition = new UnityEngine.Vector2(normImage.anchoredPosition.x, 1004.5f);
            goingUp = -1;
        }
    }


    public void BeginButton()
    {
        PuzzleManager.instance.InitializeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
