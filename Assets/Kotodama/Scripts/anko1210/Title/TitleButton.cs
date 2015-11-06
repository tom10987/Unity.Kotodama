
using UnityEngine;
using UnityEngine.UI;


public class TitleButton : MonoBehaviour {

  [SerializeField]
  bool _isSelectable = false;
  bool isSelect { get { return TitleManager.isSelect; } }

  Image _image = null;

  float alpha {
    get {
      var alpha_ = TitleManager.buttonAlpha;
      return _isSelectable ? alpha_ : 1 - alpha_;
    }
  }


  void Start() {
    _image = GetComponent<Image>();
    _image.color = Color.white * alpha;
    _image.raycastTarget = _isSelectable;
  }

  void Update() {
    if (!isSelect) { return; }
    if (TitleManager.buttonAlpha > 0f) { _image.color = Color.white * alpha; }
    if (_image.raycastTarget == _isSelectable) { _image.raycastTarget = !_isSelectable; }
  }
}
