namespace RoleTest;

/// <summary>
/// 기능을 정의 한다.
/// 열거형으로 하면 ulong을 넘길 수 없으므로 처음부터 상수를 사용하자.
/// 음수는 허용하지 않으므로 양수만 사용하는 데이터 형을 추천
/// </summary>
public static class FuncValue
{
    /// <summary>
    /// 문서를 읽을 수 있다.
    /// </summary>
    public const  ushort Read = 1;
    
    /// <summary>
    /// 문서를 생성 한다.
    /// </summary>
    public const  ushort Create = 2;
    
    /// <summary>
    /// 문서를 수정 한다.
    /// </summary>
    public const  ushort Update = 3;
    
    /// <summary>
    /// 문서를 삭제 한다.
    /// </summary>
    public const  ushort Delete = 4;
    
    /// <summary>
    /// 임의의 기능들이 엄청 많다고 가정하자
    /// </summary>
    public const  ushort DoX = 87;
    public const  ushort DoY = 99;
    public const  ushort DoZ = 105;
    public const  ushort DoQ = 600;
}