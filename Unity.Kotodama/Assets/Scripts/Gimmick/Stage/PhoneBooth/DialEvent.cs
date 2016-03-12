
using UnityEngine;

public class DialEvent : MonoBehaviour {

  [SerializeField]
  DialButton _dialEvent = null;

  void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }
    Instantiate(_dialEvent);
    GameManager.instance.Pause();
  }
}
