using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    public bool isPlayer = true;
    private bool isMove = true;
    public int attack = 100;
    public int defense = 200;
    [HideInInspector]
    public int underAttack;
    private float timer = 0;
    private float posYLawan;
    private bool isCari = false;
    private string nameTagLawan;

    // Start is called before the first frame update
    void Start()
    {
        if (isPlayer)
        {
            nameTagLawan = "Enemy";
        }
        else
        {
            nameTagLawan = "Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer)
        {
            if (isMove)
            {
                transform.position += transform.right * Time.deltaTime * 0.5f;
                if (transform.position.y > (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYLawan - 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }
            }
            else
            {
                //attack
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    defense -= underAttack;
                    transform.localScale = new Vector3(1, 1f);
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(1, 1.2f);
                }
            }
        }
        else
        {
            if (isMove)
            {
                transform.position -= transform.right * Time.deltaTime * 0.5f;
                if (transform.position.y > (posYLawan + 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYLawan - 0.1f) && isCari)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }
            }
            else
            {
                //attack
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    defense -= underAttack;
                    transform.localScale = new Vector3(1, 1f);
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(1, 1.2f);
                }
            }
        }
        if (defense <= 0)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals(nameTagLawan) && isMove)
        {
            isMove = false;
            Attacker m = collision.gameObject.GetComponent<Attacker>();
            if (m != null) m.underAttack = attack;
            Defender d = collision.gameObject.GetComponent<Defender>();
            if (d != null) d.underAttack = attack;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag.Equals(nameTagLawan))
        {
            isCari = true;
            posYLawan = collision.transform.position.y;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        isMove = true;
        transform.localScale = new Vector3(1, 1f);
    }

}