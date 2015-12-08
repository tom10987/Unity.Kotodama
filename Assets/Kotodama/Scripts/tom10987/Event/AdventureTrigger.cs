
using UnityEngine;


public class AdventureTrigger : MonoBehaviour {

  [SerializeField]
  [Tooltip("イベント発生したら削除するかどうか")]
  bool _removeTrigger = false;

  [SerializeField]
  string _jsonName = string.Empty;


  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.player) { return; }
    if (_jsonName == string.Empty) { return; }

    var body = other.GetComponent<Rigidbody>();
    body.velocity = Vector3.zero;
    Adventure.instance.Activate(_jsonName);

    if (_removeTrigger) { Destroy(gameObject); }
  }
}
