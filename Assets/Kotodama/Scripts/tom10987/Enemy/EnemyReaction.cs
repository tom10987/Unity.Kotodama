
using UnityEngine;


public class EnemyReaction : MonoBehaviour {

  [SerializeField]
  EnemyState _state = EnemyState.None;

  [SerializeField]
  EnemyActor _actor = null;


  void Start() {
    if (_actor == null) { _actor = GetComponentInParent<EnemyActor>(); }
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }
    _actor.SetTarget(other.transform);
    _actor.State(_state);
  }
}
