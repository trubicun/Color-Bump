using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    public delegate void EventHandler();
    public event EventHandler Killed;


    public void Die()
    {
        Killed?.Invoke();
        gameObject.SetActive(false);
    }
}
