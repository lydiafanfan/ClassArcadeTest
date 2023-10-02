using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Transform lookTarget;

    // Start is called before the first frame update
    virtual protected void Start() {}

    // Update is called once per frame
    virtual protected void Update() {}

    public void SetLookTarget(Transform aTarget) {
        lookTarget = aTarget;
    }

    public void DestroyEnemy() {
        GameManager.LogEnemyDestroyed();
        Destroy(this.gameObject);
    }
}
