namespace SSLibrary.API.CQRS.Persons.Queries.GetPersonBookList;

public class PersonsBooksListVm
{
    public IList<PersonBookLookupDto> PersonsBooks { get; set; }
}