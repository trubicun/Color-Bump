using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController Instance;

    public delegate void EventHandler();
    public event EventHandler OnStarted;
    public event EventHandler OnEnded;
    public event EventHandler OnRestart;

    private bool _started = false;

    private void Awake()
    {
        Instance = this;

        FindObjectOfType<Finish>().OnFinished += EndGame;

        //Так как Killable у нас только один, можно подписаться на него единствнного
        FindObjectOfType<Killable>().Killed += Restart;
    }

    private void Update()
    {
        if (!_started)
        {
            if (Input.GetMouseButton(0))
            {
                StartGame();
                _started = true;
            }
        }
    }

    public void Restart()
    {
        OnRestart?.Invoke();
    }

    public void EndGame()
    {
        OnEnded?.Invoke();
    }

    public void StartGame()
    {
        OnStarted?.Invoke();
    }
}
