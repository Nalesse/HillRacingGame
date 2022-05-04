using System;
using UI;
using UnityEngine;

namespace Road.Road_Objects
{
    public class Ring : SpeedBoost
    {
        [SerializeField] private float liftForce;
        [SerializeField] private float timeToAdd;
        private Timer timer;

        private void Start()
        {
            timer = GameObject.Find("Timer").GetComponent<Timer>();
        }

        protected override void OnTriggerEnter(Collider col)
        {
            base.OnTriggerEnter(col);
            Debug.Log("Ring trigger works");
            Player.Player.Instance.playerRB.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
            timer.timeLeft += timeToAdd;

        }
    }
}
