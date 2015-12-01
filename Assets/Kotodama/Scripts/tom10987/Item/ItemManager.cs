
using UnityEngine;


// TODO: アルファ発表用、統合に使えそうなら再利用
public class ItemManager : MonoBehaviour {

  static public bool hasItem { get; set; }


  void Awake() { hasItem = false; }

  void Start() {
    var renderer = GetComponentInChildren<SpriteRenderer>();
    renderer.color = Color.white;
  }

  public void OnTriggerEnter(Collider collider) {
    if (hasItem) { return; }
    hasItem = true;

    var renderer = GetComponentInChildren<SpriteRenderer>();
    renderer.color = Color.black * 0f;

    FindObjectOfType<ItemStateAlpha>().SpriteActivate();
  }
}
