using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public static int quantity = 0;
    Text bulletsQuantity;

    private void Start()
    {
        bulletsQuantity = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        bulletsQuantity.text = ": " + quantity;
    }
}
