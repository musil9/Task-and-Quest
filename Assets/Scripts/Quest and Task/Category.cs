using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "Category", fileName = "Category_")]
public class Category : ScriptableObject,IEquatable<Category>
{
    [SerializeField]
    private string codeName;
    [SerializeField]
    private string displayName;

    public string CodeName => codeName;

    public string DisplayName => displayName;

    public bool Equals(Category other)
    {
        if (other == null)
            return false;
        if (ReferenceEquals(other, this))
            return true;
        if (GetType() != other.GetType())
            return false;

        return codeName == other.CodeName;
    }

    public override int GetHashCode() => (CodeName, DisplayName).GetHashCode();

    public override bool Equals(object other) => base.Equals(other);

    public static bool operator ==(Category lhs, string rhs)
    {
        if (lhs is null)
            return ReferenceEquals(rhs, null);
        return lhs.CodeName == rhs || lhs.DisplayName == rhs;
    }

    public static bool operator !=(Category lhs, string rhs) => !(lhs == rhs);
}
