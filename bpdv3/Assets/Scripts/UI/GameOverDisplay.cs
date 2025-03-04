﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// WIP - Had been worked on recently. Has not been included in the game yet though.
public class GameOverDisplay : MonoBehaviour
{
    Player playerScript;

    bool hasFaded;
    float duration = 1f;
          
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Fade();
        }
    }

    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();

        StartCoroutine(FadeIn(canvGroup, canvGroup.alpha, hasFaded ? 1 : 0));

        hasFaded = !hasFaded;
    }
   

    public IEnumerator FadeIn(CanvasGroup canvGroup, float start, float end)
    {
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, timer / duration);

            yield return null;
        }
    }
}
