using Refit;

namespace InzynierkaMauiFront.Models;

public class CompareFacesRequestModel
{
    [AliasAs("sourceImage")]
    public StreamPart SourceImage { get; set; }

    public bool IsIdentified { get; set; }
    public int StudentId { get; set; }
}
