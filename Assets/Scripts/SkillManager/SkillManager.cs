using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillManager", menuName = "LeagueOfLegends/SkillManager")]
public class SkillManager : ScriptableObject
{
    [SerializeField] private List<Skill> allSkills;

    public List<Skill> AllSkills => allSkills;

    // Generic method to execute actions on Skills
    public static void ExecuteAction<T>(T skill, Action<T> action)
    {
        action(skill);
    }

    // Generic method to validate conditions for acquiring a Skill
    public static bool ValidateCondition<T>(T skill, Func<T, bool> condition)
    {
        return condition(skill);
    }

    // Generic method to find a Skill based on a condition
    public static bool TryFind<T>(T[] skills, Func<T, bool> condition, out T result)
    {
        foreach (var skill in skills)
        {
            if (condition(skill))
            {
                result = skill;
                return true;
            }
        }
        result = default;
        return false;
    }
}