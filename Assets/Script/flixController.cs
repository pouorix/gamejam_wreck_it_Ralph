using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flixController : MonoBehaviour
{
    // Start is called before the first frame update
    public float factor = 0.01f;
    private Vector3 moveVector;
    public Rigidbody2D rb;
    public float jumpAmount = 0.5f;
    private bool canJunp;
    private bool nearBroken;
    private bool nearRalph;
    private GameObject brokenGameObject;
    private int fixesCounter;
    private GameObject[] brokensGlasses;
    public Text score;
    private int localScore;
    private int health;
    public GameObject Heart3;
    public GameObject Heart2;
    public GameObject Heart1;
    public Text score2;
    public GameObject DeathMenu;
    public GameObject WinMenu;
    void Start()
    {
        moveVector = new Vector3(1 * factor, 0, 0);
        canJunp = true;
        nearBroken = false;
        nearRalph = false;
        fixesCounter = 0;
        localScore = 0;
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveVector;
            if (gameObject.transform.localScale.x<0)
            {
                gameObject.transform.localScale = new Vector3(-1 * gameObject.transform.localScale.x,
                    gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= moveVector;
            if (gameObject.transform.localScale.x>0)
            {
                gameObject.transform.localScale = new Vector3(-1 * gameObject.transform.localScale.x,
                    gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)  && canJunp)
        {
            rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
            canJunp = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (nearBroken)
            {
                brokenGameObject.transform.position = new Vector3(brokenGameObject.transform.position.x, brokenGameObject.transform.position.y, -100000);
                fixesCounter++;
                localScore++;
                score.text = localScore.ToString();
                score2.text = localScore.ToString();
                nearBroken = false;
            }

            if (nearRalph)
            {
                WinMenu.SetActive(true);
            }

        }

        if (fixesCounter%8==0 && fixesCounter!=0)
        {
            brokensGlasses = GameObject.FindGameObjectsWithTag("broken");
            foreach (GameObject item in brokensGlasses)
            {
                item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, 0);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            canJunp = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("broken") && other.transform.position.z>=0 )
        {
            nearBroken = true;
            brokenGameObject = other.gameObject;
        }
        if (other.gameObject.CompareTag("brick") )
        {
            health--;
            Destroy(other.gameObject);
            updateHeartUI();
        }
        if (other.gameObject.CompareTag("ralph") )
        {
            nearRalph = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("broken"))
        {
            nearBroken = false;
            brokenGameObject = null;
        }
        if (other.gameObject.CompareTag("ralph"))
        {
            nearRalph = false;
        }
    }
    private void updateHeartUI()
    {
        int playerHeartsCount = health;
        if (playerHeartsCount == 3)
        {
            Heart3.SetActive(true);
            Heart2.SetActive(true);
            Heart1.SetActive(true);
        }

        else if (playerHeartsCount == 2)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(true);
            Heart1.SetActive(true);
        }

        else if (playerHeartsCount == 1)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(true);
        }
        else if (playerHeartsCount == 0)
        {
            Heart3.SetActive(false);
            Heart2.SetActive(false);
            Heart1.SetActive(false);
            DeathMenu.SetActive(true);
            //player.moveAmount=0f;
           transform.position=new Vector3(10000, 10000, 1000);
        }
    }

}