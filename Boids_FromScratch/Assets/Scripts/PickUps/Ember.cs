using UnityEngine;
using System.Collections;

public class Ember : MonoBehaviour
{
    public AudioClip CollectPUSFX;
    private SoundManager _soundManager;
    private float lifeTime = 40;

    private void Start()
    {
        _soundManager = GetComponent<SoundManager>();

        Destroy(gameObject, lifeTime);
    }


    public void Collect()
    {
        _soundManager.PlaySFXClip(CollectPUSFX);
        StartCoroutine(RemoveGameObject());
        transform.GetChild(0).gameObject.SetActive(false);

    }

    private IEnumerator RemoveGameObject()
    {
        yield return new WaitForSeconds(30.0f);
        Destroy(gameObject);
    }

}
