using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public Ghost[] ghosts;
    public PacStudentController pacman;
    public Transform pellets;
    public Text scoreText;
    public Text timeText;
    public Canvas HUD;

    public int score { get; private set; }
    public int lives { get; private set; }
    public float timer { get; private set; }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {

        
        SetTimer(this.timer += Time.deltaTime);
        DisPlayTime();
        DisplayScore();
        
    }

    private void NewGame()
    {
        SetLives(3);
        SetScore(0);
        SetTimer(0);
        NewRound();
    }

    private void NewRound()
    {

        foreach(Transform pelletin in this.pellets)
        {
            pellets.gameObject.SetActive(true);
        }
        ResetState();
       
    }


    private void ResetState()
    {

        for(int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(true);
        }

        this.pacman.gameObject.SetActive(true);
    }
    private void SetScore(int score)
    {
        this.score = score;
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
    }

    private void SetTimer(float seconds)
    {
        this.timer = seconds;
    }

    private void GameOver()
    {
        for (int i = 0; i < this.ghosts.Length; i++)
        {
            this.ghosts[i].gameObject.SetActive(false);
        }

        this.pacman.gameObject.SetActive(false);

    }

    private void GhostEaten(Ghost ghost)
    {
        SetScore(this.score + ghost.points);
        SetTimer(this.timer + ghost.moretime);

    }

    private void PacmanEaten()
    {
        pacman.gameObject.SetActive(false);

        SetLives(this.lives - 1);
        if(this.lives > 0)
        {
            Invoke(nameof(ResetState), 2.0f);
        }
        else
        {
            GameOver();
        }
    }

    private void DisPlayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        int milliseconds = Mathf.FloorToInt((timer % 1) * 1000);
        timeText.text = string.Format("Time: {00}:{01}:{02}",minutes,seconds, milliseconds) ;
        

    }
    
    private void DisplayScore()
    {

        scoreText.text = string.Format("Score: {00}", this.score);
    }

    private void DisplayLives()
    {
        
    }
}
