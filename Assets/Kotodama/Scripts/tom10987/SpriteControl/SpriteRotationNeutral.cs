
using UnityEngine;


public class SpriteRotationNeutral : MonoBehaviour {

  Quaternion _rotate = Quaternion.identity;


  void Start() {
    _rotate = transform.rotation;
  }

  void Update() {
    transform.rotation = _rotate;
  }
}
