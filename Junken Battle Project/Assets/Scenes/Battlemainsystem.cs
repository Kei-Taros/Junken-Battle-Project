using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlemainsystem : MonoBehaviour
{
    //自分と敵の変数定義
    public Unit Player;
    public Unit Enemy;
    public GameObject ResultPanel;
    public GameObject Enemy_gu;
    public GameObject Enemy_choki;
    public GameObject Enemy_pa;
    int iHand;
    int EnemyHand;

    bool IsPlayerturn;
    bool IsGameOver;

    void Start()
    {
        IsPlayerturn = true;
        IsGameOver = false;
        ResultPanel.SetActive(false);
        Enemy_gu.SetActive(false);
        Enemy_gu.SetActive(false);
        Enemy_gu.SetActive(false);
    }

    void ViewResult()
    {
        ResultPanel.SetActive(true);
    }

    float second = 0f;
    void Update()
    {
        if (IsGameOver)
        {
            ViewResult();
        }

        if (!IsPlayerturn)
        {
            second += Time.deltaTime;
            if (second >= 1f)
            {
                second = 0;
                //EnemyHand = Random.Range(0,3);
                EnemyHand = 0;
                EnemyHandy();
                Juge();
                IsPlayerturn = true;
            }
            
        }

        if (Player.HP == 0 || Enemy.HP == 0)
        {
            IsGameOver = true;
        }
    }

    public void PushAttackButtonn(int number)
    {
        if (IsPlayerturn)
        {
            switch (number)
            {
                case 0:
                    iHand = 0;
                    IsPlayerturn = false;
                    break;

                case 1:
                    iHand = 1;
                    IsPlayerturn = false;
                    break;

                case 2:
                    iHand = 2;
                    IsPlayerturn = false;
                    break;

                default:
                    break;
            }
            
        }
    }

    private void Juge()
    {
        if ( iHand==EnemyHand)
        {
            Debug.Log("Drow");
        }
        else if (iHand==0 && EnemyHand == 1)
        {
            Enemy.OnDamege(Player.AT);
            Debug.Log("WIN");
        }
        else if (iHand == 1 && EnemyHand == 2)
        {
            Enemy.OnDamege(Player.AT);
            Debug.Log("WIN");
        }
        else if (iHand == 2 && EnemyHand == 3)
        {
            Enemy.OnDamege(Player.AT);
            Debug.Log("WIN");
        }
        else
        {
            Player.OnDamege(Enemy.AT);
            Debug.Log("Lose");
        }
    }

    private void EnemyHandy()
    {
        Enemy_gu.SetActive(false);
        Enemy_choki.SetActive(false);
        Enemy_pa.SetActive(false);

        if (EnemyHand == 0)
        {
            Enemy_gu.SetActive(true);
        }
        if (EnemyHand == 1)
        {
            Enemy_choki.SetActive(true);
        }
        if (EnemyHand == 2)
        {
            Enemy_pa.SetActive(true);
        }
    }
}