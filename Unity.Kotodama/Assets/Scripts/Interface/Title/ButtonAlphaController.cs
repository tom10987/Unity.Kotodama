
using UnityEngine;
using UnityEngine.UI;

public class ButtonAlphaController : MonoBehaviour {

  [SerializeField]
  Image[] _buttons = null;

  public void UpdateAlpha(float alpha) {
    foreach (var button in _buttons) {
      var color = button.color;
      color.a = alpha;
      button.color = color;
    }
  }
}
