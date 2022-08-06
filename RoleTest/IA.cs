namespace RoleTest.Permission;

public interface IPermission
{
}

public interface IUse : IPermission
{
}

[Function(func: FuncValue.Read)]
public interface IRead : IUse
{
}

[Function(func: FuncValue.Create)]
public interface ICreate : IRead
{
}

[Function(func: FuncValue.Update)]
public interface IUpdate : IRead
{
}

[Function(func: FuncValue.Delete)]
public interface IDelete : ICreate, IUpdate
{
}

[Function(func: FuncValue.DoX)]
public interface IDoX: IPermission
{
}

[Function(func: FuncValue.DoY)]
public interface IDoY:IDoX, IRead
{
}

[Function(func: FuncValue.DoZ)]
public interface IDoZ:IDoX, ICreate
{
}


[Function(func: FuncValue.DoQ)]
public interface IDoQ:IDoZ
{
}