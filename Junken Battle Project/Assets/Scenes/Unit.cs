using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    // HitPoint
    public int HP;
    public int AT;
    public int HPMax = 20;
    public Text HPtext;

    // Start is called before the first frame update
    void Start()
    {
        HP = HPMax;
        AT = 5;
        HPtext.text = HP.ToString();
        
    }
    public void OnDamege(int _damege)
    {
        HP -= _damege;
        HPView();
    }

    private void HPView()
    {
        if (HP >= 11)
        {
            HPtext.text = HP.ToString();
            
        }
        else if (HP >= 10)
        {
            HPtext.text = HP.ToString();
            HPtext.color = new Color(249f / 255f, 218f / 255f, 7f / 255f);
        }
        else if (HP >= 5)
        {
            HPtext.text = HP.ToString();
            HPtext.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }
        if (HP <= 0)
        {
            HP = 0;
            HPtext.text = HP.ToString();
            HPtext.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }

    }
}

