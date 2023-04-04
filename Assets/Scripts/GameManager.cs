using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    bool gameHasEnded = false;
    public bool isGameActive;
    
    public TextMeshProUGUI gameOver1;
    public TextMeshProUGUI gameOver2;

    public TextMeshProUGUI player1Win;
    public TextMeshProUGUI player2Win;

    public TextMeshProUGUI restartText;
    public TextMeshProUGUI menuText;


    void Start() {
    
        Cursor.visible = false;

    }
    
    public void EndGame1 () 
    {
    
        if(gameHasEnded == false) {
        
            gameHasEnded = true;
            isGameActive = false;

            gameOver1.gameObject.SetActive(true);
            player1Win.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
            menuText.gameObject.SetActive(true);

        }

    }

    public void EndGame2 () 
    {
    
        if(gameHasEnded == false) {
        
            gameHasEnded = true;
            isGameActive = false;

            gameOver2.gameObject.SetActive(true);
            player2Win.gameObject.SetActive(true);
            restartText.gameObject.SetActive(true);
            menuText.gameObject.SetActive(true);

        }

    }

    public void RestartGame ()
    {
    
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    
    }

    public void ExitToMenu () 
    {
    
        Application.Quit();

    }

}
