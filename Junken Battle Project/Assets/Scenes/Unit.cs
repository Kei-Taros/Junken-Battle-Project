using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    // HitPoint
    public int HP;
    public int AT;
    public int HPMax = 100;
    public Text HPtext;

    // Start is called before the first frame update
    void Start()
    {
        HP = HPMax;
        AT = 10;
        HPtext.text = HP.ToString();
        
    }
    public void OnDamege(int _damege)
    {
        HP -= _damege;
        if (HP <= 0)
        {
            HP = 0;
        }
        HPtext.text = HP.ToString();
    }
}
