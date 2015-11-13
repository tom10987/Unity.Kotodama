
using UnityEngine;


public class WakuWakuNoKi : MonoBehaviour {

  Material _tree = null;
  float _time = 0f;

  Color _color = Color.white;


  void Start() {
    var mesh = GetComponent<MeshRenderer>();
    _tree = mesh.materials[3];
    _color = _tree.color;
  }

  void Update() {
    _time += Time.deltaTime * 5f;
    _tree.color = new Color(Mathf.Sin(_time), Mathf.Cos(_time), 1f);
  }

  public void OnApplicationQuit() {
    _tree.color = _color;
  }
}
