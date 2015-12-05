
using UnityEngine;


//------------------------------------------------------------
// TODO:
// UI（ボタン）などにタッチした時は移動しないようにする

public class PlayerMove : MonoBehaviour {

  PlayerStatus state { get { return PlayerStatus.instance; } }

  public void OnTouch() { state.MoveStart(); }
}
