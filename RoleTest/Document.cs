using System.Reflection;
using RoleTest.Permission;

namespace RoleTest;

/// <summary>
///     뭔가를 하는 클래스
/// </summary>
public class Document
{
    private readonly User _user;

    public Document(User user)
    {
        _user = user;
    }

    [Permission(typeof(ICreate))]
    public void Create()
    {
        PermissionChecker.Check(userRole: _user.FuncValue, appRole: 1 << 2);

        Console.WriteLine(value: "Create");
    }


    /// <summary>
    ///     IRead 권한을 갖고 있는 유저는 이 메소드를 호출 할 수 있다.
    ///     IRead 권한은 IRead 인터페이스를 상속 받은 모든 하위 인터페이스는 사용 할 수 있다.
    /// </summary>
    [Permission(typeof(IRead))]
    public void Read()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Read");
    }

    [Permission(typeof(IUpdate))]
    public void Update()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Update");
    }

    [Permission(typeof(IDelete))]
    public void Delete()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Delete");
    }

    [Permission(typeof(IDoX))]
    public void Do001()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Do001");
    }

    [Permission(typeof(IDoX), typeof(IDoY))]
    public void Do002()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Do002");
    }

    [Permission(typeof(IDoQ), typeof(IDoY))]
    public void Do100()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Do100");
    }

    [Permission(typeof(IDoX), typeof(ICreate))]
    public void Do200()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Do200");
    }

    [Permission(typeof(IDoZ), typeof(IDoY))]
    public void Do300()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "Do300");
    }

    public void DoSomeThing()
    {
        PermissionChecker.Check(user: _user, methodInfo: MethodBase.GetCurrentMethod()!);
        Console.WriteLine(value: "DoSomeThing");
    }
}