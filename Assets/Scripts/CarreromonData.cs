using UnityEngine;

using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "Inventory Carreromon Data", menuName = "Inventory System/Create Carreromon")]
public class CarreromonData : ScriptableObject
{
    public string id;
    public string itemName;
    public Sprite itemIcon;
    public string[] dimensionesNombre;
    public int[] dimensionesValor;

}


