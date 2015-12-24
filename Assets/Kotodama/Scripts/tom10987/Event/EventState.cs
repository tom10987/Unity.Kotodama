
using UnityEngine;


public class EventState : MonoBehaviour {

  enum SpritePosition : uint { Left, Center, Right, }
  
  [SerializeField]
  RectTransform[] _spritePosition = null;
}
