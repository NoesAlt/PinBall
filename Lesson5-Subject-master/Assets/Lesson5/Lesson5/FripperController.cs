using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {


    //HingiJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;

    //弾いた時の傾き
    private float flickAngle = -20;


    //触れている指の数
    int fingerCount = 0;


    //左画面に指が触れてないときはfalse
    bool leftTouch = false;

    //右画面に触れてないときはfalse
    bool rightTouch = false;










	// Use this for initialization
	void Start () {
        //HingeJointコンポーネントを取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);

	}



    //スマホに対応した,指でフリッパーを動かす関数
    void CheckTouch()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("through");
            //各指を検出
            foreach (Touch t in Input.touches)
            {
                //指が画面から離れていなく、記憶したままの時
                if (t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled)
                {
                    //中心よりも左で指をタップしたとき、左画面に触れたことにする
                    if (t.position.x < Screen.width / 2)
                    {
                        leftTouch = true;
                        Debug.Log("lefttrue");
                    }
                    if (t.position.x > Screen.width / 2)
                    {
                        rightTouch = true;
                        Debug.Log("righttrue");
                    }
                }
                else         
                {
                    if (t.position.x > Screen.width / 2)
                    {
                        rightTouch = false;
                    }
                    if(t.position.x < Screen.width / 2)
                    {
                        leftTouch = false;
                    }
                }
            }
        }      
        
    }

    // Update is called once per frame
    void Update()
    {

        /*    if (Application.isEditor)
              {
                  //左矢印キーを押したとき左フリッパーを動かす
                  if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
                  {
                      SetAngle(this.flickAngle);
                  }
                  //右矢印キーを押したとき右フリッパーを動かす
                  if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
                  {
                      SetAngle(this.flickAngle);
                  }

                  //矢印キー離されたときフリッパーを元に戻す
                  if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
                  {
                      SetAngle(this.defaultAngle);
                  }
                  if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
                  {
                      SetAngle(this.defaultAngle);
                  }
              }
              else
              {
                  CheckTouch();
                  if (leftTouch && tag == "LeftFripperTag")
                  {
                      SetAngle(this.flickAngle);
                  }
                  if (rightTouch && tag == "RightFripperTag")
                  {
                      SetAngle(this.flickAngle);
                  }

                  if (!leftTouch && tag == "LeftFripperTag")
                  {
                      SetAngle(this.defaultAngle);
                  }
                  if (!rightTouch && tag == "RightFripperTag")
                  {
                      SetAngle(this.defaultAngle);
                  }
              }
          }
          */
        CheckTouch();
        if (leftTouch && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);      
        }
        if (rightTouch && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);          
        }

        if (!leftTouch && tag == "LeftFripperTag")
       {
            SetAngle(this.defaultAngle);
        }
        if (!rightTouch && tag == "RightFripperTag")
       {
           SetAngle(this.defaultAngle);
        }
    }
        //フリッパーの傾きを設定
        public void SetAngle (float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}
