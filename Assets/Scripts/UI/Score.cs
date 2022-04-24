using TMPro;
using UnityEngine;

namespace UI
{
    public class Score : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private float score;
        [SerializeField] private float tempScore;
        private float highScore;
        [SerializeField] private TextMeshProUGUI scoreValue;
        [SerializeField] private TextMeshProUGUI finalScoreValue;
        [SerializeField] private TextMeshProUGUI tempScoreValue;
        [SerializeField] private TextMeshProUGUI highScoreValue;
        [SerializeField] private TextMeshProUGUI pointMultValue;
        private float pointsIncreasing;
        private int pointMultiplier;
        private TrickSystem TrickSystem;

        public float trickBuffer;
    
        private bool isScoreMultiplying = true;

        [Header("Score Requirement")]
        [SerializeField] private float scoreRequirement;
        [SerializeField] private float increaseAmount;
        [SerializeField] private int timerDecreaseRound;
        [SerializeField] private int timerDecreaseAmount;
        [SerializeField] private Timer timer;

        [SerializeField] private TextMeshProUGUI goalValue;

        // for debug only
        [Header("Debug")]
        [SerializeField] private bool enableGameOver;

        private void OnEnable()
        {
            GameEvents.TimerCompleted.AddListener(ScoreRequirement);
            GameEvents.GameOver.AddListener(GameOver);
        }

        private void OnDisable() => GameEvents.TimerCompleted.RemoveListener(ScoreRequirement);

        private void Start()
        {
            score = 0f;
            goalValue.text = "" + scoreRequirement;
            pointsIncreasing = 1f;
            TrickSystem = GameObject.Find("Player").GetComponent<TrickSystem>();
            
            if (!PlayerPrefs.HasKey("HighScore")) return;

            highScore = PlayerPrefs.GetFloat("HighScore");
            highScoreValue.text = $"{(int)highScore:00000}";
        }

        // Update is called once per frame
        private void Update()
        {
            scoreValue.text = $"{(int)score:00000}";
            finalScoreValue.text = $"{(int)score}";
            tempScoreValue.text = $"{(int)tempScore:00000}";
        

            if (TrickSystem.isDoingTrick)
            {
                pointsIncreasing = 100 * Time.deltaTime;
                tempScore += pointsIncreasing;
            }
            if (TrickSystem.isDoingTrickSmaller)
            {
                pointMultValue.text = "x" + $"{(int)pointMultiplier + 1}";
            }

            if (Player.Instance.isDamage)
            {
                //Debug.Log("TempScoreToZero");
                tempScore = 0;
            }

            if (Player.Instance.isGrounded)
            {

                score += tempScore * pointMultiplier;
                tempScore = 0;
                pointMultiplier = 0;
                pointMultValue.text = "x" + $"{(int)pointMultiplier + 1}";
            }

        

            if (!TrickSystem.isDoingTrickSmaller && tempScore > 0)
            {
            
                if (isScoreMultiplying == true && trickBuffer >= 10)
                {
                    trickBuffer = 0;
                    //Debug.Log(pointMultiplier + " point multiplier");
                    pointMultiplier += 1;
                    isScoreMultiplying = false;
                }
            }
            else
            {
                isScoreMultiplying = true;
            }
        }
        private void FixedUpdate()
        {
            if (TrickSystem.isDoingTrick)
            {
                trickBuffer += 0.1f;
            }
        }

        private void ScoreRequirement()
        {
            if (score < (int)scoreRequirement)
            {
                if (enableGameOver)
                {
                    GameEvents.GameOver?.Invoke();
                }
            
                Debug.Log("Game Over");
            }
            else
            {
                scoreRequirement += increaseAmount;
                increaseAmount += 500;
                scoreRequirement = Mathf.CeilToInt(scoreRequirement);
                goalValue.text = $"{scoreRequirement}";

                if (timer.RoundCounter >= timerDecreaseRound)
                {
                    timer.TimerLength -= timerDecreaseAmount;
                    timerDecreaseAmount += 5;
                }
                
                Debug.Log("Score Requirement: " + (int)scoreRequirement);
            }
        }
        private void GameOver()
        {
            if (!(score > highScore)) return;
        
            highScore = (int)score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
            LeaderboardController.Instance.SubmitScore();
            highScoreValue.text = $"{(int)highScore:00000}";
        } 
    }
}
