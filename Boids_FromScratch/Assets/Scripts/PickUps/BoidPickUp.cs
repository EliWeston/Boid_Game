using UnityEngine;
using System.Collections;

public class BoidPickUp : MonoBehaviour
{

    private float lifeTime = 40;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void Collect()
    {
        StartCoroutine(RemoveGameObject());
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private IEnumerator RemoveGameObject()
    {
        yield return new WaitForSeconds(30.0f);
        Destroy(gameObject);
    }

}
