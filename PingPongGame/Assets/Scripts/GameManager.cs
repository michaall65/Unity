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
    public Text HighScoreText;
    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelGameOver;
    public GameObject panelLevelCompleted;
    public GameObject panelBackToMenu;
    private int i = 0;
    public int scoretowin = 100;

    public GameObject[] levels;

    GameObject _currentBall;
    GameObject _currentLevel;

    public static GameManager Instance{get; private set;}

    private int scores;

    public int score
    {
        get { return scores; }
        set 
        { scores = value; 
          scoreText.text = "SCORE: " + scores;
        }
          
    }

    private int balls;

    public int Balls
    {
        get { return balls; }
        set { balls = value;
            ballText.text = "BALLS: " + balls;
        }
    }

    private int level;

    public int Level
    {
        get { return level; }
        set { level = value;
            levelText.text = "LEVEL: " + level;
        }
    }


    public enum State {Menu,Init,GameOver,Play,LevelCompleted,LoadLevel};
    State _states;

    public void PlayClick()
    {
        SwichState(State.Init);
    }
  
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        SwichState(State.Menu);
        
    }
    public void SwichState(State newState)
    {
        EndState();
        _states = newState;
        BeginState(newState);
    }
    private IEnumerator WaitForaSecond()
    {
        yield return new WaitForSeconds(2);
        if(Level < 3)
        {
            Destroy(_currentLevel);
        }
        panelPlay.SetActive(true);
        SwichState(State.LoadLevel);
    }
  
    // Update is called once per frame
    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.Menu:
                Cursor.visible = true;
                HighScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
                panelMenu.SetActive(true);
                break;
            case State.Init:
                Cursor.visible = false;
                panelPlay.SetActive(true);
                if(_currentLevel != null)
                {
                    Destroy(_currentLevel);
                }
                score = 0;
                Balls = 3;
                Level = 0;
                Instantiate(paddle);
                SwichState(State.LoadLevel);
                break;
            case State.LevelCompleted:
                Destroy(_currentBall);
                Level++;
                scoretowin += 700;
                i++;
                panelLevelCompleted.SetActive(true);
                StartCoroutine(WaitForaSecond());
                break;
            case State.LoadLevel:
                if (Level >= levels.Length )
                {
                    SwichState(State.GameOver);             
                }
                else
                {
                    _currentLevel = Instantiate(levels[Level]);
                    SwichState(State.Play);
                }
                break;
            case State.GameOver:
                Level = 2;
                panelGameOver.SetActive(true);
                if(score > PlayerPrefs.GetInt("highscore"))
                {
                    PlayerPrefs.SetInt("highscore",score);
                }
                break;
            case State.Play:
                _currentBall = Instantiate(ball);
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
                if(Input.anyKeyDown)
                {
                    Destroy(_currentBall);
                    scoretowin = 100;
                    SwichState(State.Menu);               
                }
                break;
            case State.Play:
             
                if (_currentBall == null)
                {
                    if (Balls > 0)
                    {
                        _currentBall = Instantiate(ball);
                    }
                    else
                    {
                        SwichState(State.GameOver);
                    }
                }
                if(score >= scoretowin)
                {
                   SwichState(State.LevelCompleted);
                }

                if (Input.GetKey(KeyCode.Space))
                {
                    Destroy(_currentBall);
                    scoretowin = 100;
                    SwichState(State.Menu);

                }
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
                panelLevelCompleted.SetActive(false);
                break;
            case State.LoadLevel:
                break;
            case State.GameOver:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
            case State.Play:
                break;
        }
    }
}
