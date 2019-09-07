using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlemainsystem : MonoBehaviour
{
    public Unit Player;
    public Unit Enemy;
    public PlayerSystem playerSystem;
    public EnemySystem enemySystem;


    //GameObject
    public GameObject ResultPanel;
    public GameObject WIN;
    public GameObject LOSE;
    public GameObject DROW;
    public GameObject LastWIN;
    public GameObject LastLOSE;

    public bool IsPlayerturn;
    public bool IsGameOver;

    void Start()
    {
        IsPlayerturn = true;
        IsGameOver = false;
        FalseBrothers();
        playerSystem.ButtonTrueBrothes();
        playerSystem.FirstCounter();
        playerSystem.ViewCounter();
        enemySystem.ViewCounter();
        FirstCounter();
    }

    IEnumerator ViewResult()
    {
        yield return new WaitForSeconds(1.5f);
        ResultPanel.SetActive(true);
        
        if (Enemy.HP <= 0)
        {
            LastWIN.SetActive(true);
            playerSystem.ButtonfalseBrothes();
            playerSystem.NG_image.SetActive(false);
        }
        else if (Player.HP <= 0)
        {
            LastLOSE.SetActive(true);
            playerSystem.ButtonfalseBrothes();
            playerSystem.NG_image.SetActive(false);
        }
    }

    float second;

    void Update()
    {
        if (IsGameOver)
        {
            StartCoroutine(ViewResult());
        }

        if (!IsPlayerturn)
        {
            second += Time.deltaTime;
            if (second >= 1f)
            { 
                second = 0;
                FalseBrothers();
                enemySystem.EnemyHand_Number();
                StartCoroutine(Juge());
                StartCoroutine(FalseSisters());
                StartCoroutine(playerSystem.IsPlayerturnTrue());
                IsPlayerturn = true;
            }
        }

        if (Player.HP == 0 || Enemy.HP == 0)
        {
            IsGameOver = true;
        }
    }


    IEnumerator Juge()
    {
        yield return new WaitForSeconds(0.5f);
        if (playerSystem.iHand ==enemySystem.EnemyHand)
        {
            DROW.SetActive(true);
        }
        else if (playerSystem.iHand ==0 && enemySystem.EnemyHand == 1)
        {
            Enemy.OnDamege(Player.AT);
            WIN.SetActive(true);
        }
        else if (playerSystem.iHand == 1 && enemySystem.EnemyHand == 2)
        {
            Enemy.OnDamege(Player.AT);
            WIN.SetActive(true);
        }
        else if (playerSystem.iHand == 2 && enemySystem.EnemyHand == 0)
        {
            Enemy.OnDamege(Player.AT);
            WIN.SetActive(true);
        }
        else
        {
            Player.OnDamege(Enemy.AT);
            LOSE.SetActive(true);
        }
        
    }

    void FalseBrothers()
    {
        WIN.SetActive(false);
        LOSE.SetActive(false);
        DROW.SetActive(false);
        LastWIN.SetActive(false);
        LastLOSE.SetActive(false);
        playerSystem.NG_image_false();
        enemySystem.FalseBrothers();
    }

    IEnumerator FalseSisters()
    {
        yield return new WaitForSeconds(1.5f);
        enemySystem.Enemy_gu.SetActive(false);
        enemySystem.Enemy_choki.SetActive(false);
        enemySystem.Enemy_pa.SetActive(false);
        WIN.SetActive(false);
        LOSE.SetActive(false);
        DROW.SetActive(false);
    }

    void FirstCounter()
    {
        playerSystem.FirstCounter();
        enemySystem.Enemy_gu_count = 1;
        enemySystem.Enemy_choki_count = 1;
        enemySystem.Enemy_pa_count = 1;
    }
}
