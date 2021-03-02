using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartText : MonoBehaviour
{
    private void Start()
    {
        GameplayController.Instance.OnStarted += Hide;
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
