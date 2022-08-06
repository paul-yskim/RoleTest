namespace RoleTest;

/// <summary>
/// 기능 정의 
/// </summary>
public class FunctionAttribute:Attribute
{
    /// <summary>
    /// func의 숫자의 의미는 일차원 배열의 n번째 자리가 1인 것을 의미한다. 자릿수는 0부터 시작한다.
    /// 만약 func의 값이  9 라면  ....000001000000000 이다
    /// </summary>
    /// <param name="func"></param>
    public FunctionAttribute( ushort func)
    {
        this.Func = func;
    }

    public ushort Func { get; set; }
}