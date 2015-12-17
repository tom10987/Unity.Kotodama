
using UnityEngine;


public class EventTrigger : MonoBehaviour {

  [SerializeField]
  [Tooltip("イベント発生したら削除するかどうか")]
  bool _removeEvent = false;

  [SerializeField]
  string _eventName = string.Empty;


  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.player) { return; }

    var body = other.GetComponent<Rigidbody>();
    body.velocity = Vector3.zero;
    _eventName = "test";

    if (_removeEvent) { Destroy(gameObject); }
  }
}
