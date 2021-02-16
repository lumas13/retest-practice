using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    float playerSpeed = 5f;
    int coin = 0;

    public Text scoreText;
    public GameObject GameOver;
    public AudioClip[] audioClip;

    private AudioSource audioSource;
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Restart();
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * playerSpeed * Time.deltaTime); //Player movement
            transform.localScale = new Vector2(-2, 2); //Player turning left and right
            animator.SetBool("idle", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            transform.localScale = new Vector2(2, 2);
            animator.SetBool("idle", true);
        }
        else
        {
            animator.SetBool("idle", false);
        }
    }

    private void Restart()
    {
        if (Input.GetKey(KeyCode.F1)) //Restart the scene
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject); //Destory the collided object
            coin++;
            scoreText.GetComponent<Text>().text = "Score: " + coin;
            audioSource.PlayOneShot(audioClip[0]);

        }

        if (collision.gameObject.CompareTag("Saw"))
        {
            Destroy(collision.gameObject);
            GameOver.SetActive(true);
            GetComponent<PlayerController>().enabled = false;
            audioSource.PlayOneShot(audioClip[1]);
        }
    }
}
