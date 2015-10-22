
using UnityEngine;


public class PlayerMoveTest : MonoBehaviour {

  bool _State = false;

  Vector3 screenSize {
    get { return new Vector3(Screen.width, Screen.height); }
  }


  void Update() {
    var isMouseDown = Input.GetMouseButtonDown(0);
    var isTouch = TouchController.IsTouchBegan();
    if (isMouseDown || isTouch) {
      _State = !_State;
      var sprite = GetComponent<SpriteRenderer>();
      sprite.color = _State ? Color.white : Color.black;

      transform.position = GetMouseViewPosition();
    }
  }

  Vector3 GetMouseViewPosition() {
    var distance = Input.mousePosition - ScreenInfo.screenCenter;
    var normal = distance.normalized;
    var x = normal.x * ScreenInfo.screenAspect.x;
    var y = normal.y * ScreenInfo.screenAspect.y;
    return new Vector3(x, y);
  }
}
