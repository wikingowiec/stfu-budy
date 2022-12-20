using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    public int currentMultiplier;
    public int multilpierTracker; 
    public int[] multiplierThresholds; 

    public int currentScore;
    public int scorePerNote = 100; 
    public int scorePerGoodNote = 125;
    public int scorePerPerfectNote = 150;
    
    public Text scoreText;
    public Text multiText; 

    public float totalNote;
    public float normalHit;
    public float goodHit;
    public float perfectHit;
    public float missedHit;

    public GameObject resultScreen;
    public Text precentHitText, normalsText, goodsText, perfectsText, missesText, rankText, finalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "score: 0";
        currentMultiplier = 1; 

        totalNote = FindObjectsOfType<NoteObject>().Length;
    }

    // Update is called once per frame
    void Update() {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;

                theMusic.Play();
            }
        }else
        {
            if(!theMusic.isPlaying && !resultScreen.activeInHierarchy)
            {
                resultScreen.SetActive(true);

                normalsText.text = "" + normalHit;
                goodsText.text = "" + goodHit;
                perfectsText.text = "" + perfectHit;
                missesText.text = "" + missedHit;

                float totalHit = normalHit + goodHit + perfectHit;
                float precentHit = (totalHit / totalNote ) * 100f;
                precentHitText.text = precentHit.ToString("F1") + "%";

                string rankVal = "F";

                if(precentHit > 40)
                {
                    rankVal = "D";
                    if(precentHit > 55)
                    {
                        rankVal = "C";
                        if(precentHit > 70)
                        {
                            rankVal = "B";
                            if(precentHit > 85)
                            {
                                rankVal = "A";
                                if(precentHit > 95)
                                {
                                    rankVal = "S";
                                }
                            }
                        }
                    }
                }
                rankText.text = rankVal;

                finalScoreText.text = currentScore.ToString();
            }
        }
     }

     public void NoteHit()
     {
        Debug.Log("Hit On Time");

        if(currentMultiplier - 1 <multiplierThresholds.Length)
        {
        multilpierTracker ++;
        if(multiplierThresholds[currentMultiplier -1]<= multilpierTracker)
        {
            multilpierTracker = 0;
            currentMultiplier++;
        }
        }

        multiText.text = "Multiplier: x" + currentMultiplier;
        //currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score:  " + currentScore; 
     }
     public void NormalHit()
     {
        currentScore += scorePerNote * currentMultiplier;
        NoteHit();

        normalHit++;
     }
    
    public void GoodHit()
    {
        currentScore += scorePerGoodNote * currentMultiplier;
        NoteHit();

        goodHit++;
    }

    public void PerfectHit()
    {
        currentScore += scorePerPerfectNote * currentMultiplier;
        NoteHit();

        perfectHit++;
    }

     public void NoteMissed()
     {
        Debug.Log("Missed Note");

       currentMultiplier = 1;
        multilpierTracker = 0;

        multiText.text = "Multiplier: x" + currentMultiplier; 

        missedHit++;
     }
}