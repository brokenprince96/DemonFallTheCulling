using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour
{
    public string survivorName;
    public AnimatorOverrideController overrideController;
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var animator = GetComponent<Animator>();
        var overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = overrideController;

        Object[] loadedClips = Resources.LoadAll("Animations/" + survivorName);
        AnimationClip[] originalClips = overrideController.animationClips;

        var overrides = new List<KeyValuePair<AnimationClip, AnimationClip>>();

        foreach (AnimationClip original in originalClips)
        {
            AnimationClip replacement = null;

            // Get suffix like "Idle", "Move", etc
            // Assumes format like "Remy_Idle" or "James_Move"
            int underscoreIndex = original.name.IndexOf('_');
            string suffix = underscoreIndex >= 0 ? original.name.Substring(underscoreIndex) : original.name;

            foreach (Object asset in loadedClips)
            {
                if (asset is AnimationClip clip && clip.name.EndsWith(suffix))
                {
                    replacement = clip;
                    break;
                }
            }

            if (replacement != null)
            {
                overrides.Add(new KeyValuePair<AnimationClip, AnimationClip>(original, replacement));
            }
            else
            {
                overrides.Add(new KeyValuePair<AnimationClip, AnimationClip>(original, original));
            }
        }

        overrideController.ApplyOverrides(overrides);

    }

    public void PlayAnimation(string animation)
    {
        animator.Play(animation);
    }
}
