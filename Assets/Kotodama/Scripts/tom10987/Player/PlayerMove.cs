
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  public void OnTouch() { PlayerState.instance.Move(); }
}
