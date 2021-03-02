using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWindow : MonoBehaviour
{

    private void Start()
    {
        GameplayController.Instance.OnEnded += Show;
        Hide();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
