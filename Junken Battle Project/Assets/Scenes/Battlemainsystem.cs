using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlemainsystem : MonoBehaviour
{
    //自分と敵の変数定義
    public Unit Player;
    public Unit Enemy;
    //public Battlemainsystem 

    //GameObject
    public GameObject ResultPanel;
    public GameObject Enemy_gu;
    public GameObject Enemy_choki;
    public GameObject Enemy_pa;
    public GameObject WIN;
    public GameObject LOSE;
    public GameObject DROW;
    public GameObject LastWIN;
    public GameObject LastLOSE;

    public Button gu_button;
    public Button choki_button;
    public Button pa_button;

    public Text gu_Level;
    public Text choki_Level;
    public Text pa_Level;
    public Text CantText;

    int iHand;
    int EnemyHand;
    int gu_count;
    int choki_count;
    int pa_count;

    bool IsPlayerturn;
    bool IsGameOver;

    void Start()
    {
        IsPlayerturn = true;
        IsGameOver = false;
        FalseBrothers();
        ButtonTrueBrothes();
        gu_count = 1;
        choki_count = 1;
        pa_count = 1;
        ViewCounter();

    }

    IEnumerator ViewResult()
    {
        yield return new WaitForSeconds(1f);
        ResultPanel.SetActive(true);
        
        if (Enemy.HP <= 0)
        {
            LastWIN.SetActive(true);
            ButtonfalseBrothes();
        }
        else if (Player.HP <= 0)
        {
            LastLOSE.SetActive(true);
            ButtonfalseBrothes();
        }
    }
    float second = 0f;
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
                //EnemyHand = Random.Range(0,3);
                EnemyHand = 0;
                EnemyHandy();
                StartCoroutine(Juge());
                StartCoroutine(FalseSisters());
                StartCoroutine(IsPlayerturnTrue());
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
                    ButtonfalseSisters();
                    IsPlayerturn = false;
                    AT_Function();
                    Gu_Count_Function();
                    ViewCounter();
                    break;

                case 1:
                    iHand = 1;
                    ButtonfalseSisters();
                    IsPlayerturn = false;
                    AT_Function();
                    choki_Count_Function();
                    ViewCounter();
                    break;

                case 2:
                    iHand = 2;
                    ButtonfalseSisters();
                    IsPlayerturn = false;
                    AT_Function();
                    pa_Count_Function();
                    ViewCounter();
                    break;

                default:
                    break;
            }
            
        }
    }

    IEnumerator IsPlayerturnTrue()
    {
        yield return new WaitForSeconds(2.0f);
        ButtontrueSisters();
    }

    void Gu_Count_Function()
    {
        gu_count += 1;
        if (gu_count == 4)
        {
            gu_button.GetComponent<Button>().interactable = false;
        }
        if (choki_count == 4)
        {
            choki_count = 1;
            choki_button.GetComponent<Button>().interactable = true;
        }
        if (pa_count == 4)
        {
            pa_count = 1;
            pa_button.GetComponent<Button>().interactable = true;
        }
    }

    void choki_Count_Function()
    {
        choki_count += 1;
        if (choki_count == 4)
        {
            choki_button.GetComponent<Button>().interactable = false;
        }
        if (gu_count == 4)
        {
            gu_count = 1;
            gu_button.GetComponent<Button>().interactable = true;
        }
        if (pa_count == 4)
        {
            pa_count = 1;
            pa_button.GetComponent<Button>().interactable = true;
        }
    }

    void pa_Count_Function()
    {
        pa_count += 1;
        if (pa_count == 4)
        {
            pa_button.GetComponent<Button>().interactable = false;
        }
        if (gu_count == 4)
        {
            gu_count = 1;
            gu_button.GetComponent<Button>().interactable = true;
        }
        if (choki_count == 4)
        {
            choki_count = 1;
            choki_button.GetComponent<Button>().interactable = true;
        }
        
    }

    IEnumerator Juge()
    {
        yield return new WaitForSeconds(0.5f);
        if ( iHand==EnemyHand)
        {
            DROW.SetActive(true);
        }
        else if (iHand==0 && EnemyHand == 1)
        {
            Enemy.OnDamege(Player.AT);
            WIN.SetActive(true);
        }
        else if (iHand == 1 && EnemyHand == 2)
        {
            Enemy.OnDamege(Player.AT);
            WIN.SetActive(true);
        }
        else if (iHand == 2 && EnemyHand == 0)
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
    public void AT_Function()
    {
        switch (gu_count)
        {
            case 1:
                Player.AT = 1;
                break;

            case 2:
                Player.AT = 3;
                break;

            case 3:
                Player.AT = 5;
                break;

            default:
                break;
        }

        switch (choki_count)
        {
            case 1:
                Player.AT = 1;
                break;

            case 2:
                Player.AT = 3;
                break;

            case 3:
                Player.AT = 5;
                break;

            default:
                break;
        }

        switch (pa_count)
        {
            case 1:
                Player.AT = 1;
                break;

            case 2:
                Player.AT = 3;
                break;

            case 3:
                Player.AT = 5;
                break;

            default:
                break;
        }
    }

    private void EnemyHandy()
    {
        switch(EnemyHand)
        {
            case 0:
                Enemy_gu.SetActive(true);
                break;

            case 1:
                Enemy_choki.SetActive(true);
                break;

            case 2:
                Enemy_pa.SetActive(true);
                break;

            default:
                break;
        }
     
    }

    public void FalseBrothers()
    {
        Enemy_gu.SetActive(false);
        Enemy_choki.SetActive(false);
        WIN.SetActive(false);
        LOSE.SetActive(false);
        DROW.SetActive(false);
        LastWIN.SetActive(false);
        LastLOSE.SetActive(false);
    }

    IEnumerator FalseSisters()
    {
        yield return new WaitForSeconds(1.5f);
        Enemy_gu.SetActive(false);
        Enemy_choki.SetActive(false);
        Enemy_pa.SetActive(false);
        WIN.SetActive(false);
        LOSE.SetActive(false);
        DROW.SetActive(false);
    }

    void ButtonTrueBrothes()
    {
        gu_button.GetComponent<Button>().interactable=true;
        choki_button.GetComponent<Button>().interactable = true;
        pa_button.GetComponent<Button>().interactable = true;

    }

    void ButtonfalseBrothes()
    {
        gu_button.GetComponent<Button>().interactable = false;
        choki_button.GetComponent<Button>().interactable = false;
        pa_button.GetComponent<Button>().interactable = false;
        

    }

    void ButtontrueSisters()
    {
        gu_button.GetComponent<Button>().enabled = true;
        choki_button.GetComponent<Button>().enabled = true;
        pa_button.GetComponent<Button>().enabled = true;
    }

    void ButtonfalseSisters()
    {
        gu_button.GetComponent<Button>().enabled = false;
        choki_button.GetComponent<Button>().enabled = false;
        pa_button.GetComponent<Button>().enabled = false;
    }

    void ViewCounter()
    {
        gu_Level.text = "LV." + gu_count.ToString();
        choki_Level.text = "LV." + choki_count.ToString();
        pa_Level.text = "LV." + pa_count.ToString();
    }

}
