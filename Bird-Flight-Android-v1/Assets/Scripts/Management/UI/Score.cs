using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text txt;
    public Transform player;

    private int currentPos, maxPos, maxScore;
    private string currentTxt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = (int)player.position.y;

        if (currentPos > maxPos)
        {
            maxScore = maxPos * 50;
            maxPos = currentPos;
        }
    

       

        currentTxt = maxScore.ToString();
        txt.text = currentTxt;

        
    }
}
