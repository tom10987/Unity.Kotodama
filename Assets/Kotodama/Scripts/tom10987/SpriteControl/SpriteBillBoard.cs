
using UnityEngine;


public class SpriteBillBoard : MonoBehaviour {

  Quaternion _rotate = Quaternion.identity;


  void Start() {
    var camera_ = Camera.main.transform;
    _rotate = camera_.rotation;

    var renderer_ = GetComponent<MeshRenderer>();
    if (renderer_ != null) { renderer_.enabled = false; }
  }

  void Update() {
    if (transform.rotation == _rotate) { return; }
    transform.rotation = _rotate;
  }
}
