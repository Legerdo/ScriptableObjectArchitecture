using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture
{
    public class ThingMonitor : MonoBehaviour
    {
        public ThingRuntimeSet Set;

        public Text Text;

        private int previousActiveCount = -1;

        private void OnEnable()
        {
            UpdateText();
        }

        private void Update()
        {
            // 현재 활성화된 아이템 수를 계산합니다.
            int currentActiveCount = GetActiveItemCount();

            if (previousActiveCount != currentActiveCount)
            {
                UpdateText();
                previousActiveCount = currentActiveCount;
            }
        }

        // 활성화된 아이템의 개수를 계산하는 메서드
        private int GetActiveItemCount()
        {
            int activeCount = 0;
            foreach (var item in Set.Items)
            {
                if (item != null && item.gameObject.activeInHierarchy)
                {
                    activeCount++;
                }
            }
            return activeCount;
        }

        public void UpdateText()
        {
            int activeItemCount = GetActiveItemCount();
            Text.text = "There are " + activeItemCount + " active things.";
        }
    }
}
