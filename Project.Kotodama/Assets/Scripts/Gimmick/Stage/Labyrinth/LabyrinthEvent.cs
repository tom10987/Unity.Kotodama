
using UnityEngine;

public class LabyrinthEvent : MonoBehaviour {

  [SerializeField]
  MoveObstacle[] _moveObstacles = null;

  bool _eventStart = false;

  void Start() { EnemyManager.instance.ActivateActors(); }

  void OnTriggerEnter(Collider other) {
    if (_eventStart) { return; }
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }
    _eventStart = true;
    foreach (var obstacle in _moveObstacles) { obstacle.StartMove(); }
  }
}
