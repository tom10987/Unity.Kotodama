
using UnityEngine;

public class SpriteBillBoard : MonoBehaviour {

  Quaternion _rotate = Quaternion.identity;

  void Start() {
    _rotate = Camera.main.transform.rotation;
  }

  void Update() {
    if (transform.rotation == _rotate) { return; }
    transform.rotation = _rotate;
  }
}
