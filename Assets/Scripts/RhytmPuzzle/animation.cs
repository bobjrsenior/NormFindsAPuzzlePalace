using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField]
    private composer_script composer;
    private float[] expectedHits = new float[] { 1.398f, 2.853f, 4.993f };

    public GameObject movingHandle;
    public float speed = 0.1f;
    private Quaternion rotation1 = Quaternion.Euler(0, 0, 0);
    private Quaternion rotation2 = Quaternion.Euler(0, 0, 120);

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            print(movingHandle.transform.rotation.eulerAngles.x);
            StartCoroutine(RotateOverTime(rotation1, rotation2, 1f / speed));
        }
    }

    IEnumerator RotateOverTime(Quaternion originalRotation, Quaternion finalRotation, float duration)
    {
        if (duration > 0f)
        {
            Debug.Log("swinging pick");
            float startTime = Time.deltaTime;
            float endTime = startTime + duration;
            movingHandle.transform.rotation = originalRotation;
            yield return null;
            while (Time.deltaTime < endTime)
            {
                float progress = (Time.deltaTime - startTime) / duration;
                // progress will equal 0 at startTime, 1 at endTime.
                movingHandle.transform.rotation = Quaternion.Slerp(originalRotation, finalRotation, progress);
                yield return null;
            }
        }
        movingHandle.transform.rotation = finalRotation;
    }
}
