
using UnityEngine;


public class TouchController : MonoBehaviour {

  static bool IsAndroid {
    get { return Application.platform == RuntimePlatform.Android; }
  }

  static bool IsIPhone {
    get { return Application.platform == RuntimePlatform.IPhonePlayer; }
  }

  static public bool IsSmartDevice {
    get { return IsAndroid || IsIPhone; }
  }


  /// <summary>
  /// タッチされたスクリーン座標を返す
  /// </summary>
  static public Vector3 GetTouchScreenPosition() {
    // TIPS: スマートフォンでなければ、代わりにマウス位置を返す
    var pos = IsSmartDevice
      ? (Vector3)Input.touches[0].position
      : Input.mousePosition;
    return new Vector3(pos.x, pos.y);
  }

  /// <summary>
  /// 画面中央から見たスクリーン上のタッチ座標を返す
  /// </summary>
  static public Vector3 GetTouchScreenPositionFromCenter() {
    return GetTouchScreenPosition() - ScreenInfo.center;
  }

  /// <summary>
  /// タッチされたワールド座標を返す
  /// </summary>
  static public Vector3 GetTouchWorldPosition() {
    var touchPos = GetTouchScreenPositionFromCenter();
    var cameraPos = Camera.main.transform.position;
    cameraPos.z = 0f;

    // タッチがスクリーン座標なので、ワールド座標に変換
    var distance = Vector3.zero;
    distance.x = (touchPos.x / ScreenInfo.center.x) * ScreenInfo.orthoAspect.x;
    distance.y = (touchPos.y / ScreenInfo.center.y) * ScreenInfo.orthoAspect.y;

    return distance + cameraPos;
  }

  /// <summary>
  /// タッチされた瞬間 true を返す
  /// </summary>
  static public bool IsTouchBegan() {
    if (!IsSmartDevice) { return Input.GetMouseButtonDown(0); }

    if (Input.touchCount <= 0) { return false; }
    return Input.touches[0].phase == TouchPhase.Began;
  }

  /// <summary>
  /// タッチされ続けている間 true を返す
  /// </summary>
  static public bool IsTouchMoved() {
    if (!IsSmartDevice) { return Input.GetMouseButton(0); }

    if (Input.touchCount <= 0) { return false; }

    var touch = Input.touches[0];
    var isMoved = touch.phase == TouchPhase.Moved;
    var isStationary = touch.phase == TouchPhase.Stationary;

    return isMoved || isStationary;
  }

  /// <summary>
  /// タッチが離された瞬間 true を返す
  /// </summary>
  static public bool IsTouchEnded() {
    if (!IsSmartDevice) { return Input.GetMouseButtonUp(0); }

    if (Input.touchCount <= 0) { return false; }
    return Input.touches[0].phase == TouchPhase.Ended;
  }

  /// <summary>
  /// Android 端末の戻るボタンが押された時 true を返す
  /// </summary>
  static public bool IsPushedQuitKey() {
    return Input.GetKeyDown(KeyCode.Escape);
  }
}
