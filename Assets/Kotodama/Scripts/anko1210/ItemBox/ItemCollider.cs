using UnityEngine;

public class ItemCollider : MonoBehaviour {
    
    PopUpCanvas popupCanvas { get { return PopUpCanvas.instance; } }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals(ObjectTag.player))
        {
            /// 中身
            var itemState = this.gameObject.GetComponent<ItemState>();
            var effect = this.gameObject.GetComponent<ParticleSystem>();
            var collider = this.gameObject.GetComponent<Collider>();
            itemState.UpdateState(true);
            popupCanvas.CreatePopUpWindowVerItem(ItemData.ToString(itemState.itemName));
            collider.isTrigger = true;
            effect.loop = false;
        }
    }

}
