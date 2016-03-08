
using UnityEngine;


[System.Serializable]
public class DetectArea {

  [SerializeField]
  MeshCollider _collider = null;
  public MeshCollider collider { get { return _collider; } }

  [SerializeField]
  [Range(0f, 10f)]
  float _range = 1f;
  public float range { get { return _range; } }

  /// <summary> トリガーの半径 </summary>
  public void Range(float value) {
    _range = value;
    var newRange = (Vector3.one - Vector3.up) * _range + Vector3.up;
    _collider.transform.localScale = newRange;
  }

  [SerializeField]
  [Range(0f, 10f)]
  float _forwardOffset = 0f;
  public float forwardOffset { get { return _forwardOffset; } }

  /// <summary> トリガー中心位置の移動 </summary>
  public void ForwardOffset(float value) {
    _forwardOffset = value;
    _collider.transform.localPosition = Vector3.zero;
    _collider.transform.Translate(Vector3.forward * _forwardOffset);
  }
}


public class EnemyDetectArea : MonoBehaviour {

  [SerializeField]
  DetectArea _kill = null;

  [SerializeField]
  DetectArea _chase = null;
  public DetectArea chase { get { return _chase; } }

  [SerializeField]
  DetectArea _alert = null;
  public DetectArea alert { get { return _alert; } }


  /// <summary> 指定した探知範囲のパラメータを設定 </summary>
  public void Setup(DetectArea area, float range, float offset) {
    area.Range(range);
    area.ForwardOffset(offset);
  }

  void Start() {
    // TIPS: インスペクターの設定をトリガーに反映する
    Setup(_kill, _kill.range, _kill.forwardOffset);
    Setup(chase, chase.range, chase.forwardOffset);
    Setup(alert, alert.range, alert.forwardOffset);
  }
}
