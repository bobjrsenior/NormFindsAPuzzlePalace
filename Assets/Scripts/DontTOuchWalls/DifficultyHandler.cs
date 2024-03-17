using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler : MonoBehaviour
{
    public Camera camera;
    public SpriteRenderer[] walls;
    public Color[] colorTargets;
    public float colorChangeSpeed;
    private System.Random random;
    private float camTargetY;
    private float camTargetX;
    private float camMoveSpeed;
    public MousePointer mousePointer;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        random = new System.Random((int) (System.DateTime.Now.Ticks % System.Int32.MaxValue));
        colorTargets = new Color[walls.Length];
        for(int i = 0; i < colorTargets.Length; i++)
        {
            colorTargets[i] = new Color((float) random.NextDouble(), (float) random.NextDouble(), (float) random.NextDouble());
        }
        colorChangeSpeed = 0.15f * PuzzleManager.instance.puzzlePowerLevel;

        camTargetY = ((float)random.NextDouble() * 6.15f) - 3.75f;
        camTargetX = ((float)random.NextDouble() * 6f) - 3f;
        camMoveSpeed = 0.5f + (0.15f * PuzzleManager.instance.puzzlePowerLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (PuzzleManager.instance.puzzlePowerLevel >= 2)
        {
            // Colors
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i].color = Color.Lerp(walls[i].color, colorTargets[i], colorChangeSpeed * Time.deltaTime);
                if (Mathf.Abs(SumColor(walls[i].color) - SumColor(colorTargets[i])) < 0.2f)
                {
                    colorTargets[i] = new Color((float) random.NextDouble(), (float) random.NextDouble(), (float) random.NextDouble());
                }
            }
        }
        if (mousePointer.following)
        {
            if (PuzzleManager.instance.puzzlePowerLevel > 4)
            {
                // Camera movement
                float ySign = Mathf.Sign(camTargetY - camera.transform.position.y);
                camera.transform.position = camera.transform.position + new Vector3(0, ySign * camMoveSpeed * Time.deltaTime, 0);

                if (Mathf.Abs(camTargetY - camera.transform.position.y) < 0.25f)
                {
                    camTargetY = ((float)random.NextDouble() * 6.15f) - 3.75f;
                }
            }
            if (PuzzleManager.instance.puzzlePowerLevel >= 7)
            {
                // Camera movement
                float xSign = Mathf.Sign(camTargetY - camera.transform.position.y);
                camera.transform.position = camera.transform.position + new Vector3(xSign * camMoveSpeed * Time.deltaTime, 0, 0);

                if (Mathf.Abs(camTargetX - camera.transform.position.x) < 0.25f)
                {
                    camTargetX = ((float)random.NextDouble() * 6.15f) - 3.75f;
                }
            }
            mousePointer.yOffset = -camera.transform.position.y;
            mousePointer.xOffset = -camera.transform.position.x;
        }
    }

    float SumColor(Color a)
    {
        return a.r + a.g + a.b;
    }
}
