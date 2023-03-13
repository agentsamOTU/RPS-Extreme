using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RPSScript : MonoBehaviour
{
    int wins = 0;
    int losses = 0;

    [SerializeField] TMP_Text WinText;
    [SerializeField] TMP_Text LossText;
    [SerializeField] TMP_Text WonText;
    [SerializeField] TMP_Text EnemyMoveText;

    enum RPS_Move
    {
        Rock, Paper, Scissors
    }

    Dictionary<RPS_Move, string> MoveLookup;

    private void Start()
    {
        MoveLookup = new Dictionary<RPS_Move, string>()
        {
            {RPS_Move.Rock,"Rock" },
            {RPS_Move.Paper,"Paper" },
            {RPS_Move.Scissors,"Scissors" }
        };
    }

    void Play(RPS_Move move)
    {
        

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

        EnemyMoveText.text = "Enemy played "+MoveLookup[enemyMove];

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

        WinText.text = "Wins : " + wins;
        LossText.text = "Losses : " + losses;
    }

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

    public void Rock()
    {
        Play(RPS_Move.Rock);
    }
    public void Paper()
    {
        Play(RPS_Move.Paper);
    }
    public void Scissors()
    {
        Play(RPS_Move.Scissors);
    }
}
