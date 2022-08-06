using System.Numerics;
using RoleTest.Permission;

namespace RoleTest;

/// <summary>
///     권한의 상속관계를 표시 하기 위한 인터페이스
/// </summary>
/// <summary>
///     c# 11이라면 Type대신 generic 사용할 수 있을 것이다.
/// </summary>
public class PermissionAttribute : Attribute
{
    private static readonly HashSet<Type> _allIaTypes;

    private readonly Type[] _permissions;

    static PermissionAttribute()
    {
        _allIaTypes = typeof(IPermission).Assembly.GetTypes()
                                         .Where(x => typeof(IPermission).IsAssignableFrom(c: x))
                                         .ToHashSet();
    }


    /// <summary>
    ///     IPermission의 하위 타입이 세팅되어야 한다.
    /// </summary>
    public PermissionAttribute(params Type[] permissions)
    {
        _permissions = permissions;
    }

    public BigInteger FuncValue
    {
        get
        {
            if ( _permissions.Length == 0)
            {
                return BigInteger.Zero;
            }

            var result = BigInteger.Zero;
            foreach (var permission in _permissions)
            {
                result |= GetfuncValue(type: permission);
            }

            result |= GetChildren();

            return result;
        }
    }

    private BigInteger GetChildren()
    {
        var result = BigInteger.Zero;

        foreach (var t in _permissions)
        {
            foreach (var a in _allIaTypes.Where(x => t.IsAssignableFrom(c: x)))
            {
                result |= GetfuncValue(type: a);
            }
        }

        return result;
    }

    private BigInteger GetfuncValue(Type type)
    {
        var result = BigInteger.Zero;
        var v = (FunctionAttribute?) type.GetCustomAttributes(attributeType: typeof(FunctionAttribute), inherit: false)
                                         .FirstOrDefault();
        if (v != null)
        {
            result |= BigInteger.One << v.Func;
        }


        return result;
    }

    public bool HasRole(BigInteger compare)
    {
        Console.WriteLine(value: "App:" + FuncValue);
        Console.WriteLine(value: "User:" + compare);
        Console.WriteLine(value: "rrrr:" + (FuncValue & compare));


        return (FuncValue & compare) != 0;
    }
}