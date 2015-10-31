
using UnityEngine;


public class CameraMove : MonoBehaviour {

  Transform _camera = null;


  void Start() {
    _camera = Camera.main.transform;
  }

  void Update() {
    _camera.position = transform.position + Vector3.back;
  }
}
