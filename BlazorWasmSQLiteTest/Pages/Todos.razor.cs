namespace BlazorWasmSQLiteTest.Pages
{
    public partial class Todos
    {
        ClientSideDbContext? db;
        private Todo[]? todos;

        protected override async Task OnInitializedAsync()
        {
            db = await DataSynchronizer.GetPreparedDbContextAsync();
            DataSynchronizer.OnUpdate += StateHasChanged;

            if (db != null)
            {
                todos = db.Todos.ToArray();
            }
        }

        public void Dispose()
        {
            db?.Dispose();
            DataSynchronizer.OnUpdate -= StateHasChanged;
        }
    }
}
