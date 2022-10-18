using System.ComponentModel.DataAnnotations.Schema;

namespace SSLibrary.API.Entities;
// unused
public class Timestamps
{
    public DateTimeOffset InsertionTime { get; set; }
    public DateTimeOffset ModificationTime { get; set; }
    public string RecordVersion { get; set; }
}