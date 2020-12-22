using UnityEditor;

public class AssetBundlesMenu
{
   [MenuItem("Assets/Build AssetBundles")]
   private static void BuildAllAssetBundles()
   {
      var assetDirectory = "Assets/Asset Bundles";

      BuildPipeline.BuildAssetBundles(assetDirectory, BuildAssetBundleOptions.None,
         EditorUserBuildSettings.activeBuildTarget);
   }
}
