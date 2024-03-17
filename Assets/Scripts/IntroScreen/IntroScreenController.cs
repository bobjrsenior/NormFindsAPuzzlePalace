using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroScreenController : MonoBehaviour
{
    public int introState = 0;
    public UnityEngine.UI.Image puzzlePalaceImage;
    public TextMeshProUGUI introText;
    public UnityEngine.UI.Image normImage;
    public UnityEngine.UI.Image normImageBorder;
    public float normMoveSpeed = 10.0f;
    public float normFadeSpeed = 0.16f;
    public float normAlphaStop = 0.005f;

    public float state3Timer = 8.0f;
    public float state5Timer = 2.0f;

    public AudioSource audioSource;
    public AudioClip state1AudioClip;
    public AudioClip state2AudioClip;
    public UnityEngine.UI.Image forrestImage;

    // Start is called before the first frame update
    void Start()
    {
        //introState += 1;
        addToState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            addToState();
        }
        if (introState == 1)
        {
            if (!audioSource.isPlaying)
            {
                addToState();
            }
        }
        if (introState == 2)
        {
            if (!audioSource.isPlaying)
            {
                addToState();
            }
        }
        if (introState == 3)
        {

            state3Timer -= Time.deltaTime;
            if (state3Timer <= 0)
            {
                addToState();
            }
            normImage.rectTransform.position = new Vector2(normImage.rectTransform.position.x, normImage.rectTransform.position.y + normMoveSpeed * Time.deltaTime * ScreenMultipliers.verticalMultiplier);
            normImageBorder.rectTransform.position = new Vector2(normImageBorder.rectTransform.position.x, normImageBorder.rectTransform.position.y - normMoveSpeed * Time.deltaTime * ScreenMultipliers.verticalMultiplier);

            
        }
        else if (introState == 4)
        {
            normImage.color = new UnityEngine.Color(normImage.color.r, normImage.color.g, normImage.color.b, normImage.color.a - normFadeSpeed * Time.deltaTime);
            if (normImage.color.a < normAlphaStop)
            {
                normImage.color = new UnityEngine.Color(normImage.color.r, normImage.color.g, normImage.color.b, 0);
                addToState();
            }
        }
        else if (introState == 5)
        {
            state5Timer -= Time.deltaTime;
            if (state5Timer <= 0)
            {
                addToState();
            }
        }
    }

    public void addToState()
    {
        introState +=1;
        switch(introState)
        {
            case 1:
                forrestImage.enabled = true;
                audioSource.Stop();
                audioSource.clip = state1AudioClip;
                audioSource.Play();
            break;
            case 2:
                introText.enabled = false;
                forrestImage.enabled = false;
                puzzlePalaceImage.enabled = true;
                audioSource.Stop();
                audioSource.clip = state2AudioClip;
                audioSource.Play();
            break;
            case 3:

            break;
            case 4:

            break;
            case 6:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            break;
            default: break;
        }
    }
}
