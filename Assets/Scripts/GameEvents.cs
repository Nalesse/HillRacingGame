using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public static class GameEvents
{
    /// <summary>
    /// Event that fires everytime the game timer reaches 0
    /// </summary>
    public static readonly UnityEvent TimerCompleted = new UnityEvent();
}
