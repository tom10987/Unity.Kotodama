
using UnityEngine;


public class EventStarter : MonoBehaviour {

  [SerializeField]
  GameObject _dialCanvas = null;

  void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }
    PlayerState.instance.Stop();
    Instantiate(_dialCanvas);
  }
}
