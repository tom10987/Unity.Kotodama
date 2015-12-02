
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
    var touchPosition = (Input.touchCount > 0) ?
      (Vector3)Input.touches[0].position : Vector3.zero;
    return IsSmartDevice ? touchPosition : Input.mousePosition;
  }

  /// <summary>
  /// 画面中央から見たスクリーン上のタッチ座標を返す
  /// </summary>
  static public Vector3 GetTouchScreenPositionFromCenter() {
    return GetTouchScreenPosition() - ScreenInfo.center;
  }

  /// <summary>
  /// スクリーン座標を XZ 平面で見た場合の値として返す
  /// </summary>
  static public Vector3 GetTouchScreenPositionXZ() {
    var pos = GetTouchScreenPositionFromCenter();
    return new Vector3(pos.x, 0f, pos.y);
  }

  /// <summary>
  /// 画面中央から見たワールドの絶対座標を返す
  /// </summary>
  static public Vector3 GetTouchWorldPosition() {
    var touchPos = GetTouchScreenPositionFromCenter();

    // タッチがスクリーン座標なので、ワールド座標に変換
    var distance = Vector3.zero;
    distance.x = (touchPos.x / ScreenInfo.center.x) * ScreenInfo.orthoAspect.x;
    distance.y = (touchPos.y / ScreenInfo.center.y) * ScreenInfo.orthoAspect.y;

    return distance;
  }

  /// <summary>
  /// XZ 平面で見た場合のワールドの絶対座標を返す
  /// </summary>
  static public Vector3 GetTouchWorldPositionXZ() {
    var pos = GetTouchWorldPosition();
    pos.z = pos.y;
    pos.y = 0f;
    return pos;
  }

  /// <summary>
  /// カメラ座標を反映させたタッチのワールド座標を返す
  /// </summary>
  static public Vector3 GetTouchWorldPositionFromCamera() {
    var touchPos = GetTouchWorldPosition();
    var cameraPos = Camera.main.transform.position;
    cameraPos.z = 0f;
    return touchPos + cameraPos;
  }

  /// <summary>
  /// XZ 平面で見た場合のワールドの相対座標を返す
  /// </summary>
  static public Vector3 GetTouchWorldPositionFromCameraXZ() {
    var touchPos = GetTouchWorldPositionXZ();
    var cameraPos = Camera.main.transform.position;
    cameraPos.y = 0f;
    return touchPos + cameraPos;
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
