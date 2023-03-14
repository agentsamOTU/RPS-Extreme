using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RPSScript : MonoBehaviour
{
    //keep track of player wins and losses
    int wins = 0;
    int losses = 0;

    [SerializeField] TMP_Text WinText;
    [SerializeField] TMP_Text LossText;
    [SerializeField] TMP_Text WonText;
    [SerializeField] TMP_Text EnemyMoveText;

    [SerializeField] GameObject enemyRock;
    [SerializeField] GameObject enemyPaper;
    [SerializeField] GameObject enemyScissors;
    [SerializeField] Transform arrow;

    [SerializeField] Vector3 offset;


    //enum for easily keeping track of values of moves
    enum RPS_Move
    {
        Rock, Paper, Scissors
    }

    Dictionary<RPS_Move, GameObject> ObjectLookup;


    private void Start()
    {
        //initializes lookup table for ease of use
        ObjectLookup = new Dictionary<RPS_Move, GameObject>()
        { 
            {RPS_Move.Rock,enemyRock},
            {RPS_Move.Paper,enemyPaper},
            {RPS_Move.Scissors,enemyScissors}
        };

        //hides all objects in table
        foreach (KeyValuePair<RPS_Move,GameObject> g in ObjectLookup)
        {
            g.Value.SetActive(false);
        }
    }

    //function is called when the player clicks the button corresponding to their move
    void Play(RPS_Move move)
    {
        foreach (KeyValuePair<RPS_Move, GameObject> g in ObjectLookup)
        {
            g.Value.SetActive(false);
        }

        //generates a random number and randomly selects one of 3 moves for the enemy to do
        RPS_Move enemyMove;
        int rand = Random.Range(0, 300);
        if(rand<100)
        {
            enemyMove = RPS_Move.Rock;
        }
        else if(rand>200)
        {
            enemyMove = RPS_Move.Paper;
        }
        else
        {
            enemyMove= RPS_Move.Scissors;
        }

        EnemyMoveText.text = "Enemy played: ";

        ObjectLookup[enemyMove].SetActive(true);
        ObjectLookup[enemyMove].GetComponent<AudioSource>().Play();

        //check if the players tied or if one of them won
        if(enemyMove==move)
        {
            WonText.text = "It's a tie";
        }
        else if(Check(move,enemyMove))
        {
            WonText.text = "You won";
            wins++;
        }
        else
        {
            WonText.text = "You Lost";
            losses++;
        }

        //changes text displayed on screen
        WinText.text = "Wins : " + wins;
        LossText.text = "Losses : " + losses;
    }

    //checks if player beat the opponent, returns true if player wins
    bool Check(RPS_Move pMove,RPS_Move eMove)
    {
        bool returning = true;
        if(pMove==RPS_Move.Rock&& eMove == RPS_Move.Paper)
        {
            return false;
        }
        else if(pMove==RPS_Move.Scissors&&eMove==RPS_Move.Rock)
        {
            return false;
        }
        else if(pMove==RPS_Move.Paper&&eMove==RPS_Move.Scissors)
        {
            return false;
        }
        return returning;
    }

    //functions called by unity buttons that pass the correct move enum
    //also moves arrow under pressed button
    public void Rock(Transform t)
    {
        Play(RPS_Move.Rock);
        arrow.position = t.position - offset;
    }
    public void Paper(Transform t)
    {
        Play(RPS_Move.Paper);
        arrow.position = t.position - offset;
    }
    public void Scissors(Transform t)
    {
        Play(RPS_Move.Scissors);
        arrow.position = t.position - offset;
    }
}
