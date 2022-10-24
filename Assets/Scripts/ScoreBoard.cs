using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    [Header("Starting Values")]

    public int happyKidCounter;
    public int candyCounter;
    [Space(10)]

    [Header("UI Text Boxes")]

    public TextMeshProUGUI kidCountText;
    public TextMeshProUGUI candyCountText;

    [Space(10)]
    public GameOver gameober;

    // Start is called before the first frame update
    void Start()
    {

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




    public void KidHasLeft()
    {

        Kid kid = KidsController.WhoAreComing()[0];

        if (kid.NumCandyHolding == 1 && !kid.ShownUp)
        {
            if (kid.Sprayed)
            {
                DecreaseCandyCounter(5);
            }
            else
            {
                DecreaseCandyCounter(1);
                IncreaseKidCounter(1);
            }
        }
        else if (kid.NumCandyHolding > 1 || kid.ShownUp)
        {
            if (!kid.Sprayed)
            {
                DecreaseCandyCounter(kid.NumCandyHolding);

                if (!kid.ShownUp)
                {
                    IncreaseKidCounter(1);
                }
                
            }
            else
            {
                Debug.Log("success");
            }
        }

        if (candyCounter <= 0)
        {
            gameober.Gameover();
        }

    }
}
