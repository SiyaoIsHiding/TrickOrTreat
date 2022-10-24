using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI kidsText;

    public ScoreBoard scoreboard;

    public void Gameover()
    {
        gameObject.SetActive(true);

        int score = scoreboard.GetKidCounter();
        string kidGrammer = score == 1 ? "kid" : "kids";
        kidsText.text = $"You made {score} {kidGrammer} happy this Halloween!";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void ExitButton()
    {
        //Will add when title screen is made
        //SceneManager.LoadScene("");
    }

}
