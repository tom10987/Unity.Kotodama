
using UnityEngine;


public class ScreenInfo : MonoBehaviour {

  // 画面サイズを返す
  // TIPS: GameObject の Transform が Vector3 を使うため、Vector3 で返す
  static public Vector3 size {
    get {
      var width = (float)Screen.width;
      var height = (float)Screen.height;
      return new Vector3(width, height);
    }
  }

  // 画面中央の座標を返す
  // TIPS: GameObject の Transform が Vector3 を使うため、Vector3 で返す
  static public Vector3 center { get { return size * 0.5f; } }

  // 正投影カメラの Aspect、OrthoGraphicSize を反映させた画面比率を返す
  static public Vector3 aspect {
    get {
      var aspect = Camera.main.aspect;
      var orthoSize = Camera.main.orthographicSize;
      return new Vector3(aspect * orthoSize, orthoSize);
    }
  }
}
