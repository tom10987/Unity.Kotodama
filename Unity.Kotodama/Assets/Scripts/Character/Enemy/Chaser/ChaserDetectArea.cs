
using UnityEngine;

[System.Serializable]
public class DetectArea {

  [SerializeField]
  MeshCollider _collider = null;
  public MeshCollider collider { get { return _collider; } }

  [SerializeField]
  [Range(1f, 20f)]
  float _range = 1f;
  public float range {
    get { return _range; }
    set {
      _range = value;
      var newRange = (Vector3.one - Vector3.up) * _range + Vector3.up;
      _collider.transform.localScale = newRange;
    }
  }

  [SerializeField]
  [Range(0f, 10f)]
  float _forwardOffset = 0f;
  public float forwardOffset {
    get { return _forwardOffset; }
    set {
      _forwardOffset = value;
      _collider.transform.localPosition = Vector3.zero;
      _collider.transform.Translate(Vector3.forward * _forwardOffset);
    }
  }
}

public class ChaserDetectArea : MonoBehaviour {

  [SerializeField]
  DetectArea _kill = null;

  [SerializeField]
  DetectArea _chase = null;
  public DetectArea chase { get { return _chase; } }

  [SerializeField]
  DetectArea _alert = null;
  public DetectArea alert { get { return _alert; } }

  void Start() {
    Initialize(_kill, _kill.range, _kill.forwardOffset);
    Initialize(_chase, _chase.range, _chase.forwardOffset);
    Initialize(_alert, _alert.range, _alert.forwardOffset);
  }

  void Initialize(DetectArea area, float range, float offset) {
    area.range = range;
    area.forwardOffset = offset;
  }
}
