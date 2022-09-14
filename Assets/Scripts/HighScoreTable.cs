using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

//not commented properly as no longer using but did try to make a high score scene and have players see their progress, issues with json object
public class HighScoreTable : MonoBehaviour
{
    //public CountScore cs;
    public Transform entryContainer;
    public Transform entryTemplate;
    private List<Transform> highScoreEntryTransformList;

    public Text posText;
    public Text scoreText;
    public Text nameText;

    private void Awake()
    {
        //entryContainer = transform.Find("highScoreEntryContainer");
        //entryTemplate = entryContainer.Find("highScoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        //int scoreValue = cs.GetScore();
        //Debug.log(scoreValue);
        AddHighScoreEntry(200, "TRY");
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        //sort the list
        for (int i = 0; i < highScores.highScoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
            {
                if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score)
                {
                    //swap
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry highScoreEntry in highScores.highScoreEntryList)
        {
            CreateHighScoreEntryTransform(highScoreEntry, entryContainer, highScoreEntryTransformList);
        }
    }

    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 100f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }
        posText.text = rankString;

        int score = highScoreEntry.score;
        scoreText.text = score.ToString();

        string name = highScoreEntry.name;
        nameText.text = name;

        transformList.Add(entryTransform);
    }

    public void AddHighScoreEntry(int score, string name)
    {
        //create highScoreEntry
        HighScoreEntry highScoreEntry = new HighScoreEntry { score = score, name = name };

        //load saved highscores
        string jsonString = PlayerPrefs.GetString("highScoreTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);

        //add new entry to highscores
        highScores.highScoreEntryList.Add(highScoreEntry);

        //save updated highscores
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores
    {
        public List<HighScoreEntry> highScoreEntryList;
    }

    //represents a single high score entry
    [System.Serializable]
    private class HighScoreEntry
    {
        public int score;
        public string name;
    }
}
