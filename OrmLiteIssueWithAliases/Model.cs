using ServiceStack.DataAnnotations;

namespace OrmLiteIssueWithAliases
{
    public class MainTable
    {
        [AutoIncrement]
        [PrimaryKey]
        [Alias("MAINID")]
        public int Id { get; set; }

        [Alias("DESCRIPTION")]
        public string Description { get; set; }
    }

    public class AltTable
    {
        [AutoIncrement]
        [PrimaryKey]
        [Alias("ALTID")]
        public int Id { get; set; }

        [Alias("DESCRIPTION")]
        public string Description { get; set; }
    }
}