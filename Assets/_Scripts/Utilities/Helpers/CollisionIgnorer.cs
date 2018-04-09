using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnorer : MonoBehaviour {

    public int layer1;
    public int layer2;

    public void ToggleCollision(bool toggle)
    {
        Physics2D.IgnoreLayerCollision(layer1, layer2, toggle);
    }
}
