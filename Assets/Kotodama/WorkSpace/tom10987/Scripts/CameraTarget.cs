
using UnityEngine;


public class CameraTarget : MonoBehaviour {

  [SerializeField]
  GameObject _target = null;
  Transform _targetTransform = null;


  void Start() {
    _targetTransform = _target.transform;
  }

  void Update() {
    Debug.Log(transform.position);
    transform.position = _targetTransform.position + Vector3.back;
    Debug.Log(transform.position);
  }
}
