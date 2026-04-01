using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SkillUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SkillManager skillManager;
    [SerializeField] private Transform availableSkillsContainer;
    [SerializeField] private Transform learnedSkillsContainer;
    [SerializeField] private GameObject skillButtonPrefab;

    private void Start()
    {
        PopulateAvailableSkills();
        PopulateLearnedSkills();
    }

    private void PopulateAvailableSkills()
    {
        foreach (var skill in skillManager.AllSkills)
        {
            var button = Instantiate(skillButtonPrefab, availableSkillsContainer);
            button.GetComponentInChildren<Text>().text = skill.SkillName;
            button.GetComponent<Button>().onClick.AddListener(() => AttemptToLearnSkill(skill));
        }
    }

    private void PopulateLearnedSkills()
    {
        foreach (var skill in player.AvailableSkills)
        {
            var button = Instantiate(skillButtonPrefab, learnedSkillsContainer);
            button.GetComponentInChildren<Text>().text = skill.SkillName;
        }
    }

    private void AttemptToLearnSkill(Skill skill)
    {
        if (player.LearnSkill(skill))
        {
            Debug.Log($"Player learned skill: {skill.SkillName}");
            PopulateLearnedSkills();
        }
        else
        {
            Debug.Log($"Player cannot learn skill: {skill.SkillName}");
        }
    }
}