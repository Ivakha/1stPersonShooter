using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ammo Bonus")
        {
            PlayerShooting playerShooting = GetComponentInChildren<PlayerShooting>();
            AmmoBonus ammoBonus = other.GetComponent<AmmoBonus>();
            playerShooting.AddAmmo(ammoBonus.ammoAmount);
            ammoBonus.DestroyBonus();
        }
    }
}
