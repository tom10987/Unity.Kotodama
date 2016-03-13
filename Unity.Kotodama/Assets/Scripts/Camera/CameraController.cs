
using UnityEngine;
using System.Collections;

public class CameraController : SingletonBehaviour<CameraController> {

  [SerializeField]
  Vector3 _start = Vector3.zero;

  /// <summary> カメラの注視対象の位置を取得 </summary>
  public Transform target { get; set; }

  /// <summary> ターゲットを追尾中なら true を返す </summary>
  public bool isRunning { get; private set; }

  /// <summary> ターゲットの追尾を開始 </summary>
  public void ChaseStart() { StartCoroutine(UpdateCamera()); }

  /// <summary> 指定されたターゲットの追尾を開始 </summary>
  public void ChaseTarget(Transform target) {
    this.target = target;
    ChaseStart();
  }

  IEnumerator UpdateCamera() {
    isRunning = true;
    while (target != null) {
      transform.position = target.position + _start;
      yield return null;
    }
    isRunning = false;
  }
}
