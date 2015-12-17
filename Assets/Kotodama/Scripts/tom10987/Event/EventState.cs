
using UnityEngine;


// TODO: コルーチンにする
public class EventState : MonoBehaviour {

  const string Mari = "マリ";
  const string Nana = "ナナ";

  enum SpritePosition : uint { Left, Center, Right, }

  [SerializeField]
  Sprite[] _actors = null;

  [SerializeField]
  RectTransform[] _spritePosition = null;

  struct EventData {
    static public readonly EventData empty = new EventData {
      name = string.Empty,
      text = string.Empty,
    };

    public string name { get; set; }
    public string text { get; set; }
  }
}
