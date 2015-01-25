using System;
using System.Linq;
using UnityEngine;
using System.Collections;

public class FxManager : MonoBehaviourExtend
{
    private static FxManager instance = null;

    public static FxManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType<FxManager>();
            }

            return instance;
        }
    }

    [Serializable]
    public class FxPair
    {
        public string EffectName;
        public GameObject EffectPrefab;
    }

    [SerializeField] private FxPair[] effects = null;

    public FxPair[] Effects
    {
        get { return effects; }
    }

    public GameObject GetEffectPrefab(string effectName)
    {
        GameObject effect = null;

        var pack =
            effects.SingleOrDefault(
                pair => string.Equals(pair.EffectName.ToLowerInvariant().Trim(), effectName.ToLowerInvariant().Trim()));

        if (pack != null)
        {
            effect = pack.EffectPrefab;
        }

        return effect;
    }
}
