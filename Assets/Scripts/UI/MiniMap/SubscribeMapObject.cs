using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SubscribeMapObject : MonoBehaviour {

    public Image image;
    private MiniMapController _miniMapController;

    void Awake()
    {
        _miniMapController = MiniMapController.Instance();
    }
    // Use this for initialization
    void Start () {
        
        if(image == null)
        {
            Debug.LogError(this.gameObject.name + " has no image");
        }
        else
        {
            _miniMapController.RegisterMapObject(this.gameObject, image);
        }

        if(transform.parent == null)
        {
            Debug.LogWarning(this.gameObject.name + " has no parent");
        }
	}
	
	void OnDestroy()
    {
        _miniMapController.RemoveMapObject(this.gameObject);
    }

    void UnSubscribe()
    {
        _miniMapController.RemoveMapObject(this.gameObject);
    }

}
