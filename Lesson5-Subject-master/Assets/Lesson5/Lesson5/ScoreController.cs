using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    //Materialを入れる
   // Material mymaterial;


    //初めの持ち点
     public int totalScore = 0;

    public GameObject ScoreText;

	// Use this for initialization
	void Start () {
        ScoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {

        //タグによって得点の大きさを変える
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.totalScore += 100;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.totalScore += 1000;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.totalScore += 300;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.totalScore += 500;
        
        }
        ScoreText.GetComponent<Text>().text = "Score" + totalScore;
    }
}
