using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public OyuncuKontrol karakter;
    public Dusman gavur;
    public void cevikAlma()
    {
        if(karakter.coin>=2)
        {
            karakter.coin -= 2;
            karakter.hiz += 1;
        }
    }
    public void defans()
    {
        if(karakter.coin >=2)
        {
            karakter.coin -= 2;
            gavur.Hasar -= 1;
        }
    }
}
