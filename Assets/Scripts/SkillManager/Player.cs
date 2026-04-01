using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int level;
    [SerializeField] private List<Skill> availableSkills;

    public int Level => level;
    public List<Skill> AvailableSkills => availableSkills;

    public bool CanUseSkill(Skill skill)
    {
        return level >= skill.LevelRestriction;
    }

    public bool LearnSkill(Skill skill)
    {
        if (level >= skill.LevelRestriction && !availableSkills.Contains(skill))
        {
            availableSkills.Add(skill);
            return true;
        }
        return false;
    }
}