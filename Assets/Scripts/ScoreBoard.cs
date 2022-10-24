using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ScoreBoard : MonoBehaviour
{

    [Header("Starting Values")]

    public int happyKidCounter;
    public int candyCounter;
    [Space(10)]

    [Header("UI Text Boxes")]

    public TextMeshProUGUI kidCountText;
    public TextMeshProUGUI candyCountText;

    [FormerlySerializedAs("gameober")] [Space(10)]
    public GameOver gameOver;

    private bool resultUpdated = false;
    public static ScoreBoard Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        kidCountText.text = "Happy Kid Counter: " + happyKidCounter.ToString();
        candyCountText.text = "Candies: " + candyCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetKidCounter(){
        return happyKidCounter;
    }
    public int GetCandyCounter(){
        return candyCounter;
    }

    public void DecreaseCandyCounter(int candyNum)
    {
        candyCounter -= candyNum;
        UpdateCounters();
    }

    public void IncreaseKidCounter(int kidNum)
    {
        happyKidCounter += kidNum;
        UpdateCounters();
    }

    public void UpdateCounters()
    {
        kidCountText.text = "Happy Kid Counter: " + happyKidCounter.ToString();
        candyCountText.text = "Candies: " + candyCounter.ToString();
    }



    public static void NewKidsComing()
    {
        Instance.resultUpdated = false;
    }

    public static void UpdateScore(bool spray)
    {
        if (Instance.resultUpdated)
        {
            return;
        }

        Instance.resultUpdated = true;
        Kid kid = KidsController.WhoAreComing()[0];
        bool goodKid = !(kid.NumCandyHolding > 1 || kid.ShownUp);
        if (goodKid && spray)
        {
            Instance.DecreaseCandyCounter(5);
        }else if (!goodKid & spray)
        {
            // nothing
        }else
        {
            Instance.DecreaseCandyCounter(kid.NumCandyHolding);
            Instance.IncreaseKidCounter(1);
        }
        
        if (Instance.candyCounter <= 0)
        {
            Instance.gameOver.Gameover();
        }

    }
}
