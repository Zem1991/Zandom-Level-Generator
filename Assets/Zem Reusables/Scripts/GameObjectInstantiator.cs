using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZemReusables
{
    public static class GameObjectInstantiator
    {
        public static T Instantiate<T>(Vector3 position, Transform transform)
        {
            Quaternion rotation = Quaternion.identity;
            return Instantiate<T>(position, rotation, transform);
        }

        public static T Instantiate<T>(Vector3 position, Quaternion rotation, Transform parent)
        {
            Type type = typeof(T);
            string name = $"{type.Name} instance";
            GameObject gameObject = new(name, type);
            Transform transform = gameObject.transform;
            transform.SetPositionAndRotation(position, rotation);
            transform.parent = parent;
            T result = gameObject.GetComponent<T>();
            return result;
        }
    }
}
