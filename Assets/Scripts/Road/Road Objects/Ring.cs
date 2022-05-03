using UnityEngine;

namespace Road.Road_Objects
{
    public class Ring : SpeedBoost
    {
        [SerializeField] private float liftForce;
    
        protected override void OnTriggerEnter(Collider col)
        {
            base.OnTriggerEnter(col);
            Debug.Log("Ring trigger works");
            Player.Player.Instance.playerRB.AddForce(Vector3.up * liftForce, ForceMode.Impulse);
        }
    }
}
