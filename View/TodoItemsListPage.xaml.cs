using TodoApp.Models;
using TodoApp.ViewModels;

namespace TodoApp.View;

public partial class TodoItemsListPage : ContentPage
{
    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия

    private readonly TodoItemsViewModel _viewModel;
	public TodoItemsListPage(TodoItemsViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		TodoListView.ItemsSource = null;
		await _viewModel.LoadTodoItemsAsync();
		TodoListView.ItemsSource = _viewModel.TodoItems;

		if (_viewModel.TodoItems.Count> 0)
		{
			SearchBar.IsVisible= true;
		}
		else
		{
			SearchBar.IsVisible= false;
		}
	}

	private void OnAddTodoItemClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new AddTodoItemPage());
	}

    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
    private async void OnTodoItemTapped(object sender, ItemTappedEventArgs e)
	{
		var todoItem = (TodoItem)e.Item;
		await Navigation.PushAsync(new TodoItemPage(new TodoItemViewModel(todoItem)));
	}
	
	private async void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
	{
		string searchText = e.NewTextValue;

		if (string.IsNullOrEmpty(searchText))
		{
			TodoListView.ItemsSource = null;
			TodoListView.ItemsSource = _viewModel.TodoItems;
		}
		else
		{
			_viewModel.FilteredTodoItems = await _viewModel.SearchTodoItemsAsync(searchText);
			TodoListView.ItemsSource = _viewModel.FilteredTodoItems;
		}
	}
}
