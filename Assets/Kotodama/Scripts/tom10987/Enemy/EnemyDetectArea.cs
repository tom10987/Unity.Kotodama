
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

  [SerializeField]
  [Range(0f, 10f)]
  float _forwardOffset = 0f;


  public void Setup() {
    var range = (Vector3.one - Vector3.up) * _range + Vector3.up;
    _collider.transform.localScale = range;
    _collider.transform.Translate(Vector3.forward * _forwardOffset);
  }
}


public class EnemyDetectArea : MonoBehaviour {

  [SerializeField]
  DetectArea _kill = null;

  [SerializeField]
  DetectArea _chase = null;
  public float chaseRange { get { return _chase.range; } }

  [SerializeField]
  DetectArea _alert = null;
  public float alertRange { get { return _alert.range; } }


  void Start() {
    _kill.Setup();
    _chase.Setup();
    _alert.Setup();
  }
}
