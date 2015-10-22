
using UnityEngine;


public class PlayerMove : MonoBehaviour {

  void Update() {
    var isPressMouse = Input.GetMouseButton(0);
    var isTouching = TouchController.IsTouchMoved();
    if (isPressMouse || isTouching) { Translate(); }
  }

  void Translate() {
    var distance = Vector3.zero;

    if (TouchController.IsSmartDevice) {
      var touchPos = TouchController.GetTouchViewPosition();
      distance = touchPos - transform.position;
    }
    else {
      var mousePos = Input.mousePosition - ScreenInfo.center;
      var x = (mousePos.x / ScreenInfo.center.x) * ScreenInfo.aspect.x;
      var y = (mousePos.y / ScreenInfo.center.y) * ScreenInfo.aspect.y;
      distance = (new Vector3(x, y)) - transform.position;
    }

    if (distance.magnitude < 1f) { return; }

    var normal = distance.normalized;
    transform.Translate(normal);
  }
}
