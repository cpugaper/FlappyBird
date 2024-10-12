using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public bool isGameOver; 

    private int score;

    private float level = 1;

    private static GameManager instance; 
    public static GameManager Instance { get { return instance; } }

    // Start is called before the first frame update
    void Awake()
    {
        //iniciamos el juego, si no existe GameManager aun, le asignamos este mismo
        if(instance == null)
        {
            instance = this; 
        }
        else
        {
            Destroy(gameObject); //nos aseguramos de que solo haya 1 instancia
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(level < 4)
        {
            level += Time.deltaTime / 20;
        }

        if(Input.GetMouseButtonDown(0) && isGameOver)
        {
            RestartGame(); 
        }
    }

    public void GameOver()
    {
        isGameOver = true; 
        gameOverText.SetActive(true);

        AudioManager.Instance.PlayGameOver();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        AudioManager.Instance.PlayScore();
    }

    public float GetLevel()
    {
        return level;
    }
}
