using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    Image image = null;
    Coroutine currentFlashRoutine = null;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForOneFlash, float maxAlpha, Color newColor)
    {
        image.color = newColor;

        //Ensure maxAlpha is not above 1
        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);

        if(currentFlashRoutine != null)
        {
            StopCoroutine(currentFlashRoutine);
        }
        currentFlashRoutine = StartCoroutine(FlashScreen(secondsForOneFlash, maxAlpha));
    }

    IEnumerator FlashScreen(float secondsForOneFlash, float maxAlpha)
    {
        //animate flash in, half of duration
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
            image.color = colorThisFrame;
            yield return null;
        }

        //animate flash out, other half of duration
        float flashOutDuration = secondsForOneFlash / 2;
        for (float t = 0; t < flashOutDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
            image.color = colorThisFrame;
            yield return null;
        }

        image.color = new Color32(0, 0, 0, 0);
    }
}
