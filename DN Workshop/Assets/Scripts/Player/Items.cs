using UnityEngine;

[CreateAssetMenu(order = 2, menuName = "Item/New items", fileName = "new item")]
public class Items : ScriptableObject
{
    public string itemName;
    public int sellValue;
    public int buyValue;
}
