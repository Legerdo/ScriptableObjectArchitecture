using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjectArchitecture
{
    public class ImageFillSetter : MonoBehaviour
    {
        [Tooltip("Value to use as the current ")]
        public FloatVariable Variable;

        public Image Image;

        private void Start()
        {
            Variable.SetValue(Variable.Value);

            Debug.Log(Variable.Value);
        }

        void OnEnable()
        {
            Variable.Subscribe(this.gameObject, UpdateImageFill);         
        }

        private void OnDestroy()
        {
            Variable.UnSubscribe(this.gameObject,UpdateImageFill);
        }

        private void UpdateImageFill(float value)
        {
            Image.fillAmount = Mathf.Clamp01(
                Mathf.InverseLerp(0, 100, Variable.Value));
        }

/*
        private void Update()
        {
            Image.fillAmount = Mathf.Clamp01(
                Mathf.InverseLerp(0, 100, Variable.value));
        }
*/
    }

}
