using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性があるｚ軸の最大化
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;
    private GameObject scoreText;



	// Use this for initialization
	void Start ()
    {
        //シーン中のGameObjectTectオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreText = GameObject.Find("ScoreText");
	}
	
	// Update is called once per frame
	void Update ()
    {
        //ボールが画面外に出た場
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
	}

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.scoreText.GetComponent<Score>().score += 1;
        }
        else if (other.gameObject.tag=="LargeStarTag")
        {
            this.scoreText.GetComponent<Score>().score += 20;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.scoreText.GetComponent<Score>().score += 3;
        }
        else if (other.gameObject.tag)
        {
            this.scoreText.GetComponent<Score>().score += 10;
        }

        this.scoreText.GetComponent<Text>().text = "Score" + this.scoreText.GetComponent<Score>().score;

    }

}