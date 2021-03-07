using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skor : MonoBehaviour
{
    public OyuncuKontrol o;
    public Dusman d;

    private int health;
    public Text healthText;

    private int coin;
    public Text coinText;

    private int defans;
    public Text defansText;

    private int hiz;
    public Text hizText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Can :" + o.Can;
        coinText.text = "Coin :" + o.coin;
        defansText.text = "Alınan Hasar(2 Coin) :" + d.Hasar;
        hizText.text = "Hız(2 Coin) :" + o.hiz;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            o.Can -= 10;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "altin")
        {
            o.coin += 1;
        }
    }
}
