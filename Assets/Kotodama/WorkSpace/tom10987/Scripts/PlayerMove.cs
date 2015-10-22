
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  void Update() {
    var isPressMouse = Input.GetMouseButton(0);
    var isTouching = TouchController.IsTouchMoved();
    if (isPressMouse || isTouching) { Translate(); }
  }

  void Translate() {
  }
}
