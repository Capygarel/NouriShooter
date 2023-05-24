using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public  class IItem : MonoBehaviour
{
    public ItemData itemType;
    public void Effect() { }

    public  void UndoEffect() { }
}
