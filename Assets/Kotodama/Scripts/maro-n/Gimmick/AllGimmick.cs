

using UnityEngine;


public class AllGimmick : MonoBehaviour
{

    bool _isHit = false;
    public bool _isClear = false;
    public bool isClear { get { return _isClear; } }

    void OnCollisionStay(Collision other)
    {

        // 灯籠の床部にプレイヤーが接触してる間
        _isHit = (other.gameObject.tag == ObjectTag.Player.ToString());
    }

    void Update()
    {
        // TIPS: 灯籠の床にプレイヤーが触れている かつ タッチされてなければスキップ
        if (!_isHit || !TouchController.IsTouchBegan()) { return; }

        // TIPS: タッチ位置から画面奥方向へのレイを生成
        Ray ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());
        RaycastHit hit = new RaycastHit();

        // TIPS: レイが当たってなければスキップ
        if (Physics.Raycast(ray, out hit)) { return; }

        // TIPS: レイがギミックに当たっていたらフラグを ON にする
        _isClear = (hit.collider.tag == ObjectTag.Gimmick.ToString());
    }
}

