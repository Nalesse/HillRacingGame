using System;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

namespace UI
{
    public class LeaderboardController : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private TextMeshProUGUI[] entries;
        [SerializeField] private GameObject leaderboardUI;
        [SerializeField] private GameObject gameOverUI;
        public static LeaderboardController Instance { get; private set; }
        private int highScore;
        private int maxScores = 10;
        private string userName;
        

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void Start()
        {
            gameOverUI.SetActive(false);
            leaderboardUI.SetActive(false);
            LootLockerSDKManager.StartGuestSession("Player", (response) =>
            {
                Debug.Log(response.success ? "Success" : response.Error);
            });
        }

        public void SubmitScore()
        {
            LoadPrefs();
            LootLockerSDKManager.SubmitScore(userName, highScore, id,(response) =>
            {
                Debug.Log(response.success ? "Score Submitted to Leaderboard" : response.Error);
            });
        }

        private void ShowScores()
        {
            LootLockerSDKManager.GetScoreList(id, maxScores, (response) =>
            {
                if (!response.success) return;
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = "#" + scores[i].rank + " " + scores[i].member_id + " Score: " + scores[i].score;
                }

                if (scores.Length >= maxScores) return;
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text = "#" + (i + 1) + " No Data";
                    }
                }
            });
        }

        public int GetHighScore()
        {
            int _highScore = 0;
            LootLockerSDKManager.GetScoreList(id, 10, (response) =>
            {
                if (!response.success) return;

                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    if (scores[i].member_id == PlayerPrefs.GetString("Username"))
                    {
                        _highScore = scores[i].score;
                    }
                }

            });
            return _highScore;
        }

        public void ShowLeaderboard()
        {
            ShowScores();
            leaderboardUI.gameObject.SetActive(true);
            gameOverUI.gameObject.SetActive(false);
        
        }

        public void HideLeaderboard()
        {
            Debug.Log("Close leaderboard");
            leaderboardUI.SetActive(false);
            gameOverUI.SetActive(true);
        }

        private void LoadPrefs()
        {
            if (PlayerPrefs.HasKey("Username"))
            {
                userName = PlayerPrefs.GetString("Username");
            }

            if (PlayerPrefs.HasKey("HighScore"))
            {
                highScore = (int)PlayerPrefs.GetFloat("HighScore", highScore);
            }
        }
    }
}
