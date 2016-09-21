
using UnityEngine;

public class BillBoard : MonoBehaviour {

  [SerializeField]
  bool _xReverse = false;

  [SerializeField]
  bool _zReverse = false;

  // TIPS: メインカメラに向かって正面を向くように自身を回転させる
  void FixedUpdate() {
    if (Camera.main == null) { return; }
    transform.rotation = Camera.main.transform.rotation;
  }

  void OnValidate() {
    if (!_xReverse && !_zReverse) { return; }

    var scale = transform.localScale.Absolute();
    if (_xReverse) { scale.x *= -1f; }
    if (_zReverse) { scale.z *= -1f; }
    transform.localScale = scale;
  }
}
