
using UnityEngine;
using UnityEngine.UI;


public class DialButton : MonoBehaviour {
  [SerializeField]
  Text Dial;

  [SerializeField]
  int TrueNumber = 1234567890;

  /*
  [SerializeField]
  bool clear = false;
  */

  //public Event r;

  void Start() {
    Dial.text = null;
    //r.
  }

  public void DialToText(int i) {
    if (Dial.text.Length < 10)
      Dial.text += i;
  }

  public void BackSpace() {
    Dial.text = null;
  }

  public void Enter() {
    if (Dial.text == TrueNumber.ToString()) {
      //clear = true;
    }
  }
}
