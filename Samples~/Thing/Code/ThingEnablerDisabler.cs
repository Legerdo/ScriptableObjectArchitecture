using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjectArchitecture
{
    public class ThingEnablerDisabler : MonoBehaviour
    {
        public ThingRuntimeSet Set;

        public void SetAllActiveState(bool isActive)
        {
            // Loop backwards since the list may change when disabling/enabling
            for (int i = Set.Items.Count - 1; i >= 0; i--)
            {
                if (i < Set.Items.Count) // 인덱스 참조 예외처리 추가
                {
                    Set.Items[i].gameObject.SetActive(isActive);
                }
            }
        }

        public void SetRandomActiveState(bool isActive)
        {
            if (Set.Items.Count > 0) // 인덱스 참조 예외처리 추가
            {
                bool foundValidObject = false;
                int attempts = 0;
                int maxAttempts = Set.Items.Count * 2; // 무한 루프 방지를 위한 최대 시도 횟수

                while (!foundValidObject && attempts < maxAttempts)
                {
                    int index = Random.Range(0, Set.Items.Count);

                    // 선택된 아이템의 현재 활성화 상태가 원하는 상태와 다를 경우만 처리
                    if (Set.Items[index].gameObject.activeInHierarchy != isActive)
                    {
                        Set.Items[index].gameObject.SetActive(isActive);
                        foundValidObject = true;
                    }

                    attempts++; // 시도 횟수 증가
                }
            }
        }
    }
}
