using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Information : MonoBehaviour
{
    public GameObject _GO;
    public string _name, _tag;
    public int damage, healing;

    private void Awake()
    {
        _GO = gameObject;
    }
}
