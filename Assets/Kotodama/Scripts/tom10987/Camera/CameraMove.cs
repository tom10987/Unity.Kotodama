
using UnityEngine;


public class CameraMove : MonoBehaviour {

  static public Transform target { get; set; }
  Vector3 _start = Vector3.zero;


  void Start() {
    _start = transform.position;
  }

  void Update() {
    if (target == null) { return; }
    transform.position = target.position + _start;
  }
}
