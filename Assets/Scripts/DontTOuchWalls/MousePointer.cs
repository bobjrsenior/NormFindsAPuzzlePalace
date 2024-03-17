using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{
    public bool following = false;
    public float maxDistanceStart = 0.25f;
    private float maxDistanceStartSqr = 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //transform.position = mousePosition;
        maxDistanceStartSqr = maxDistanceStart * maxDistanceStart;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!following && (mousePosition - (Vector2)transform.position).sqrMagnitude < maxDistanceStartSqr)
        {
            following = true;
        }
        if (following)
        {
            transform.position = mousePosition;
        }
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!PuzzleManager.instance.playingAudioBeforePuzzle)
        {
            if (col.transform.tag.Equals("Wall"))
            {
                PuzzleManager.instance.LosePuzzle();
            }
            else if (col.transform.tag.Equals("Goal"))
            {
                PuzzleManager.instance.WinPuzzle();
            }
        }
    }
}
