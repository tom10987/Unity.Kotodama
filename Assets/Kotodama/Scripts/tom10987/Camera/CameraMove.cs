
using UnityEngine;


public class CameraMove : MonoBehaviour {

  static public Transform target { get; set; }


  void Update() {
    if (target == null) { return; }

    var offset = Vector3.up * Camera.main.orthographicSize;
    transform.position = target.position + offset;
  }
}
