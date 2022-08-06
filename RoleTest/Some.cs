using System.Numerics;
using System.Reflection;

namespace RoleTest;

public enum UserType
{
    Deny = 1 << 0,
    User = 1 << 1,
    Staff = 1 << 2,
    Admin = Staff | (1 << 3)
}

public static class PermissionChecker
{
    public static void Check(BigInteger userRole, BigInteger appRole)
    {
        if ((userRole & appRole) != 0)
        {
            return;
        }

        throw new UnauthorizedAccessException();
    }

    public static void Check(User user, MethodBase methodInfo)
    {
        if (!HasRole(userRole: user.FuncValue, methodInfo: methodInfo))
        {
            throw new UnauthorizedAccessException();
        }
    }

    private static bool HasRole(BigInteger userRole, MethodBase methodInfo)
    {
        var attr = methodInfo.GetCustomAttribute<PermissionAttribute>();

        //권한 설정이 없는것은 모두에게 허용
        if (attr == null)
        {
            return true;
        }

        return attr.HasRole(compare: userRole);
    }


    public static List<MethodBase> GetCallableMethod(BigInteger userRole)
    {
        //현재 어셈블리에서만 찾자
        //원래는 아직 로딩되지 않은 assembly도 file로 올려서 검사해야 함

        var results = new List<MethodBase>();

        // foreach (var type in typeof(Document).Assembly.GetTypes())

        var type = typeof(Document);
        {
            results.AddRange(collection: type.GetMethods().Where(x => HasRole(userRole: userRole, methodInfo: x)));
        }

        return results;
    }
}