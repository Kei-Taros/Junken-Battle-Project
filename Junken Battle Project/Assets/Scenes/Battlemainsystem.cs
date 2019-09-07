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
    public GameObject NG_image;
    public GameObject Enemy_NG_image;
    public GameObject Enemy_gu_image;
    public GameObject Enemy_choki_image;
    public GameObject Enemy_pa_image;

    public Button gu_button;
    public Button choki_button;
    public Button pa_button;

    public Text gu_Level;
    public Text choki_Level;
    public Text pa_Level;
    public Text Enemy_gu_Level;
    public Text Enemy_choki_Level;
    public Text Enemy_pa_Level;

    int iHand;
    int EnemyHand;
    int gu_count;
    int choki_count;
    int pa_count;
    int Enemy_gu_count;
    int Enemy_choki_count;
    int Enemy_pa_count;
    int returnNumber;

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
                EnemyHand_Number();
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

    void EnemyHand_Number()
    {
        EnemyHand = Random.Range(0,3);
        //EnemyHand = 0;
        Debug.Log(EnemyHand);
        if (Enemy_gu_count == 4)
        {
            Enemy_Gu_count4();
        }
        else if (Enemy_choki_count == 4)
        {
            Enemy_Choki_count4();
        }
        else if (Enemy_pa_count == 4)
        {
            Enemy_Pa_count4();
        }
        else
        {
            switch (EnemyHand)
            {
                case 0:
                    Enemy_Gu_Count_Function();
                    Enemy_gu.SetActive(true);
                    break;

                case 1:
                    Enemy_Choki_Count_Function();
                    Enemy_choki.SetActive(true);
                    break;

                case 2:
                    Enemy_Pa_Count_Function();
                    Enemy_pa.SetActive(true);
                    break;

                default:
                    break;
            }
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

    float x ;
    float y ;

    IEnumerator IsPlayerturnTrue()
    {
        yield return new WaitForSeconds(2f);
        ButtontrueSisters();
        ViewCounter();
        Enemy_NG_images();
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

    void Enemy_Gu_Count_Function()
    {
        switch (Enemy_gu_count)
        {
            case 1:
                Enemy.AT = 1;
                break;

            case 2:
                Enemy.AT = 3;
                break;

            case 3:
                Enemy.AT = 5;
                break;

            default:
                break;
        }
        Enemy_gu_count += 1;
        
        if (Enemy_choki_count == 4)
        {
            Enemy_choki_count = 1;
            Enemy_NG_image.SetActive(false);
        }
        if (Enemy_pa_count == 4)
        {
            Enemy_pa_count = 1;
            Enemy_NG_image.SetActive(false);
        }
    }

    void Enemy_Gu_count4()
    {
        EnemyHand = Random.Range(0, 2);
        Debug.Log("Gu4" + EnemyHand);
        switch (EnemyHand)
        {
            case 0:
                EnemyHand = 1;
                Enemy_Choki_Count_Function();
                Enemy_choki.SetActive(true);
                break;

            case 1:
                EnemyHand = 2;
                Enemy_Pa_Count_Function();
                Enemy_pa.SetActive(true);
                break;

            default:
                break;
        }
    }

    void Enemy_Choki_Count_Function()
    {
        switch (Enemy_choki_count)
        {
            case 1:
                Enemy.AT = 1;
                break;

            case 2:
                Enemy.AT = 3;
                break;

            case 3:
                Enemy.AT = 5;
                break;

            default:
                break;
        }

        Enemy_choki_count += 1;

        if (Enemy_gu_count == 4)
        {
            Enemy_gu_count = 1;
            Enemy_choki.SetActive(false);
        }
        if (Enemy_pa_count == 4)
        {
            Enemy_pa_count = 1;
            Enemy_choki.SetActive(false);
        }
    }

    void Enemy_Choki_count4()
    {
        EnemyHand = Random.Range(0, 2);
        Debug.Log("Choki4" + EnemyHand);
        switch (EnemyHand)
        {
            case 0:
                EnemyHand = 0;
                Enemy_Gu_Count_Function();
                Enemy_gu.SetActive(true);
                break;

            case 1:
                EnemyHand = 2;
                Enemy_Pa_Count_Function();
                Enemy_pa.SetActive(true);
                break;

            default:
                break;
        }
    }

    void Enemy_Pa_Count_Function()
    {
        switch (Enemy_pa_count)
        {
            case 1:
                Enemy.AT = 1;
                break;

            case 2:
                Enemy.AT = 3;
                break;

            case 3:
                Enemy.AT = 5;
                break;

            default:
                break;
        }

        Enemy_pa_count += 1;

        if (Enemy_choki_count == 4)
        {
            Enemy_choki_count = 1;
            Enemy_choki.SetActive(false);
        }
        if (Enemy_gu_count == 4)
        {
            Enemy_gu_count = 1;
            Enemy_choki.SetActive(false);
        }
    }

    void Enemy_Pa_count4()
    {
        EnemyHand = Random.Range(0, 2);
        Debug.Log("Pa4"+EnemyHand);
        switch (EnemyHand)
        {
            case 0:
                EnemyHand = 0;
                Enemy_Gu_Count_Function();
                Enemy_gu.SetActive(true);
                break;

            case 1:
                EnemyHand = 1;
                Enemy_Choki_Count_Function();
                Enemy_choki.SetActive(true);
                break;

            default:
                break;
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

    public void FalseBrothers()
    {
        Enemy_gu.SetActive(false);
        Enemy_choki.SetActive(false);
        WIN.SetActive(false);
        LOSE.SetActive(false);
        DROW.SetActive(false);
        LastWIN.SetActive(false);
        LastLOSE.SetActive(false);
        NG_image.SetActive(false);
        Enemy_NG_image.SetActive(false);
        Enemy_gu_image.GetComponent<Image>().color = new Color(255f / 250f, 255f / 250f, 255f / 250f, 255f / 250f);
        Enemy_choki_image.GetComponent<Image>().color = new Color(255f / 250f, 255f / 250f, 255f / 250f, 255f / 250f);
        Enemy_pa_image.GetComponent<Image>().color = new Color(255f / 250f, 255f / 250f, 255f / 250f, 255f / 250f);
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
        gu_Level.text = "Lv." + gu_count.ToString();
        choki_Level.text = "Lv." + choki_count.ToString();
        pa_Level.text = "Lv." + pa_count.ToString();
        Enemy_gu_Level.text = "Lv." + Enemy_gu_count.ToString();
        Enemy_choki_Level.text = "Lv." + Enemy_choki_count.ToString();
        Enemy_pa_Level.text = "Lv." + Enemy_pa_count.ToString();
    }

    void FirstCounter()
    {
        gu_count = 1;
        choki_count = 1;
        pa_count = 1;
        Enemy_gu_count = 1;
        Enemy_choki_count = 1;
        Enemy_pa_count = 1;
    }

    float Enemy_x;
    float Enemy_y;
    void Enemy_NG_images()
    {
        if(Enemy_gu_count == 4)
        {
            Enemy_x = 350;
            Enemy_y = -148;
            Enemy_NG_image.GetComponent<RectTransform>().anchoredPosition = new Vector2(Enemy_x, Enemy_y);
            Enemy_gu_image.GetComponent<Image>().color = new Color(135f / 250f, 133f / 255f, 133f / 250f, 185f / 250f);
            Enemy_NG_image.SetActive(true);
        }
        if (Enemy_choki_count == 4)
        {
            Enemy_x = 470;
            Enemy_y = -148;
            Enemy_NG_image.GetComponent<RectTransform>().anchoredPosition = new Vector2(Enemy_x, Enemy_y);
            Enemy_choki_image.GetComponent<Image>().color = new Color(135f / 250f, 133f / 255f, 133f / 250f, 185f / 250f);
            Enemy_NG_image.SetActive(true);
        }
        if (Enemy_pa_count == 4)
        {
            Enemy_x = 590;
            Enemy_y = -148;
            Enemy_NG_image.GetComponent<RectTransform>().anchoredPosition = new Vector2(Enemy_x, Enemy_y);
            Enemy_pa_image.GetComponent<Image>().color = new Color(135f / 250f, 133f / 255f, 133f / 250f, 185f / 250f);
            Enemy_NG_image.SetActive(true);
        }
    }
}
