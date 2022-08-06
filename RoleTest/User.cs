using System.Numerics;

namespace RoleTest;

public record User
{
    public BigInteger FuncValue { get; set; }

    public UserType UserType { get; set; }

    public void SetFunction(params ushort[] func)
    {
        var one = BigInteger.One;

        foreach (var f in func)
        {
            FuncValue |= one << f;
        }
    }
}