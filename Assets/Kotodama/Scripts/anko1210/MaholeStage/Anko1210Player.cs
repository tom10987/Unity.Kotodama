using UnityEngine;

public class Anko1210Player : MonoBehaviour {

    PlayerStatus state { get { return PlayerStatus.instance; } }
    ItemManager manager { get { return ItemManager.instance; } }
    PopUpCanvas _puc;
    ManholeScript _ms;
    
    /// <summary>
    ///  アラワレ消すようの変数群
    /// </summary>
    private Collider _col;
    private SpriteRenderer _spriteRenderer;
    private float _alpha = 1f;
    private bool _IsArawareDead;


    void Start () {
        _puc = GameObject.FindObjectOfType<PopUpCanvas>();
        _ms = GameObject.FindObjectOfType<ManholeScript>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 8)
        {
            if (col.gameObject.tag.Equals(ObjectTag.enemy))
            {
                state.MoveStop();
                CheckAraware(col);
            }
        }
    }

    void OnTriggerStay(Collider col)
    { 
        /// ギミックというＬａｙｅｒにだけレイ飛ばしてる
        /// 他の場所をタップしてギミックが発動しないようにするため
        Ray ray = Camera.main.ScreenPointToRay(TouchController.GetTouchScreenPosition());
        RaycastHit hit;
        int layerMask = LayerMask.GetMask(new string[] { LayerMask.LayerToName(8)});
        float maxDistance = 150f;

        if (Physics.Raycast(ray, out hit, maxDistance, layerMask))
        {
            if (TouchController.IsTouchBegan())
            {
                if (col.gameObject.tag.Equals(ObjectTag.gimmick))
                {
                    state.MoveStop();
                    GimmickJump(col);
                }
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        /// 徘徊する敵に衝突する
        if (col.gameObject.tag.Equals(ObjectTag.enemy))
        {
            if (col.gameObject.name == "MoveEnemy")
            {
                _ms.ChangePosition(StartPosition.ManholeStage);
                _ms.ChangeMapView(true);
            }
        }
        /// アイテムを拾う
        else if (col.gameObject.tag.Equals(ObjectTag.item)) { ItemGet(col); }
        /// ゴールテープに衝突
        else if (col.gameObject.name.Equals("GoalTape"))
        {
            var itemState = GameObject.Find("Bill").GetComponentInChildren<ItemState>();
            if (itemState.hasItem)
            {
                _puc._str = col.gameObject.name;
                _puc.CreatePopUpWindowVerGimmick("神社に戻りますか？", _puc.IsEnd);
            }
            else { _puc.CreatePopUpWindow("忘れものがあるみたい"); }
        }
    }

    void OnCollisionExit()
    {
        _puc._count = 1f;
    }

    void OnTriggerExit()
    {
        _puc.IsCancel();
    }

    void GimmickJump(Collider col)
    {
        if (col.gameObject.name.Equals(GimmickObjectName.board))
        {
            _puc.CreatePopUpWindowVerGimmick("掲示板です", _puc.IsCancel);
        }
        if (col.gameObject.name.Equals(GimmickObjectName.switchA))
        {
            _puc.CreatePopUpWindowVerGimmick("スイッチを押しますか？", _puc.IsFloorMove);
        }
        if (col.gameObject.name == "ManholeKey_B")
        {
            IsHasKey(col, "KeyMB");
        }
        if (col.gameObject.name == "ManholeKey_D")
        {
            IsHasKey(col, "KeyMD");
        }
        else
        {
            _puc._str = col.gameObject.name;
            _puc.CreatePopUpWindowVerGimmick("移動しますか？", _puc.IsWarpMari);
        }
    }

    void ItemGet(Collision col)
    {
        var itemState = col.gameObject.GetComponentInChildren<ItemState>();
        var effect = col.gameObject.GetComponentInChildren<ParticleSystem>();
        itemState.UpdateState(true);
        _puc.CreatePopUpWindowVerItem(ItemData.ToString(itemState.itemName));
        col.collider.isTrigger = true;
        effect.loop = false;
    }

    void IsHasKey(Collider col, string str)
    {
        ItemState itemState = GameObject.Find(str).GetComponentInChildren<ItemState>();
        if (col.gameObject.name == itemState.itemName.ToString())
        {
            if(itemState.hasItem)
            {
                _puc._str = col.gameObject.name;
                _puc.CreatePopUpWindowVerGimmick("移動しますか？", _puc.IsWarpMari);
            }
            else {
                _puc.CreatePopUpWindow("カギかかかって開かない"); }
        }
    }

    void CheckAraware(Collider col)
    {
        var keyName = new string[] { "KeyA", "KeyB", "KeyC", "KeyD" };

        for (int i = 0; i < keyName.Length; i++)
        {
            ItemState itemState = GameObject.Find(keyName[i]).GetComponentInChildren<ItemState>();

            if (col.gameObject.name.Equals(itemState.itemName.ToString()))
            {
                if (itemState.hasItem)
                {
                    _col = col;
                    _spriteRenderer = col.gameObject.GetComponentInChildren<SpriteRenderer>();
                    _alpha = 1f;
                    _IsArawareDead = true;
                    itemState.UpdateState(false);
                }
                else _puc.CreatePopUpWindow("近付かない方がいいかも");
            }
        }
    }

    void DestroyAwarare(float time)
    {
        if (_spriteRenderer != null)
        {
            state.MoveStop();
            var view = (_alpha >= 0f) ? time : 0f;
            _alpha -= view * Time.deltaTime;
            Debug.Log("alpha : " + _alpha);
            _spriteRenderer.color = new Vector4(_alpha, _alpha, _alpha, _alpha);
            if (_alpha <= 0)
            {
                Destroy(_col.gameObject);
                _puc.CreatePopUpWindow("どこか消えちゃった…");
                _IsArawareDead = false;
                _alpha = 1f;
                _spriteRenderer = null;
                _puc._count = 1f;
                _puc.IsCancel();
            }
        }
    }

    void Update()
    {
        if (_IsArawareDead) { DestroyAwarare(1f); }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _ms.ChangePosition(StartPosition.ManholeStage);
            _ms.ChangeMapView(true);
            state.MoveStop();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _ms.DestroyStage();
            manager.items.Clear();
            _ms.RESET();
            state.MoveStop();
        }
    }
}
