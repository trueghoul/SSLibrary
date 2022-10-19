using System.ComponentModel.DataAnnotations.Schema;

namespace SSLibrary.API.Entities;
// unused
public class Timestamps
{
    public DateTimeOffset CreationDate { get; set; }
    public DateTimeOffset? EditDate { get; set; }
}