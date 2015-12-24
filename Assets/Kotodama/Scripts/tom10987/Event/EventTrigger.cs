
using UnityEngine;


public class EventTrigger : MonoBehaviour {

  [SerializeField]
  [Tooltip("イベント発生したら削除するかどうか")]
  bool _removeEvent = false;

  [SerializeField]
  Scenario.StoryName _eventName = Scenario.StoryName.None;


  public void OnTriggerEnter(Collider other) {
    if (other.tag != ObjectTag.player) { return; }

    var body = other.GetComponent<Rigidbody>();
    body.velocity = Vector3.zero;
    // TODO: アドベンチャーパート開始
    // manager.Adventure(_eventName);

    if (_removeEvent) { Destroy(gameObject); }
  }

  // test
  void hoge() {
    var character = Scenario.prologue[0].name;
    var nana = CharacterSprite.GetSprite(character);

    foreach (var scenario in Scenario.prologue) {
      Debug.Log(scenario.name);
      Debug.Log(scenario.text);

      var sprite = CharacterSprite.GetSprite(scenario.name);
      Debug.Log(sprite.name);
    }
  }
}
