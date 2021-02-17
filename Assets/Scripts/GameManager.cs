using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject Coin1;
    public GameObject Coin2;
    public GameObject Coin3;
    public GameObject Saw1;
    public GameObject Saw2;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        StartCoroutine(WaitSpawnCoin(2)); //Spawn according to time given
        StartCoroutine(WaitSpawnSaw(3));
    }

    // Update is called once per frame
    void Update()
    {
        Restart();   
    }
    
    private IEnumerator WaitSpawnCoin (float waitTime) //spawner
    {
        Vector3 coin1Pos = new Vector3(-4.48f, 11.75f, 0f);
        Vector3 coin2Pos = new Vector3(-0.8f, 9.45f, 0f);
        Vector3 coin3Pos = new Vector3(3.7f, 8.39f, 0f);

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(Coin1, coin1Pos, Quaternion.identity);
            Instantiate(Coin2, coin2Pos, Quaternion.identity);
            Instantiate(Coin3, coin3Pos, Quaternion.identity);

        }
    }

    private IEnumerator WaitSpawnSaw (float waitTime)
    {
        Vector3 saw1Pos = new Vector3(1.34f, 8.95f, 0f);
        Vector3 saw2Pos = new Vector3(-2.75f, 10.83f, 0f);

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(Saw1, saw1Pos, Quaternion.identity);
            Instantiate(Saw2, saw2Pos, Quaternion.identity);
        }
    }
    private void Restart()
    {
        if (Input.GetKey(KeyCode.F1)) //Restart the scene
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

}
