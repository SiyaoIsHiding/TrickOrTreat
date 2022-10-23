using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{

    [Header("Starting Values")]

    [SerializeField]
    public int happyKidCounter;

    [SerializeField]
    public int candyCounter;
    [Space(10)]

    [Header("UI Text Boxes")]

    public TextMeshProUGUI kidCountText;
    public TextMeshProUGUI candyCountText;

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
    
}
