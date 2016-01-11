
using UnityEngine;


public class GameClear : MonoBehaviour {

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }
    // TODO: Ending シーンに移動する処理
  }
}
