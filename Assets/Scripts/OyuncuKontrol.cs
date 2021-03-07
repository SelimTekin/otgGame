using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyuncuKontrol : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float Can;
    public float Hasar;
    public float hiz;
    public float hori;
    public float jumpSpeed = 1f, jumpFrequency = 1f, nextJumpTime;
    public float yerKontrolRadius;

    public LayerMask yerKontrolLayer;

    bool acikMi=false;
    public bool yerdemi = false;
    public bool ölü = false;
    bool facingRight = true;

    public int coin;
    public Transform yerKontrol;
    public float lifeTime;

    public GameObject shop;
    public Transform sword;
    public float swordHiz;
    Transform muzzle;
    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        market();
        Yürüme();
        KilicSavur();
        ZeminKontrol();

        if (rb.velocity.x < 0 && facingRight)
        {
            FlipFace();
        }
        else if (rb.velocity.x > 0 && !facingRight)
        {
            FlipFace();
        }

        anim.SetFloat("yürüme", Mathf.Abs(rb.velocity.x));

        if (Input.GetAxis("Vertical") > 0 && yerdemi && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            rb.AddForce(new Vector2(0f, jumpSpeed));
        }
        if(Input.GetMouseButtonDown(0))
        {
            Vurus();
        }
    }
    void FlipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }

    void Yürüme()
    {
        hori = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hori * hiz, rb.velocity.y);
    }
    void ZeminKontrol()
    {
        yerdemi = Physics2D.OverlapCircle(yerKontrol.position, yerKontrolRadius, yerKontrolLayer);
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
        YokOl();
    }
    void YokOl()
    {
        if (Can <= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(gameObject, lifeTime);
        }

    }
    void ÖlüMü()
    {
        if (Can <= 0)
        {
            ölü = true;
        }
    }
    void KilicSavur()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("Atak", true);
        }
        else
        {
            anim.SetBool("Atak", false);
        }
    }
    public void market()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            acikMi = !acikMi;
        }
        if(acikMi)
        {
            shop.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            shop.SetActive(false);
            Time.timeScale = 1;
        }
    }
    void Vurus()
    {
        Transform tempSword;
        tempSword = Instantiate(sword, muzzle.position, Quaternion.identity);
        tempSword.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * swordHiz);

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="altin")
        {
            coin++;
            Destroy(other.gameObject);
        }
    }
}
