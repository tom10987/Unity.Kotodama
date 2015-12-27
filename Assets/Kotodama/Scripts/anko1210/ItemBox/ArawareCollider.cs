using UnityEngine;

public class ArawareCollider : MonoBehaviour {

    PlayerStatus state { get { return PlayerStatus.instance; } }
    PopUpCanvas popup { get { return PopUpCanvas.instance; } }

    [SerializeField]
    private string _itemName;
    private ItemState _itemState;
    [SerializeField]
    private string _DestroyText = "どこか消えちゃった…";
    [SerializeField]
    private string _StayText = "近付かないほうがいいかも";

    /// <summary>
    /// あらわれちゃん
    /// </summary>
    private bool _isDestroy;
    private float _alpha = 1f;
    private Collider _collider;
    private SpriteRenderer _sprite;

    void Start()
    {
        _isDestroy = false;
        _collider = this.gameObject.GetComponent<Collider>();
        _sprite = this.gameObject.GetComponentInChildren<SpriteRenderer>();
        _itemState = GameObject.Find(_itemName).gameObject.GetComponentInChildren<ItemState>();
        if (_itemState == null)
        { Debug.LogError(this.gameObject.name + "のitemStateがみつかりません"); }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals(ObjectTag.player))
        {
            state.MoveStop();
            if (_itemState.hasItem)
            {
                _itemState.UpdateState(false);
                _isDestroy = true;
            }
            else { popup.CreatePopUpWindow(_StayText); }
        }
    }

    void OnTriggerExit()
    {
        popup.IsCancel();
    }

    void DestroyAraware()
    {
        state.MoveStop();
        var view = (_alpha >= 0f) ? 1f : 0f;
        _alpha -= view * Time.deltaTime;
        _sprite.color = new Vector4(_alpha, _alpha, _alpha, _alpha);
        if (_alpha <= 0f)
        {
            popup.CreatePopUpWindow(_DestroyText);
            Destroy(this.gameObject);
            popup._count = 1f;
            popup.IsCancel();
        }
    }


    void Update()
    {
        if(_isDestroy) { DestroyAraware(); }
    }
}
