using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Newtonsoft.Json;

namespace ScriptableObjectArchitecture
{
    public class GenericVariable<T> : ScriptableObjectPlayMode
    {
        #region Fields

        [JsonIgnore]
        [SerializeField]
        protected T initialValue;

        [SerializeField]
        protected T value;

        // 구독자 관리 리스트 추가 (디버깅 용도)
        [JsonIgnore]
        [SerializeField]
        private List<GameObject> gameObjectSubscribers = new();

        [JsonIgnore]
        [SerializeField]
        private int totalSubscribers;

        private event Action<T> OnValueChanged;

        #endregion

        #region Properties

        /// <summary>
        /// 현재 변수의 값
        /// </summary>
        public virtual T Value
        {
            get => value;
            set => SetValue(value);
        }

        #endregion

        #region Operators

        public static implicit operator T(GenericVariable<T> input) => input.Value;

        #endregion

        #region Public Methods

        /// <summary>
        /// 변수의 값을 설정합니다.
        /// </summary>
        /// <param name="newValue">새로운 값</param>
        public virtual void SetValue(T newValue)
        {
            if (!this.value.Equals(newValue))
            {
                this.value = newValue;
                OnValueChanged?.Invoke(this.value);
            }
        }

        /// <summary>
        /// 구독을 추가합니다.
        /// </summary>
        /// <param name="subscriber">구독자 GameObject</param>
        /// <param name="callback">콜백 함수</param>
        public void Subscribe(GameObject subscriber, Action<T> callback)
        {
            OnValueChanged += callback;
            AddSubscriber(subscriber);
        }

        /// <summary>
        /// 구독을 제거합니다.
        /// </summary>
        /// <param name="subscriber">구독자 GameObject</param>
        /// <param name="callback">콜백 함수</param>
        public void UnSubscribe(GameObject subscriber, Action<T> callback)
        {
            OnValueChanged -= callback;
            RemoveSubscriber(subscriber);
        }

        /// <summary>
        /// 값에 변화를 적용합니다. (연산 지원 시 사용)
        /// </summary>
        /// <param name="amount">적용할 값</param>
        public virtual void ApplyChange(T amount)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 새 인스턴스를 생성합니다.
        /// </summary>
        /// <returns>새로운 GenericVariable 인스턴스</returns>
        public virtual GenericVariable<T> NewInstance()
        {
            return ScriptableObject.CreateInstance<GenericVariable<T>>();
        }

        /// <summary>
        /// 현재 인스턴스의 복제본을 생성합니다.
        /// </summary>
        /// <returns>복제된 GenericVariable 인스턴스</returns>
        public virtual GenericVariable<T> CloneInstantiate()
        {
            return Instantiate(this);
        }

        public virtual T GetMin()
        {
            return this.value;
        }

        public virtual T GetMax()
        {
            return this.value;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 구독자를 추가합니다.
        /// </summary>
        /// <param name="subscriber">구독자 GameObject</param>
        private void AddSubscriber(GameObject subscriber)
        {
            totalSubscribers++;
            gameObjectSubscribers.Add(subscriber);
        }

        /// <summary>
        /// 구독자를 제거합니다.
        /// </summary>
        /// <param name="subscriber">구독자 GameObject</param>
        private void RemoveSubscriber(GameObject subscriber)
        {
            totalSubscribers--;
            gameObjectSubscribers.Remove(subscriber);
        }

        #endregion

        #region Unity Callbacks

        protected override void InitializeRuntimeData()
        {
            value = initialValue;
        }

        protected override void CleanupRuntimeData()
        {
            value = initialValue;
        }

        #endregion

        #region Editor

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            SetValueEdit(value);
        }

        /// <summary>
        /// 에디터 모드에서 값이 변경될 때 호출됩니다.
        /// </summary>
        /// <param name="newValue">새로운 값</param>
        private void SetValueEdit(T newValue)
        {
            value = newValue;
            OnValueChanged?.Invoke(value);
        }
#endif

        #endregion
    }
}
