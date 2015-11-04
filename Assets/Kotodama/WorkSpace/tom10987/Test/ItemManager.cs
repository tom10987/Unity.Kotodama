
using UnityEngine;


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
