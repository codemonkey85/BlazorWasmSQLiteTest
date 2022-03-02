namespace BlazorWasmSQLiteTest.Pages;

public partial class Todos
{
    private ClientSideDbContext? db;
    private IList<Todo>? todos;

    protected override async Task OnInitializedAsync()
    {
        db = await DataSynchronizer.GetPreparedDbContextAsync();
        DataSynchronizer.OnUpdate += StateHasChanged;

        if (db is not null)
        {
            todos = db.Todos.ToList();
        }
    }

    public void Dispose()
    {
        db?.Dispose();
        DataSynchronizer.OnUpdate -= StateHasChanged;
    }

    private async Task DeleteTodo(Todo todo)
    {
        if (db is null)
        {
            return;
        }

        db.Remove(todo);
        await db.SaveChangesAsync();
        todos = db.Todos.ToList();
    }

    private async Task AddNewTodo()
    {
        if (db is null)
        {
            return;
        }

        db.Add(new Todo
        {
            Title = "Another one",
            IsComplete = false,
        });
        await db.SaveChangesAsync();
        todos = db.Todos.ToList();
    }
}
