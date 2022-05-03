using UnityEngine.Events;

namespace Misc
{
    public static class GameEvents
    {
        /// <summary>
        /// Event that fires everytime the game timer reaches 0
        /// </summary>
        public static readonly UnityEvent TimerCompleted = new UnityEvent();

        /// <summary>
        /// Triggers the game over state
        /// </summary>
        public static readonly UnityEvent GameOver = new UnityEvent();
    }
}
