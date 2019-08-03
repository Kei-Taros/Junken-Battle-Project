using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // HitPoint
    public int iHP, EnemyHP;

    // Atacck
    public int iAT, EnemyAT;

    // Start is called before the first frame update
    void Start()
    {
        iHP = 20;
        EnemyHP = 20;
        iAT = 1;
        EnemyAT = 1;
    }
    public void onDamege(int _damege)
    {
        iHP -= _damege;
    }
}
