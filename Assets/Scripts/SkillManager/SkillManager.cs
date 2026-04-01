using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;


    [SerializeField] private List<Skill> skillList;

    public List<Skill> SkillList => skillList; // Nueva propiedad pública para acceder a la lista de habilidades

    public void NameOfSkill<T>(T skill) where T : Skill
    {
        Debug.Log(skill.SkillName);
    }


    //public bool TryLearnSkill<T,TResult>(Player sender, T target, Func<T,TResult>) where T : Skill
    public bool TryLearnSkill<T>(Player sender, T target, out T Result) where T : Skill
    {
        if (sender.Level >= target.LevelRestriction)
        {
            Result = target;
            return true;
        }
        else
        {
            Result = default;
            return false;
        }
    }

    // Método genérico para ejecutar acciones relacionadas con Skill y Player
    public static void ExecuteAction<T>(T skill, Action<T> action) where T : Skill
    {
        action(skill);
    }

    // Método genérico para validar condiciones previas para adquirir una habilidad
    public static bool ValidateCondition<T>(T skill, Func<T, bool> condition) where T : Skill
    {
        return condition(skill);
    }

    // Método genérico de búsqueda con out
    public static bool TryFind<T>(T[] skills, Func<T, bool> condition, out T result) where T : Skill
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



    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    //-> COMO IMPLEMENTARLO CON BOTONES
    public void BtnSelectSkill(Skill skill)
    {
        //GameManager.Instance.Player.Target = skill;
        Debug.Log("a");
    }

}
