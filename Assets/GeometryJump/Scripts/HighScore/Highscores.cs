using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class Highscores : MonoBehaviour {

	public static Highscores instance;
	const string privateCode = "US3XfEHZx0urj7vrRa2VjAJo9ekyuay061xWEHg1kfzw";
	const string publicCode = "5823ffb88af6031150994692";
	const string webURL = "http://dreamlo.com/lb/";
	const string idSperator = "VKHVQ";
	const string teamSperator = "PDMWY";

	PlayerScoreList playerScoreList;
	public Highscore[] highscoresList;

	void Awake() {
		playerScoreList = GetComponent<PlayerScoreList> ();
        instance = this;
        //Debug.Log (instance);
    }


	public void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score ) {

        //Debug.Log("upload high score");


		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score );
        //Debug.Log(www);

        yield return www;

       // Debug.Log(username + WWW.EscapeURL(username));
      // Debug.Log (webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);

        if (string.IsNullOrEmpty(www.error)) {
			//print ("Upload Successful");
			//DownloadHighscores();
		}
		else {
			print ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/10");
		yield return www;
		
		//Debug.Log("Downloading Scores..");
		if (string.IsNullOrEmpty (www.error)) {
			FormatHighscores (www.text);
			playerScoreList.OnHighscoresDownloaded(highscoresList);
		}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];



			string[] playerInfo = username.Split(new string[] {teamSperator},System.StringSplitOptions.None);
		
			string name ="", team ="";
			if (playerInfo.Length > 1) {
				name = playerInfo [0];
				team = playerInfo [1];

				string[] nameInfo = name.Split(new string[] {idSperator},System.StringSplitOptions.None);
				if (nameInfo.Length > 1) {
					name = nameInfo [1];
				}


			} else {
				name = username;
			}

	
			int score = int.Parse(entryInfo[1]);

			highscoresList[i] = new Highscore(username,name,team,score);
			//print (highscoresList[i].name + ": " + highscoresList[i].team + " -> " + highscoresList[i].score);
		}
	}


	public string FormatUserName(string name , string team)
	{
		string userName = "";
		int randomId =  Random.Range(1, 9999);
		userName = randomId + idSperator + name + teamSperator + team;
		return userName;
	}

}



public struct Highscore {
	public string userName;
	public string name;
	public string team; 
	public int score;

	public Highscore(string _userName,string _name,string _team, int _score) {
		userName = _userName;
		name = _name;
		team = _team;
		score = _score;
	}

}
