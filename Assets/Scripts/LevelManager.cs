using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameplayController.Instance.OnRestart += RestartLevel;
        GameplayController.Instance.OnEnded += NextLevel;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        //Время можно вынести в инспектор
        StartCoroutine(Wait(2f));
    }

    private IEnumerator Wait(float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        //Так как у нас их всего два, то просто загружаем 2й
        SceneManager.LoadScene(1);
    }
}
