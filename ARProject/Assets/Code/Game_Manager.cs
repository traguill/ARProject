using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game_Manager : MonoBehaviour
{
    public int max_lifes = 5;
    public Text p1_life_txt;
    public Text p2_life_txt;
    public Text winner;
    public GameObject start;
    public GameObject restart;

    private int p1_life;
    private int p2_life;

    [HideInInspector]
    public bool game_over = false;
    [HideInInspector]
    public bool starting = false;

    public static Game_Manager gm;

    void Awake()
    {
        gm = this;
    }

    void Start()
    {
        p1_life = max_lifes;
        p2_life = max_lifes;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }


    public void SubstractLife(int id)
    {
        if(id == 1)
        {
            --p1_life;
            p1_life_txt.text = "Player1 life: " + p1_life.ToString();

            if (p1_life == 0)
            {
                game_over = true;
                winner.gameObject.SetActive(true);
                winner.text = "Player 2 wins!";
                restart.SetActive(true);
            }
        }
        else
        {
            --p2_life;
            p2_life_txt.text = "Player2 life: " + p2_life.ToString();
            if (p2_life == 0)
            {
                game_over = true;
                winner.gameObject.SetActive(true);
                winner.text = "Player 1 wins!";
                restart.SetActive(true);
            }
        }
    }

    public void Restart()
    {
        restart.SetActive(false);
        winner.gameObject.SetActive(false);
        game_over = false;
        p1_life = max_lifes;
        p2_life = max_lifes;

        p1_life_txt.text = "Player1 life: " + p1_life.ToString();
        p2_life_txt.text = "Player2 life: " + p2_life.ToString();
    }

    public void Starting()
    {
        starting = true;
        start.SetActive(false);
    }

}
