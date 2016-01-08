
using UnityEngine;


public class GameClear : MonoBehaviour {
  
  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.player) { return; }
  }
}
