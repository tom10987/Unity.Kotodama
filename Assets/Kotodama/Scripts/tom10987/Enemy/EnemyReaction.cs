
using UnityEngine;


public class EnemyReaction : MonoBehaviour {

  [SerializeField]
  EnemyState _state = EnemyState.None;

  EnemyActor _actor = null;
  readonly string _player = "Player";


  void Start() {
    _actor = GetComponentInParent<EnemyActor>();
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != _player) { return; }
    _actor.State(_state);
  }
}
