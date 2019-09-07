using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySystem : MonoBehaviour
{
    public Unit Enemy;

    public GameObject Enemy_gu;
    public GameObject Enemy_choki;
    public GameObject Enemy_pa;
    public GameObject Enemy_NG_image;
    public GameObject Enemy_gu_image;
    public GameObject Enemy_choki_image;
    public GameObject Enemy_pa_image;

    public Text Enemy_gu_Level;
    public Text Enemy_choki_Level;
    public Text Enemy_pa_Level;

    public int EnemyHand;
    public int Enemy_gu_count;
    public int Enemy_choki_count;
    public int Enemy_pa_count;

    public void EnemyHand_Number()
    {
        EnemyHand = Random.Range(0, 3);
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

    public void Enemy_Gu_Count_Function()
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

    public void Enemy_Gu_count4()
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

    public void Enemy_Choki_Count_Function()
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

    public void Enemy_Choki_count4()
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

    public void Enemy_Pa_Count_Function()
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

    public void Enemy_Pa_count4()
    {
        EnemyHand = Random.Range(0, 2);
        Debug.Log("Pa4" + EnemyHand);
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

    public void ViewCounter()
    {
        Enemy_gu_Level.text = "Lv." + Enemy_gu_count.ToString();
        Enemy_choki_Level.text = "Lv." + Enemy_choki_count.ToString();
        Enemy_pa_Level.text = "Lv." + Enemy_pa_count.ToString();
    }

    public void FirstCounter()
    {
        Enemy_gu_count = 1;
        Enemy_choki_count = 1;
        Enemy_pa_count = 1;
    }

    public float Enemy_x;
    public float Enemy_y;
    public void Enemy_NG_images()
    {
        if (Enemy_gu_count == 4)
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
