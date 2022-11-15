using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AssetManager : MonoBehaviour
{

    public static AssetManager instance;

    private void Awake()
    {
        AssetManager.instance = this;


    }
    public IEnumerator LoadFromMemoryAsynce(string path, System.Action<AssetBundle> callback)
    {
        //파일을 바이트 배열로 읽어서 비동기 방식로 로드한다.

        byte[] binary = File.ReadAllBytes(path);
        AssetBundleCreateRequest req =
        AssetBundle.LoadFromMemoryAsync(binary);

        yield return req;

        callback(req.assetBundle);

    }

}