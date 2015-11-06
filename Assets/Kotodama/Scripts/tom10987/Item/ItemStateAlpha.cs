
using UnityEngine;


public class ItemStateAlpha : MonoBehaviour {

  void Start() {
    var renderer = GetComponent<SpriteRenderer>();
    renderer.color = Color.white * 0.5f;
  }

  public void SpriteActivate() {
    var renderer = GetComponent<SpriteRenderer>();
    renderer.color = Color.white;
  }
}
