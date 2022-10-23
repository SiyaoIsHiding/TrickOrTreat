using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI kidsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        kidsText.text = $"You made {score.ToString()} kids happy this Halloween!";
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
