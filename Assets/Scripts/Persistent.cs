using UnityEngine;
using System.Collections;
using System.Linq;

public class Persistent : MonoBehaviour {
    public string UniqueId;
	void Awake()
    {
        DontDestroyOnLoad(this);

        if(FindObjectsOfType<Persistent>().Where(o => o.UniqueId == UniqueId).Count() > 1)
        {
            Destroy(gameObject);
        }
    }
}
