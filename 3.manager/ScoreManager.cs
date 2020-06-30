using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score; // The player's score.
    public float ScoreCNT = 0f; // Score count.


    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        score = 0;
    }


    void Update ()
    {
        text.text = "Score: " + score; // Set the displayed text to be the word "Score" followed by the score value.
        ScoreCNT = score; // count score.
    }
}
