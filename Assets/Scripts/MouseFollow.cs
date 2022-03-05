using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mouseFollow;
    void Update()
    {
        
            var mousePos = Input.mousePosition;
            mousePos.z = 10;
            mouseFollow.transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        
    }
}
