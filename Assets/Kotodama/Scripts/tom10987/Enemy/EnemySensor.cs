
using UnityEngine;


[System.Serializable]
public class Sensor {

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


public class EnemySensor : MonoBehaviour {

  [SerializeField]
  Sensor _kill = null;

  [SerializeField]
  Sensor _detect = null;
  public float detectRange { get { return _detect.range; } }

  [SerializeField]
  Sensor _alert = null;
  public float alertRange { get { return _alert.range; } }


  void Start() {
    _kill.Setup();
    _detect.Setup();
    _alert.Setup();
  }
}
