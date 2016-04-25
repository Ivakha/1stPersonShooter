using UnityEngine;
using System.Collections;

public class AmmoBonus : MonoBehaviour {

    public int ammoAmount = 10;

    public void DestroyBonus()
    {
        Destroy(gameObject);
    }

}
