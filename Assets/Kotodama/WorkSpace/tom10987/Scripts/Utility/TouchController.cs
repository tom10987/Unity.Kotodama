
using UnityEngine;
using Platform = UnityEngine.RuntimePlatform;


public class TouchController : MonoBehaviour {

  static int _touchId = -1;


  static bool IsAndroid {
    get { return Application.platform == Platform.Android; }
  }

  static bool IsIPhone {
    get { return Application.platform == Platform.IPhonePlayer; }
  }

  static public bool IsSmartDevice {
    get { return IsAndroid || IsIPhone; }
  }


  /// <summary>
  /// タッチされたスクリーン座標を返す
  /// </summary>
  static public Vector3 GetTouchScreenPosition() {
    var pos = Input.touches[0].position;
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
    var center = Camera.main.transform.position;
    center.z = 0f;

    var distance = Vector3.zero;
    distance.x = (touchPos.x / ScreenInfo.center.x) * ScreenInfo.aspect.x;
    distance.y = (touchPos.y / ScreenInfo.center.y) * ScreenInfo.aspect.y;

    return distance + center;
  }

  /// <summary>
  /// タッチされた瞬間 true を返す
  /// </summary>
  static public bool IsTouchBegan() {
    var count_ = Input.touchCount;
    if (count_ <= 0) { return false; }

    if (Input.touches[0].phase == TouchPhase.Began) {
      _touchId = Input.touches[0].fingerId;
      return true;
    }

    return false;
  }

  /// <summary>
  /// タッチされ続けている間 true を返す
  /// </summary>
  static public bool IsTouchMoved() {
    var count_ = Input.touchCount;
    if (count_ <= 0) { return false; }

    for (int i = 0; i < count_; ++i) {
      if (_touchId == Input.touches[i].fingerId) { return true; }
    }

    return false;
  }

  /// <summary>
  /// タッチが離された瞬間 true を返す
  /// </summary>
  /// <returns></returns>
  static public bool IsTouchEnded() {
    if (Input.touchCount <= 0) { return false; }
    return Input.touches[0].phase == TouchPhase.Ended;
  }

  /// <summary>
  /// Android 端末の戻るボタンが押された時 true を返す
  /// </summary>
  static public bool IsPushedQuitKey() {
    return IsAndroid && Input.GetKeyDown(KeyCode.Escape);
  }
}
