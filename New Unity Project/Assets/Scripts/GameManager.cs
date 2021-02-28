using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject paddle;
    public Text scoreText;
    public Text levelText;
    public Text ballText;
    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelGameOver;
    public GameObject panelLevelCompleted;
    public enum State {Menu,Init,GameOver,Play,LevelCompleted,LoadLevel};
    State _states;

    public void PlayClick()
    {
        SwichState(State.Play);
    }
    // Start is called before the first frame update
    void Start()
    {
        SwichState(State.Menu);
    }

    public void SwichState(State newState)
    {
        EndState();
        BeginState(newState);
    }
    // Update is called once per frame
    void BeginState(State newState)
    {
        switch(newState)
        {
            case State.Menu:
                panelMenu.SetActive(true);
                break;
            case State.Init:
                break;
            case State.LevelCompleted:
                break;
            case State.LoadLevel:
                break;
            case State.GameOver:
                break;
            case State.Play:
                panelPlay.SetActive(true);
                break;
        }
        
    }
    void Update()
    {
        switch (_states)
        {
            case State.Menu:
                break;
            case State.Init:
                break;
            case State.LevelCompleted:
                break;
            case State.LoadLevel:
                break;
            case State.GameOver:
                break;
            case State.Play:
                break;
        }
    }
    void EndState()
    {
        switch (_states)
        {
            case State.Menu:
                panelMenu.SetActive(false);
                break;
            case State.Init:
                break;
            case State.LevelCompleted:
                break;
            case State.LoadLevel:
                break;
            case State.GameOver:
                panelPlay.SetActive(false);
                break;
            case State.Play:
                break;
        }
    }
}
