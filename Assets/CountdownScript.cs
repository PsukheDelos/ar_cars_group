using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownScript : MonoBehaviour {

	public Text timerText;
	public Text countDownText;
	public Text scoreText;
	public Text playerText;
	public Text roomText;
	public float gameDuration = 180.0f;
	public float countdownDuration = 3.0f;

	private bool first = true;
	private float startTime;
	private float currentTime;
	private bool gameOver = false;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FixedUpdate () {
		roomText.text = "Room: " + PhotonNetwork.room.name;
		playerText.text = "Player " + PhotonNetwork.player.name;
		if (PhotonNetwork.playerList.Length > 1) {
			if (first) {
				start ();
				first = false;
			} else {
				update ();
			}				
		} else {
			// resets game
//			roomText.text = "Room: " + PhotonNetwork.room.name;
//			playerText.text = "Player " + PhotonNetwork.player.name;
			countDownText.text = "Waiting for\nplayer...";
			timerText.text = "";
		}
	}

	void start()
	{
//		roomText.text = "Room: " + PhotonNetwork.room.name;
//		playerText.text = "Player " + PhotonNetwork.player.name;
		startTime = Time.time;
		currentTime = startTime;
		countDownText.text = "";
		timerText.text = "";
	}

	void update()
	{
		currentTime = Time.time;
		
		float elapsedTime = currentTime - startTime;
		
		if (elapsedTime > 3.0 && elapsedTime <= gameDuration) {
			PhotonNetwork.gameVersion = "Start";
			float timeRemaining = (float)gameDuration - elapsedTime;
			countDownText.text = "";
			timerText.text = "Time Left " + Mathf.Round(timeRemaining) + "s";
		} else if (elapsedTime <= 3.0) {
			string txt = "Game starting in\n" + (int)(4 - elapsedTime);
			countDownText.text = txt;
			timerText.text = "";
		} else { // game ends
			gameOver = true;
			PhotonNetwork.gameVersion = "GameOver";
			timerText.text = "";
			countDownText.text = "GAME OVER\n";
			scoreText.text = "Player " + PhotonNetwork.player.name + ": " + PhotonNetwork.otherPlayers[0].GetScore() + "\n" +
				"Player " + PhotonNetwork.otherPlayers[0].name + ": " + PhotonNetwork.player.GetScore() + "\n";
			if(PhotonNetwork.player.GetScore() < PhotonNetwork.otherPlayers[0].GetScore()){
				scoreText.text = scoreText.text + "You win!";
			}
			else if(PhotonNetwork.player.GetScore() > PhotonNetwork.otherPlayers[0].GetScore()){
				scoreText.text = scoreText.text + "You Lose!";
			}
			else if(PhotonNetwork.player.GetScore() == PhotonNetwork.otherPlayers[0].GetScore()){
				scoreText.text = scoreText.text + "DRAW!";
			}
			GameObject.Find ("ResetCanvas").gameObject.GetComponent<Canvas> ().enabled = true;
		}
	}
	
	void restart()
	{
		first = true;
	}
}
