using OWML.Common;
using OWML.ModHelper;
using UnityEngine;
using UnityEngine.UI;

namespace VietnameseTranslation
{
    public class VietnameseTranslation : ModBehaviour
    {
        public static VietnameseTranslation Instance;

        private AssetBundle bundle;
        public AssetBundle Bundle
        {
            get
            {
                if (bundle == null)
                {
                    bundle = ModHelper.Assets.LoadBundle("assets/font");
                }
                return bundle;
            }
        }

        private void Awake()
        {
            // You won't be able to access OWML's mod helper in Awake.
            // So you probably don't want to do anything here.
            // Use Start() instead.
        }

        private void Start()
        {
            var api = ModHelper.Interaction.TryGetModApi<ILocalizationAPI>("xen.LocalizationUtility");
            api.RegisterLanguage(this, "Vietnamese", "assets/VietnameseTranslation.xml");

            Instance = this;
            //ModHelper.HarmonyHelper.AddPrefix<NomaiTranslatorProp>("InitializeFont", typeof(VietnameseTranslation), nameof(VietnameseTranslation.InitTranslatorFont));
            ModHelper.HarmonyHelper.AddPrefix<TextTranslation>("GetFont", typeof(VietnameseTranslation), nameof(VietnameseTranslation.GetFont));
            //api.AddLanguageFont(this, "Space Mono", "assets/spacemono-regular", "Assets/SpaceMono-Regular.ttf");




            //// Starting here, you'll have access to OWML's mod helper.
            //ModHelper.Console.WriteLine($"My mod {nameof(VietnameseTranslation)} is loaded!", MessageType.Success);


            //// Example of accessing game code.
            //LoadManager.OnCompleteSceneLoad += (scene, loadScene) =>
            //{
            //    if (loadScene != OWScene.SolarSystem) return;
            //    ModHelper.Console.WriteLine("Loaded into solar system!", MessageType.Success);
            //};
        }

        private static bool InitTranslatorFont(
            ref Font ____fontInUse,
            ref Font ____dynamicFontInUse,
            ref float ____fontSpacingInUse,
            ref Text ____textField)
        {
            ____fontInUse = VietnameseTranslation.self.NotoSansTcMed;
            ____dynamicFontInUse = VietnameseTranslation.self.NotoSansTcMedDyn;
            ____fontSpacingInUse = TextTranslation.GetDefaultFontSpacing();
            ____textField.font = ____fontInUse;
            ____textField.lineSpacing = ____fontSpacingInUse;
            return false;
        }

        private static bool GetFont(
            bool dynamicFont,
            ref Font __result)
        {
            if (TextTranslation.Get().GetLanguage() != TextTranslation.Language.CHINESE_SIMPLE)
            {
                return true;
            }

            if (dynamicFont)
            {
                __result = VietnameseTranslation.Instance.NotoSansTcMedDyn;
            }
            else
            {
                __result = VietnameseTranslation.Instance.NotoSansTcMed;
            }
            return false;
        }
    }
}