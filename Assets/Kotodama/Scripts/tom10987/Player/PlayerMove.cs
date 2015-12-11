
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  PlayerStatus state { get { return PlayerStatus.instance; } }
  public void OnTouch() { state.MoveStart(); }
}
