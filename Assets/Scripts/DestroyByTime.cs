using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float destroyTime = 5f;
    float pastTime = 0;

	void Update () {
        if (pastTime > destroyTime)
        {
            Destroy(gameObject);
        }
	    pastTime += Time.deltaTime;
	}
}
