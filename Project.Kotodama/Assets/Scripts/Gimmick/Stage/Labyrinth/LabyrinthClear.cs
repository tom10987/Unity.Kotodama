
using UnityEngine;

public class LabyrinthClear : MonoBehaviour {

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }
    EnemyManager.instance.DestroyActors();
  }
}
