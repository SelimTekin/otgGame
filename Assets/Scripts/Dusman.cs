using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : MonoBehaviour
{
    public float Can=100;
    public float Hasar;

    public bool ölü = false;

    public GameObject Altin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<OyuncuKontrol>().HasarAl(Hasar);
        }
        else if (other.tag == "sword")
        {
            HasarAl(other.GetComponent<SwordDamage>().hasar);
            Destroy(other.gameObject);
        }
    }
    public void HasarAl(float Hasar)
    {
        if ((Can - Hasar) >= 0)
        {
            Can -= Hasar;
        }
        else
        {
            Can = 0;
        }
        ÖlüMü();
    }
    void ÖlüMü()
    {
        if (Can <= 0)
        {
            Instantiate(Altin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
