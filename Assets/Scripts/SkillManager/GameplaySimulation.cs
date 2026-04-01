using UnityEngine;

public class GameplaySimulation : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SkillManager skillManager;

    private void Start()
    {
        // Simulate acquiring skills
        foreach (var skill in skillManager.AllSkills)
        {
            bool canLearn = SkillManager.ValidateCondition(skill, s => player.Level >= s.LevelRestriction);
            if (canLearn)
            {
                player.LearnSkill(skill);
                Debug.Log($"Player learned skill: {skill.SkillName}");
            }
            else
            {
                Debug.Log($"Player cannot learn skill: {skill.SkillName}");
            }
        }

        // Simulate executing skills
        foreach (var skill in player.AvailableSkills)
        {
            SkillManager.ExecuteAction(skill, s => Debug.Log($"Executing skill: {s.SkillName}"));
        }

        // Try finding a specific skill and ignore the result
        if (SkillManager.TryFind(skillManager.AllSkills.ToArray(), s => s.Id == 99, out _))
        {
            Debug.Log("Skill with ID 99 exists.");
        }
        else
        {
            Debug.Log("Skill with ID 99 does not exist.");
        }
    }
}