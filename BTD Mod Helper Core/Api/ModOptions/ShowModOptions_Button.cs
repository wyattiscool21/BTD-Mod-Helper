﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Patches;
using MelonLoader;
using Object = UnityEngine.Object;

namespace BTD_Mod_Helper.Api.ModOptions
{
    internal class ShowModOptions_Button
    {
#if BloonsTD6
        public ModOptionsMenu modOptionsMenu;
        public static GameObject settingsUI_Canvas;
        public Button instantiatedButton;
        public Button optionsButton;

        public ShowModOptions_Button()
        {
            
        }

        public void Init()
        {
#if BloonsTD6
            var scene = SceneManager.GetSceneByName("SettingsUI");
#elif BloonsAT
            var scene = SceneManager.GetSceneByName("UI-Settings");
#endif
            var rootGameObjects = scene.GetRootGameObjects();
            settingsUI_Canvas = rootGameObjects[0];
            optionsButton = ModOptionsMenu.CanvasGO.transform.Find("ModOptionsButton/Button").GetComponent<Button>();

            var twitchButton = settingsUI_Canvas.GetComponentInChildrenByName<RectTransform>("TwitchButton");
            
            
            instantiatedButton = Object.Instantiate(optionsButton, twitchButton.transform);
            instantiatedButton.onClick.AddListener(OptionButtonClicked);

            var transform = instantiatedButton.transform.Cast<RectTransform>();
            
            transform.Translate(new Vector3(-150, 0), twitchButton.transform);
            transform.localScale = new Vector3(2.5f, 2.5f);
        }

        public void OptionButtonClicked()
        {
            modOptionsMenu = new ModOptionsMenu();
            instantiatedButton.gameObject.SetActive(false);
        }
#endif
    }
}
