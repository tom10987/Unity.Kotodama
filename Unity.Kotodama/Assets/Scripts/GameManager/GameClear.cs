
using UnityEngine;

public class GameClear : MonoBehaviour {

  [SerializeField]
  ItemType _itemName = ItemType.Empty;

  [SerializeField, Range(1f, 3f)]
  float _effectTime = 2f;

  public void OnTriggerEnter(Collider other) {
    if (!ObjectTag.Player.EqualTo(other.tag)) { return; }

    var find = ItemManager.instance.GetItem(_itemName);
    if (find == null) { return; }

    PlayerState.instance.Stop();

    System.Action Finish = () => { SceneTag.Ending.ChangeScene(); };
    ScreenSequencer.instance.SequenceStart(Finish, new Fade(_effectTime));
  }
}
