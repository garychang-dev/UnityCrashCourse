using System;
using UnityEngine;

[Serializable]
public struct PlayerMaterial
{
    public int playerIndex;
    public Material material;
}

public class PlayerColors : MonoBehaviour
{
    public PlayerMaterial[] playerColors;
}
