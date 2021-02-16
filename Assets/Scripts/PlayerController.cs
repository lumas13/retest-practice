using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    float playerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        Restart();
        
        //Destroy coin/saw (done)
        //Background sound
        //Audio sound play when die/collect 
        //Press r to restart (done)
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * playerSpeed * Time.deltaTime); //Player movement
            transform.localScale = new Vector2(-2, 2); //Player turning left and right
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * playerSpeed * Time.deltaTime);
            transform.localScale = new Vector2(2, 2);
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
        }

        if (collision.gameObject.CompareTag("Saw"))
        {
            Destroy(collision.gameObject);
        }
    }
}
