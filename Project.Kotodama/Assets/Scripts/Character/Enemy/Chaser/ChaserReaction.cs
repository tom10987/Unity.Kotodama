
using UnityEngine;

public class ChaserReaction : MonoBehaviour {

  [SerializeField]
  ChaseActor _actor = null;

  [SerializeField]
  ChaserState _state = ChaserState.None;

  [SerializeField]
  [Tooltip("追尾速度の増加割合（単位：1.00 倍）")]
  [Range(0f, 2f)]
  float _velocityRate = 1.0f;

  public void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }
    _actor.SetState(_state);
    _actor.agent.speed = _actor.defaultSpeed * _velocityRate;
  }
}
