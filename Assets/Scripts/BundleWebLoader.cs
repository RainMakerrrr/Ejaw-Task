using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

namespace Bundles
{
    public class BundleWebLoader : MonoBehaviour
    {
        [SerializeField] private string _bundleUrl = "http://localhost:8000/defaultbundle";
        [SerializeField] private string[] _assetsName;
        

        public IEnumerator LoadAndCreateBundle(Vector3 position)
        {
            using (var webRequest = UnityWebRequestAssetBundle.GetAssetBundle(_bundleUrl))
            { 
               yield return webRequest.SendWebRequest();

                if (webRequest.isNetworkError || webRequest.isHttpError) yield break;
              
                var bundle = DownloadHandlerAssetBundle.GetContent(webRequest);
                var randomAssetName = _assetsName[Random.Range(0, _assetsName.Length)];
                
                var prefab =  Instantiate(bundle.LoadAsset(randomAssetName)) as GameObject;
                prefab.transform.position = position;
                
                bundle.Unload(false);
                
            }
        }
        
    }
}