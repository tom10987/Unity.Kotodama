
/*
using UnityEngine;


public class TouchGimmick : MonoBehaviour {

  public bool _isHit = false;
  public bool _isClear = false;

  void OnCollisionStay(Collision player) {
    // 灯籠の床部にプレイヤーが接触してる間
    if (player.gameObject.tag.Equals(bjectTag.player)) {
      _isHit = true;
    }
    else {
      _isHit = false;
    }
  }

  void ClearGimmick() {
    if (_isHit) {
      // 画面をタッチした時
      if (TouchController.IsTouchBegan()) {
        // カメラからタッチ位置へのレイを生成
        Ray ray_ = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());
        RaycastHit hit_ = new RaycastHit();

        // レイが当たったオブジェクトのコライダーを取得
        if (Physics.Raycast(ray_, out hit_)) {
          if (hit_.collider.gameObject.tag.Equals(bjectTag.gimmick)) {
            // クリアフラグをtrueにする
            if (!_isClear) {
              _isClear = true;
            }
          }
        }
      }
    }
  }

  void Update() {
    ClearGimmick();
  }
}
*/
