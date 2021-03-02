using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProgressBar : MonoBehaviour
{
    private Finish _finish;
    [SerializeField] private GameObject _player;

    private Image _image;

    private void Start()
    {
        _finish = FindObjectOfType<Finish>();
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount = _player.transform.position.z / _finish.transform.position.z;
    }
}
