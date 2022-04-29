using System;
using System.Collections;
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
        public int Score { get; private set;}
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

        }

        public IEnumerator LoginRoutine()
        {
            bool done = false;
            LootLockerSDKManager.StartGuestSession("Player", (response) =>
            {
                if (response.success)
                {
                    done = true;
                }
            });

            yield return new WaitWhile(() => done == false);
        }

        IEnumerator SubmitScoreRoutine()
        {
            bool done = false;
            LootLockerSDKManager.SubmitScore(userName, Score, id,(response) =>
            {
                if (response.success)
                {
                    done = true;
                }
            });

            yield return new WaitWhile(() => done == false);
        }

        IEnumerator ShowScoresRoutine()
        {
            bool done = false;
            LootLockerSDKManager.GetScoreList(id, maxScores, (response) =>
            {
                if (!response.success) return;
                done = true;
                LootLockerLeaderboardMember[] scores = response.items;

                for (int i = 0; i < scores.Length; i++)
                {
                    entries[i].text = "#" + scores[i].rank + " " + scores[i].member_id + ": " + scores[i].score;
                }

                if (scores.Length >= maxScores) return;
                {
                    for (int i = scores.Length; i < maxScores; i++)
                    {
                        entries[i].text = "#" + (i + 1) + " No Data";
                    }
                }

            });

            yield return new WaitWhile(() => done == false);
        }

        public IEnumerator GetHighScoreRoutine()
        {
            bool done = false;
            LootLockerSDKManager.GetScoreList(id, 10, (response) =>
            {
                if (!response.success) return;
                done = true;
                LootLockerLeaderboardMember[] scores = response.items;
                Score = scores.Length != 0 ? scores[0].score : 0;
               

            });
            yield return new WaitWhile(() => done == false);
        }

        public void SubmitScore(int score)
        {
            LoadPrefs();
            Score = score;
            StartCoroutine(SubmitScoreRoutine());
        }
        

        public void ShowLeaderboard()
        {
            StartCoroutine(ShowScoresRoutine());
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
        }
    }
}
