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

    bool IsPlayerturn;
    bool IsGameOver;

    void Start()
    {
        IsPlayerturn = true;
        IsGameOver = false;
        ResultPanel.SetActive(false);
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
            ResultPanel.SetActive(true);
        }

        if (!IsPlayerturn)
        {
            second += Time.deltaTime;
            if (second >= 1f)
            {
                second = 0;
                IsPlayerturn = true;
                Player.OnDamege(Enemy.AT);
            }
        }
        if (Player.HP == 0 || Enemy.HP == 0)
        {
            IsGameOver = true;
        }
    }

    public void PushAttackBottonn()
    {
        if (IsPlayerturn)
        {
            Enemy.OnDamege(Player.AT);
            IsPlayerturn = false;
        }
    }
}