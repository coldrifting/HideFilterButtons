using ColossalFramework.UI;
using ICities;
using System;
using UnityEngine;

namespace HideFilterButtons
{
    public class HideFilterButtons : LoadingExtensionBase, IUserMod
    {
        public string Name => "Hide Filter Buttons";
        public string Description => "Removes those annoying little buttons in the build panels";

        /// <summary>
        /// The actions to take when the level has been loaded
        /// </summary>
        public override void OnLevelLoaded(LoadMode mode)
        {
            Hide();
        }

        /// <summary>
        /// Seeks and destroys all filter buttons in the UI.
        /// </summary>
        public void Hide()
        {
            try
            {
                UITabContainer gtsContainer;
                UITabContainer tsContainer = GameObject.Find("TSContainer").GetComponent<UITabContainer>();

                if (tsContainer != null)
                {
                    foreach (UIComponent toolPanel in tsContainer.components)
                    {
                        if (toolPanel is UIPanel)
                        {
                            gtsContainer = toolPanel.GetComponentInChildren<UITabContainer>();

                            if (gtsContainer != null)
                            {
                                foreach (UIComponent tabPanel in gtsContainer.components)
                                {
                                    UIPanel filterPanel = tabPanel.Find("FilterPanel") as UIPanel;
                                    filterPanel.Hide();
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Log("HideFilterButtons: An issue occurred while hiding a filter button: " + ex.Message);
            }
        }
    }
}