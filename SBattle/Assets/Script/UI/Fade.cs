using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float Speed = 0.04f;        //フェードするスピード
    float red, green, blue, alpha;

    public bool Out = false;
    public bool In = false;

    Image fadeImage;                //パネル

    void Start()
    {
        In = true;
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
    }

    void FixedUpdate()
    {
        if (In)
        {
            FadeIn();
        }

        if (Out)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        alpha -= Speed;
        Alpha();
        if (alpha <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        alpha += Speed;
        Alpha();
        if (alpha >= 1)
        {
            Out = false;
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }
}
