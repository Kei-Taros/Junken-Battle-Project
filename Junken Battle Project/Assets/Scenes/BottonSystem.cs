using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottonSystem : MonoBehaviour
{

    public int gu;
    public int choki;
    public int pa;
    int gucount = 0;
    int chokicount = 0;
    int pacount = 0;

    //Button btn;
    //Button Gubutton;
    //Button Chokibutton;
    //Button Pabuttoon;


    void Start()
    {
        gu = 0;
        choki = 0;
        pa = 0;
        //btn = GetComponent<Button>();
        //Gubutton = GameObject.Find("Canvas/gu_botton").GetComponent<Button>();
        
    }

    private void Update()
    {
        gu = 0;
        choki = 0;
        pa = 0;
    }
    public void GuOnClick()
    {
        gu = 1;
        gucount += 1;
    }

    public void ChokiOnClick()
    {
        choki = 1;
        chokicount += 1;
    }

    public void PaOnClick()
    {
        pa = 1;
        pacount += 1;
    }
}
