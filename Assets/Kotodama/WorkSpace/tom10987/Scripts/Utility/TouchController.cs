
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
  /// 描画画面のタッチ座標を返す
  /// </summary>
  static public Vector3 GetTouchPosition() {
    return Input.touches[0].position;
  }

  /// <summary>
  /// 画面比率を反映させたタッチ座標を返す
  /// </summary>
  static public Vector3 GetTouchViewPosition() {
    var distance = GetTouchPosition() - ScreenInfo.center;
    var x = (distance.x / ScreenInfo.center.x) * ScreenInfo.aspect.x;
    var y = (distance.y / ScreenInfo.center.y) * ScreenInfo.aspect.y;
    return new Vector3(x, y);
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
