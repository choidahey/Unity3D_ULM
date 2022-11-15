using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{

    //List<AssetBundle> bundle = new List<AssetBundle>();
    //Dictionary<string, AssetBundle> dicBundles = new Dictionary<string, AssetBundle>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(
                    AssetManager.instance.LoadFromMemoryAsynce("Assets/AssetBundles/building", (bundle) =>
                    {
                        Debug.LogFormat("bundle: {0}", bundle);
                        var prefab1 = bundle.LoadAsset<GameObject>("Library");
                        var model1 = Instantiate<GameObject>(prefab1);

                        var prefab2 = bundle.LoadAsset<GameObject>("Gym");
                        var model2 = Instantiate<GameObject>(prefab2);

                        var prefab3 = bundle.LoadAsset<GameObject>("munhaksa");
                        var model3 = Instantiate<GameObject>(prefab3);

                        var prefab4 = bundle.LoadAsset<GameObject>("Headquaters");
                        var model4 = Instantiate<GameObject>(prefab4);

                        var prefab5 = bundle.LoadAsset<GameObject>("NoCheon");
                        var model5 = Instantiate<GameObject>(prefab5);

                        var prefab6 = bundle.LoadAsset<GameObject>("Play Ground");
                        var model6 = Instantiate<GameObject>(prefab6);

                        var prefab7 = bundle.LoadAsset<GameObject>("Daehakwon");
                        var model7 = Instantiate<GameObject>(prefab7);

                        var prefab8 = bundle.LoadAsset<GameObject>("Lecture Hall");
                        var model8 = Instantiate<GameObject>(prefab8);

                        var prefab9 = bundle.LoadAsset<GameObject>("Hue");
                        var model9 = Instantiate<GameObject>(prefab9);
                        
                        var prefab10 = bundle.LoadAsset<GameObject>("Tennis");
                        var model10 = Instantiate<GameObject>(prefab10);
                        
                    })

            );
    }
}