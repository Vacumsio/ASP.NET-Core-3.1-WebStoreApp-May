namespace WebStoreApp.Domain.Entities.Base.Interfaces
{
    interface INamedEntity: IBaseEntity
    {
        string Name { get; set; }
    }
}
