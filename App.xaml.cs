using TodoApp.Services;
using TodoApp.View;
using TodoApp.ViewModels;


namespace TodoApp;

public partial class App : Application
{
    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
    public DatabaseService databaseService { get; private set; }
	public static new App Current { get; private set; }

	public App()
	{
		Current= this;
		InitializeComponent();
		databaseService = new DatabaseService(Constants.DatabasePath, Constants.Flags);

		MainPage = new NavigationPage(new TodoItemsListPage(new TodoItemsViewModel(databaseService)));
	}
}
