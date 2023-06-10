using OWML.Common;
using OWML.ModHelper;
using UnityEngine;

namespace VietnameseTranslation
{
    public class VietnameseTranslation : ModBehaviour
    {
        private void Awake()
        {
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        public static VietnameseTranslation Instance;

        private void Start()
        {
            var api = ModHelper.Interaction.TryGetModApi<ILocalizationAPI>("xen.LocalizationUtility");
            api.RegisterLanguage(this, "Vietnamese", "assets/VietnameseTranslation.xml");
            //api.AddLanguageFont(this, "Space Mono", "assets/spacemono-regular", "Assets/SpaceMono-Regular.ttf");

            private AssetBundle bundle;
            public AssetBundle Bundle
            {
                get
                {
                    if (bundle == null)
                    {
                        bundle = ModHelper.Assets.LoadBundle("assets/space");
                    }
                    return bundle;
                }
            }

        //// Starting here, you'll have access to OWML's mod helper.
        //ModHelper.Console.WriteLine($"My mod {nameof(VietnameseTranslation)} is loaded!", MessageType.Success);


        //// Example of accessing game code.
        //LoadManager.OnCompleteSceneLoad += (scene, loadScene) =>
        //{
        //    if (loadScene != OWScene.SolarSystem) return;
        //    ModHelper.Console.WriteLine("Loaded into solar system!", MessageType.Success);
        //};
    }
    }
}