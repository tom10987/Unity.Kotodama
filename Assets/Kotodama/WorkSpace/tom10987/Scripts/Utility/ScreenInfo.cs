
using UnityEngine;


public class ScreenInfo : MonoBehaviour {

  /// <summary>
  /// 画面サイズを返す
  /// </summary>
  static public Vector3 size {
    // TIPS: GameObject の Transform が Vector3 を使うため、Vector3 で返す
    get {
      var width = (float)Screen.width;
      var height = (float)Screen.height;
      return new Vector3(width, height);
    }
  }

  /// <summary>
  /// 画面中央の座標を返す
  /// </summary>
  static public Vector3 center { get { return size * 0.5f; } }

  /// <summary>
  /// 正投影カメラの Aspect、OrthoGraphicSize を反映させた画面比率を返す
  /// </summary>
  static public Vector3 orthoAspect {
    get {
      var aspect = Camera.main.aspect;
      var orthoSize = Camera.main.orthographicSize;
      return new Vector3(aspect * orthoSize, orthoSize);
    }
  }
}
