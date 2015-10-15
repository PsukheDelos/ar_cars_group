using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetermineOutcome : MonoBehaviour {
    private Rect screenrect = new Rect (0, 0, Screen.width, Screen.height);
    private float score;
    private int totalGuests;
    private int currentGuests;
	private float time;
    private bool started;

	public GameObject TimeUI;
	public GameObject GameOverUI;
    public GameObject TextOut;
	public GameObject Player;
	public GameObject Reticle;


	// Use this for initialization
	void Start () {
        totalGuests = GameObject.FindGameObjectsWithTag("Guest").Length;
		time = 180f; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
        if (started)
        {
            time -= Time.deltaTime;
            score = 0;
            currentGuests = 0;
            foreach (GameObject o in GameObject.FindGameObjectsWithTag("Guest"))
            {
                if (!o.GetComponent<Death>().isDead())
                {
                    score = Mathf.Max(score, o.GetComponent<GuestKnowledge>().getKnowledge());
                    currentGuests++;
                }
            }

            if (time < 0)
            {
                GameOver();
            }
            else
            {
                int minutes = Mathf.FloorToInt(time / 60F);
                int seconds = Mathf.FloorToInt(time - minutes * 60);
                TimeUI.GetComponent<Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
            }
        }
	}

	public void GameOver(){
		Time.timeScale = 0;
		TimeUI.SetActive(false);
		GameOverUI.SetActive(true);
        TextOut.GetComponent<Text>().text = "Witness Description: " + (int)(score * 100) + " %\nTotal kill count: " + (totalGuests - currentGuests) + "\nGrade: " + grade() + "\n\nPress R to try again.\nPress Esc to quit";
		Player.GetComponent<LookAtMouse>().enabled = false;
		Reticle.GetComponent<StickToMouse>().enabled = false;
	}

    public string grade()
    {
        int myScore = (int)(score * 100);
        int myKills = (totalGuests - currentGuests);
        if (myScore < 20)
        {
            if (myKills < 5)
            {
                return "Ghost\nClean and clear, Johnny.\nJust the way we like it.";
            }
            else if (myKills < 15)
            {
                return "Assassin\nWell, you got out clean, Johnny.\nBit messy, but not bad.";
            }
            else
            {
                return "Monster\nDid you have to kill so many people, Johnny?\nJesus.";
            }
        }
        else if (myScore < 80)
        {
            if (myKills < 5)
            {
                return "Knife\nHearsay and rumour.\nSafe, as far as we're concerned.";
            }
            else if (myKills < 15)
            {
                return "Murderer\nChrist, what a mess.\nAt least no-one saw much.";
            }
            else
            {
                return "Thug\nAll that blood, Johnny.\nYou are one hell of a killer.";
            }
        }
        else
        {
            if (myKills < 5)
            {
                return "Pacifist\nSome day, Johnny, you're gonna have to get your hands dirty.\nSee you in twenty to life.";
            }
            else if (myKills < 15)
            {
                return "Spree Killer\nEveryone saw you, Johnny.\nDo you understand how bad that looks for us?";
            }
            else
            {
                return "Message Sender\nNo-one's gonna touch you, Johnny.\nAnd I ain't gonna defend you.";
            }
        }
    }

    public void startGame()
    {
        started = true;
    }
}
