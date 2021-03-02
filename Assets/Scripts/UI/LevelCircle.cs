using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCircle : MonoBehaviour
{

    private Image _image;

    private void Start()
    {
        //Мы можем загружать уровень, но у нас всего два
        _image = GetComponent<Image>();
        FindObjectOfType<Finish>().OnFinished += WhenFinished;
    }

    private void WhenFinished()
    {
        _image.color = Color.white;
    }
}
