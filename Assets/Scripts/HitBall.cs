using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HitBall : MonoBehaviour {

	public GameObject ball;
	public Rigidbody rb;
	public GameObject p1, p2;
    public Text t1, t2;
    bool end = false;

    public AudioClip pong;
    public AudioSource pongSound;

    public bool restart, exit, restartRound = false;

    public GameObject posLine1, posLine2, posLine3, posLine4;

	public static int p1Score, p2Score = 0;
	public static bool add = true;
	public static bool p1StartBall = true, p2StartBall = false;
	private Vector3 startPos = new Vector3 (48.00f,-0.2f,10f);

	void Start () {
		rb = GetComponent<Rigidbody> ();
        pongSound.clip = pong;
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyUp(KeyCode.Y) && p1Score >= 7) || (Input.GetKeyUp(KeyCode.Y) && p2Score >= 7))
        {
            restart = true;
        }
        else if ((p1Score >= 7 || p2Score >= 7) && Input.GetKeyUp(KeyCode.Escape))
        {
            exit = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && end == false)
        {
            restartRound = true;
        }
    }

	void FixedUpdate() {
		Vector3 pos = transform.position;
        followBall(pos);

        if (pos.x > 51.0f) {
			if (add) {
                P2Score();
			}

            if(restart)
            {
                RestartGame();
            }
            else if(exit)
            {
                Application.Quit();
            }

            if (restartRound)
            {
                startPos.x = 48.0f;
                RestartRound();
			}
		} 
		else if (pos.x < -51.0f) {
			if (add) {
                P1Score();
			}

            if (restart)
            {
                RestartGame();
            }
            else if (exit)
            {
                Application.Quit();
            }

            if (restartRound)
            {
                startPos.x = -48.0f;
                RestartRound();
            }

		}
	}

	void OnCollisionEnter(Collision c) {

        if (c.gameObject.name == "Player1Model") {
			Debug.Log ("HIT P1");
            pongSound.Play();
        } 
		else if (c.gameObject.name == "Player2Model") {
			Debug.Log ("HIT P2");
            pongSound.Play();
        }

	}

    void DisableText()
    {
        t1.enabled = false;
        t2.enabled = false;
    }

    void enableText()
    {
        t1.enabled = true;
        t2.enabled = true;
    }

    void followBall(Vector3 pos)
    {
        Vector3 pos1 = posLine1.transform.position;
        posLine1.transform.position = new Vector3(pos.x, pos1.y, pos1.z);
        Vector3 pos2 = posLine2.transform.position;
        posLine2.transform.position = new Vector3(pos.x, pos2.y, pos2.z);
        Vector3 pos3 = posLine3.transform.position;
        posLine3.transform.position = new Vector3(pos.x, pos3.y, pos3.z);
        Vector3 pos4 = posLine4.transform.position;
        posLine4.transform.position = new Vector3(pos.x, pos4.y, pos4.z);
    }

    void P1Score()
    {
        p1Score++;
        add = false;
        Debug.Log(p1Score);
        rb.velocity = Vector3.zero;


        p1StartBall = false;
        p2StartBall = true;

        enableText();
        t1.text = p1Score.ToString();
        Debug.Log("p1 score:" + p1Score.ToString());
        t2.text = p2Score.ToString();

        if (p1Score >= 7)
        {
            t1.text = "YOU WIN :D";
            t2.text = "YOU LOST :c";
            end = true;
        }
    }

    void P2Score()
    {
        p2Score++;
        add = false;
        Debug.Log(p2Score);
        rb.velocity = Vector3.zero;

        p1StartBall = true;
        p2StartBall = false;

        enableText();
        t1.text = p1Score.ToString();
        Debug.Log("p2 score:" + p2Score.ToString());
        t2.text = p2Score.ToString();

        if (p2Score >= 7)
        {
            t2.text = "YOU WIN :D";
            t1.text = "YOU LOST :c";
            end = true;

        }
    }

    void RestartGame()
    {
        p1Score = 0;
        p2Score = 0;
        p1.transform.position = PlayerControl.startpos1;
        p2.transform.position = PlayerControl2.startpos2;
        transform.position = startPos;
        PlayerControl.count = 0;
        add = true;
        DisableText();
        end = false;
        restart = false;
    }

    void RestartRound()
    {
        p1.transform.position = PlayerControl.startpos1;
        p2.transform.position = PlayerControl2.startpos2;
        transform.position = startPos;
        PlayerControl.count = 0;
        add = true;
        DisableText();
        restartRound = false;
    }
}
