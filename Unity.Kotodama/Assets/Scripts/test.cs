
using UnityEngine;

public class test : MonoBehaviour {

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }
    EnemyManager.instance.ActivateActors();
  }
}
