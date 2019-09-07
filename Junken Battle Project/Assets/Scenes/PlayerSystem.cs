using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    public Unit Player;
    public Battlemainsystem battlemainsystem;
    public EnemySystem enemySystem;

    public GameObject NG_image;

    public Button gu_button;
    public Button choki_button;
    public Button pa_button;

    public Text gu_Level;
    public Text choki_Level;
    public Text pa_Level;

    public int iHand;
    public int gu_count;
    public int choki_count;
    public int pa_count;

    public void PushAttackButtonn(int number)
    {
        if (battlemainsystem.IsPlayerturn==true)
        {
            switch (number)
            {
                case 0:
                    iHand = 0;
                    ButtonfalseSisters();
                    battlemainsystem.IsPlayerturn = false;
                    Gu_Count_Function();
                    break;

                case 1:
                    iHand = 1;
                    ButtonfalseSisters();
                    battlemainsystem.IsPlayerturn = false;
                    Choki_Count_Function();
                    break;

                case 2:
                    iHand = 2;
                    ButtonfalseSisters();
                    battlemainsystem.IsPlayerturn = false;
                    Pa_Count_Function();
                    break;

                default:
                    break;
            }

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

    float x;
    float y;

    public IEnumerator IsPlayerturnTrue()
    {
        yield return new WaitForSeconds(2f);
        ButtontrueSisters();
        ViewCounter();
        enemySystem.ViewCounter();
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
    public void ButtonTrueBrothes()
    {
        gu_button.GetComponent<Button>().interactable = true;
        choki_button.GetComponent<Button>().interactable = true;
        pa_button.GetComponent<Button>().interactable = true;

    }

    public void ButtonfalseBrothes()
    {
        gu_button.GetComponent<Button>().interactable = false;
        choki_button.GetComponent<Button>().interactable = false;
        pa_button.GetComponent<Button>().interactable = false;
    }

    public void ButtontrueSisters()
    {
        gu_button.GetComponent<Button>().enabled = true;
        choki_button.GetComponent<Button>().enabled = true;
        pa_button.GetComponent<Button>().enabled = true;
    }

    public void ButtonfalseSisters()
    {
        gu_button.GetComponent<Button>().enabled = false;
        choki_button.GetComponent<Button>().enabled = false;
        pa_button.GetComponent<Button>().enabled = false;
    }

    public void ViewCounter()
    {
        gu_Level.text = "Lv." + gu_count.ToString();
        choki_Level.text = "Lv." + choki_count.ToString();
        pa_Level.text = "Lv." + pa_count.ToString();
    }

    public void FirstCounter()
    {
        gu_count = 1;
        choki_count = 1;
        pa_count = 1;
    }

    public void NG_image_false()
    {
        NG_image.SetActive(false);
    }
}
