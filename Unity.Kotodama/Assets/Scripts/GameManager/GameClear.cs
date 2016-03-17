
using UnityEngine;
using System.Linq;

public class GameClear : MonoBehaviour {

  [SerializeField]
  ItemType[] _keyItems = null;

  [SerializeField, Range(1f, 3f)]
  float _effectTime = 2f;
  
  public void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    // TIPS: キーアイテムを全て所持していればゲームクリア
    var items = ItemManager.instance.items;
    var count = 0;
    foreach (var keyItem in _keyItems) {
      if (!items.Any(item => item.data.type == keyItem)) { break; }
      ++count;
    }
    if (count < 4) { return; }

    PlayerState.instance.Stop();

    System.Action Finish = () => { GameScene.Ending.ChangeScene(); };
    ScreenSequencer.instance.SequenceStart(Finish, new Fade(_effectTime));
  }
}
