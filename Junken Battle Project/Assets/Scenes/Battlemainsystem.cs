using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battlemainsystem : MonoBehaviour
{
    //自分と敵の変数定義
    public Unit Player;
    public Unit Enemy;
    public EnemySystem enemySystem;

    //GameObject
    public GameObject ResultPanel;
    public GameObject WIN;
    public GameObject LOSE;
    public GameObject DROW;
    public GameObject LastWIN;
    public GameObject LastLOSE;
    public GameObject NG_image;


    public Button gu_button;
    public Button choki_button;
    public Button pa_button;

    public Text gu_Level;
    public Text choki_Level;
    public Text pa_Level;

    int iHand;
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
        FirstCounter();
        ViewCounter();
    }

    IEnumerator ViewResult()
    {
        yield return new WaitForSeconds(1.5f);
        ResultPanel.SetActive(true);

        if (Enemy.HP <= 0)
        {
            LastWIN.SetActive(true);
            ButtonfalseBrothes();
            NG_image.SetActive(false);
        }
        else if (Player.HP <= 0)
        {
            LastLOSE.SetActive(true);
            ButtonfalseBrothes();
            NG_image.SetActive(false);
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
                    Gu_Count_Function();
                    break;

                case 1:
                    iHand = 1;
                    ButtonfalseSisters();
                    IsPlayerturn = false;
                    Choki_Count_Function();
                    break;

                case 2:
                    iHand = 2;
                    ButtonfalseSisters();
                    IsPlayerturn = false;
                    Pa_Count_Function();
                    break;

                default:
                    break;
            }

        }
    }

    float x;
    float y;

    IEnumerator IsPlayerturnTrue()
    {
        yield return new WaitForSeconds(1f);
        ButtontrueSisters();
        ViewCounter();
        enemySystem.Enemy_NG_images();
        if (gu_count == 4)
        {
            x = 7f;
            y = -367f;
            gu_button.GetComponent<Button>().interactable = false;
            NG_image.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            NG_image.SetActive(true);
        }
        if (choki_count == 4)
        {
            x = 254f;
            y = -367f;
            choki_button.GetComponent<Button>().interactable = false;
            NG_image.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            NG_image.SetActive(true);
        }
        if (pa_count == 4)
        {
            x = 504f;
            y = -367f;
            pa_button.GetComponent<Button>().interactable = false;
            NG_image.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            NG_image.SetActive(true);
        }

    }

    void Gu_Count_Function()
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

        gu_count += 1;


        if (choki_count == 4)
        {
            choki_count = 1;
            choki_button.GetComponent<Button>().interactable = true;
            choki_Level.text = "Lv." + choki_count.ToString();
            NG_image.SetActive(false);
        }
        if (pa_count == 4)
        {
            pa_count = 1;
            pa_button.GetComponent<Button>().interactable = true;
            pa_Level.text = "Lv." + pa_count.ToString();
            NG_image.SetActive(false);
        }
    }

    void Choki_Count_Function()
    {
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

        choki_count += 1;


        if (gu_count == 4)
        {
            gu_count = 1;
            gu_button.GetComponent<Button>().interactable = true;
            gu_Level.text = "Lv." + gu_count.ToString();
            NG_image.SetActive(false);
        }
        if (pa_count == 4)
        {
            pa_count = 1;
            pa_button.GetComponent<Button>().interactable = true;
            pa_Level.text = "Lv." + pa_count.ToString();
            NG_image.SetActive(false);
        }

    }

    void Pa_Count_Function()
    {
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

        pa_count += 1;

        if (gu_count == 4)
        {
            gu_count = 1;
            gu_button.GetComponent<Button>().interactable = true;
            gu_Level.text = "Lv." + gu_count.ToString();
            NG_image.SetActive(false);
        }
        if (choki_count == 4)
        {
            choki_count = 1;
            choki_button.GetComponent<Button>().interactable = true;
            choki_Level.text = "Lv." + choki_count.ToString();
            NG_image.SetActive(false);
        }

    }

    IEnumerator Juge()
    {
        yield return new WaitForSeconds(0.5f);
        if (iHand == enemySystem.EnemyHand)
        {
            DROW.SetActive(true);
        }
        else if (iHand == 0 && enemySystem.EnemyHand == 1)
        {
            Enemy.OnDamege(Player.AT);
            WIN.SetActive(true);
        }
        else if (iHand == 1 && enemySystem.EnemyHand == 2)
        {
            Enemy.OnDamege(Player.AT);
            WIN.SetActive(true);
        }
        else if (iHand == 2 && enemySystem.EnemyHand == 0)
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

    public void FalseBrothers()
    {
        enemySystem.Enemy_gu.SetActive(false);
        enemySystem.Enemy_choki.SetActive(false);
        WIN.SetActive(false);
        LOSE.SetActive(false);
        DROW.SetActive(false);
        LastWIN.SetActive(false);
        LastLOSE.SetActive(false);
        NG_image.SetActive(false);
        enemySystem.Enemy_NG_image.SetActive(false);
        enemySystem.Enemy_gu_image.GetComponent<Image>().color = new Color(255f / 250f, 255f / 250f, 255f / 250f, 255f / 250f);
        enemySystem.Enemy_choki_image.GetComponent<Image>().color = new Color(255f / 250f, 255f / 250f, 255f / 250f, 255f / 250f);
        enemySystem.Enemy_pa_image.GetComponent<Image>().color = new Color(255f / 250f, 255f / 250f, 255f / 250f, 255f / 250f);
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

    void ButtonTrueBrothes()
    {
        gu_button.GetComponent<Button>().interactable = true;
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
        gu_Level.text = "Lv." + gu_count.ToString();
        choki_Level.text = "Lv." + choki_count.ToString();
        pa_Level.text = "Lv." + pa_count.ToString();
        enemySystem.Enemy_gu_Level.text = "Lv." + enemySystem.Enemy_gu_count.ToString();
        enemySystem.Enemy_choki_Level.text = "Lv." + enemySystem.Enemy_choki_count.ToString();
        enemySystem.Enemy_pa_Level.text = "Lv." + enemySystem.Enemy_pa_count.ToString();
    }

    void FirstCounter()
    {
        gu_count = 1;
        choki_count = 1;
        pa_count = 1;
        enemySystem.Enemy_gu_count = 1;
        enemySystem.Enemy_choki_count = 1;
        enemySystem.Enemy_pa_count = 1;
    }

}