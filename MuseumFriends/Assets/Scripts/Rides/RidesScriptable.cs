using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Rides Data")]
public class RidesScriptable : ScriptableObject
{
    public string id;
    public string ridename;
    public Sprite icon;
}
