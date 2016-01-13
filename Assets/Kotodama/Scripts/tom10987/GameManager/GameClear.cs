
using UnityEngine;


public class GameClear : MonoBehaviour {

  ItemManager manager { get { return ItemManager.instance; } }

  [SerializeField]
  ItemName _itemName = ItemName.Empty;


  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.Player.ToString()) { return; }

    // TIPS: アイテムを所有してなければ何もしない
    if (manager.items.ContainsKey(_itemName)) { return; }
    SceneSequencer.instance.SceneFinish(SceneTag.Ending.ToString());
  }
}
