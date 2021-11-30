using System.ComponentModel.DataAnnotations;

namespace BlazorWasmSQLiteTest
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsComplete { get; set; }
    }
}
