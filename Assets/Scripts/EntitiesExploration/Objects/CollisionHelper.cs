using UnityEngine;
using System.Collections;
/* Not sure this is really helpful 
 * 
 * 
 * */

#region Collisions

public class Tags
{
    // Built in tags
    public const string Respawn = "Respawn";
    public const string Finish = "Finish";
    public const string EditorOnly= "EditorOnly";
    public const string MainCamera= "MainCamera";
    public const string Player = "Player";
    public const string GameController= "GameController";

    //Custom tags
    public const string Monster = "Monster";
    public const string PlayerCombat = "PlayerCombat";
    public const string Sticky = "Sticky";
    public const string NPC = "NPC";
}


public enum Layers
{
    Default = 0,
    TransparentFX = 1,
    IgnoreRaycast = 2,
    Water = 4,
    UI = 5,

    Minimap = 8,
    NPC = 9,
    Ball = 10

}


public class CollisionHelper : MonoBehaviour
{

}

#endregion