using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicScript : MonoBehaviour
{
    public GameObject fheart1, fheart2, fheart3, hheart1, hheart2, hheart3, eheart1, eheart2, eheart3; //dead;
    public static int health;

    [SerializeField] private GameObject gameOverUI;

    public static float gameTimer;

    // Start is called before the first frame update
    void Start()
    {
        health = 6;
        fheart1.gameObject.SetActive(true);
        fheart2.gameObject.SetActive(true);
        fheart3.gameObject.SetActive(true);
        hheart1.gameObject.SetActive(false);
        hheart2.gameObject.SetActive(false);
        hheart3.gameObject.SetActive(false);
        eheart1.gameObject.SetActive(false);
        eheart2.gameObject.SetActive(false);
        eheart3.gameObject.SetActive(false);
        //dead.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(health > 6)
        {
            health = 6;
        }
        if(health < 0)
        {
            health = 0;
        }

        switch (health)
        {
            case 6:
                fheart1.gameObject.SetActive(true);
                fheart2.gameObject.SetActive(true);
                fheart3.gameObject.SetActive(true);
                hheart1.gameObject.SetActive(false);
                hheart2.gameObject.SetActive(false);
                hheart3.gameObject.SetActive(false);
                eheart1.gameObject.SetActive(false);
                eheart2.gameObject.SetActive(false);
                eheart3.gameObject.SetActive(false);
                break;

            case 5:
                fheart1.gameObject.SetActive(true);
                fheart2.gameObject.SetActive(true);
                fheart3.gameObject.SetActive(false);
                hheart1.gameObject.SetActive(true);
                hheart2.gameObject.SetActive(false);
                hheart3.gameObject.SetActive(false);
                eheart1.gameObject.SetActive(false);
                eheart2.gameObject.SetActive(false);
                eheart3.gameObject.SetActive(false);
                break;

            case 4:
                fheart1.gameObject.SetActive(true);
                fheart2.gameObject.SetActive(true);
                fheart3.gameObject.SetActive(false);
                hheart1.gameObject.SetActive(false);
                hheart2.gameObject.SetActive(false);
                hheart3.gameObject.SetActive(false);
                eheart1.gameObject.SetActive(true);
                eheart2.gameObject.SetActive(false);
                eheart3.gameObject.SetActive(false);
                break;

            case 3:
                fheart1.gameObject.SetActive(true);
                fheart2.gameObject.SetActive(false);
                fheart3.gameObject.SetActive(false);
                hheart1.gameObject.SetActive(false);
                hheart2.gameObject.SetActive(true);
                hheart3.gameObject.SetActive(false);
                eheart1.gameObject.SetActive(true);
                eheart2.gameObject.SetActive(false);
                eheart3.gameObject.SetActive(false);
                break;

            case 2:
                fheart1.gameObject.SetActive(true);
                fheart2.gameObject.SetActive(false);
                fheart3.gameObject.SetActive(false);
                hheart1.gameObject.SetActive(false);
                hheart2.gameObject.SetActive(false);
                hheart3.gameObject.SetActive(false);
                eheart1.gameObject.SetActive(true);
                eheart2.gameObject.SetActive(true);
                eheart3.gameObject.SetActive(false);
                break;

            case 1:
                fheart1.gameObject.SetActive(false);
                fheart2.gameObject.SetActive(false);
                fheart3.gameObject.SetActive(false);
                hheart1.gameObject.SetActive(false);
                hheart2.gameObject.SetActive(false);
                hheart3.gameObject.SetActive(true);
                eheart1.gameObject.SetActive(true);
                eheart2.gameObject.SetActive(true);
                eheart3.gameObject.SetActive(false);
                FindObjectOfType<AudioManager>().Play("GameOver");
                break;
            case 0:
                fheart1.gameObject.SetActive(false);
                fheart2.gameObject.SetActive(false);
                fheart3.gameObject.SetActive(false);
                hheart1.gameObject.SetActive(false);
                hheart2.gameObject.SetActive(false);
                hheart3.gameObject.SetActive(false);
                eheart1.gameObject.SetActive(true);
                eheart2.gameObject.SetActive(true);
                eheart3.gameObject.SetActive(true);
                DeadPlayer();
                //dead.gameObject.SetActive(true);
                //Destroy(gameObject);
                break;
        }
    }

    void DeadPlayer()
    {
        Time.timeScale = 0f;
        PlayerController.freezePlayer();
        gameOverUI.SetActive(true);
    }

    public void restartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        GameScore.SubScore();
        GameScore.setLevelScore();
        SceneManager.LoadScene(currentScene.name);
    }
}
