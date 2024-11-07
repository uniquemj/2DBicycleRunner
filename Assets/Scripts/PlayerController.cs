using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    private bool isGround = true;
    public GameObject playLabel;

    
    // Start is called before the first frame update
    void Start()
    {
        playLabel.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGround)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGround = false;
            playLabel.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

        if (collision.gameObject.CompareTag("Obstacle") && !gameController.isGameOver)
        {
            gameController.GameOver();
        }
    }

   

   
}
