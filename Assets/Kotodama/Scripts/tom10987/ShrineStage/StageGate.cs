
using UnityEngine;


public class StageGate : MonoBehaviour {

  ItemManager manager { get { return ItemManager.instance; } }

  [SerializeField]
  SceneTag _sceneName = SceneTag.Title;

  [SerializeField]
  ItemName _activeItem = ItemName.Empty;

  [SerializeField]
  GameObject _gateObject = null;


  void Start() {
    var existsItem = manager.items.ContainsKey(_activeItem);
    if (!existsItem) { return; }

    var isActive = manager.items[_activeItem].useItem;
    _gateObject.SetActive(isActive);
  }

  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }
    SceneSequencer.instance.SceneFinish(_sceneName.ToString());
  }
}
