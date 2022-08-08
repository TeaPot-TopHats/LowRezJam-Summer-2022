using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SORT_TEXT_MESH : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMesh>().GetComponent<Renderer>().sortingOrder = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(HOVER_TEXT_MANAGER.TextStatus == false)
        {
            Destroy(gameObject);
        }
    }
}
