using CCG51.DBF.Viewer.Domain.Entities;
using CCG51.DBF.Viewer.Domain.ValueObjects;

namespace CCG51.DBF.Viewer.Domain.Interfaces;
public interface IDBFReader
{
    Task<DBFContent> ReadAsync(DBFFilePath dbfFilePath);
}
