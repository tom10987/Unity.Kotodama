
using UnityEngine;


public class SpriteBillBoard : MonoBehaviour {

  void Start() {
    var camera = Camera.main.transform;
    transform.rotation = camera.rotation;

    GetComponentInParent<MeshRenderer>().enabled = false;
  }
}
