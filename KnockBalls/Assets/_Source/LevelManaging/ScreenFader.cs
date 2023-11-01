using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image FadeImage;
    public float TimeToFade;
    


    public TweenerCore<Color, Color, ColorOptions> FadeIn()
    {
        return FadeImage.DOFade(1, TimeToFade);
    }

    public TweenerCore<Color, Color, ColorOptions> FadeOut()
    {
        return FadeImage.DOFade(0, TimeToFade);
    }

    public void CreateTransition()
    {
        FadeImage.DOFade(1, TimeToFade).OnComplete(() =>
        {
            FadeImage.DOFade(0, TimeToFade);
        });
    }
    
}
