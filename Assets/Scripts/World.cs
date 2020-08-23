using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    private static PlayerController _player = null;

    /// <summary>
    /// Returns the player in the world
    /// </summary>
    /// <returns></returns>
    public static PlayerController GetPlayer()
    {
        if (!_player)
        {
            _player = FindObjectOfType<PlayerController>();
        }
        return _player;
    }
}
