using System.Collections.Generic;
using UnityEngine;

namespace Common.Extensions
{
    public static class TransformExtensions
    {
        public static void SetParentForAllTransforms(
            this IEnumerable<Component> components,
            Transform parent = null)
        {
            foreach (Component component in components)
            {
                component.transform.SetParent(parent);
            }
        }
    }
}