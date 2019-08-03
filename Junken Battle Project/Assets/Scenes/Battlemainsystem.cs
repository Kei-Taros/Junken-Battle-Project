using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battlemainsystem : MonoBehaviour
{

    // JunkenHand
    public int iHand,EnemyHand;

    //JunkenCounter
    int iGucount = 0,iChokicount =0,iPacount = 0;

    //Player of Turn
    bool iTurn,EnemyTurn;

    // Start is called before the first frame update
    void Start()
    {
        iHand = 0;
        UnityEngine.Random.Range(1,4);

    }

    //GuBotton　process
    public void GuOnClick()
    {
        iHand = 1;
        iGucount += 1;
    }

    //GuBotton　process
    public void ChokiOnClick()
    {
        iHand = 2; 
        iChokicount += 1;
    }

    //GuBotton　process
    public void PaOnClick()
    {
        iHand=3;
        iPacount += 1;
    }

    //JunkenJuge
    public void juge()
    {
        
    }

}
