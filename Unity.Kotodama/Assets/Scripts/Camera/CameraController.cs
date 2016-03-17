
using UnityEngine;

public class CameraController : SingletonBehaviour<CameraController> {

  [SerializeField]
  Vector3 _start = Vector3.zero;

  /// <summary> カメラの注視対象の位置を取得 </summary>
  public Transform target { get; set; }

  /// <summary> ターゲットを追尾中なら true を返す </summary>
  public bool isRunning { get; private set; }

  void LateUpdate() {
    if (target == null) { return; }
    transform.position = target.position + _start;
  }
}
