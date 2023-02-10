using TodoApp.ViewModels;

namespace TodoApp.View;

public partial class TodoItemPage : ContentPage
{
    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
    private readonly TodoItemViewModel _viewModel;
    public TodoItemPage(TodoItemViewModel viewModel)
	{
		InitializeComponent();

		_viewModel = viewModel;
		BindingContext= _viewModel;
	}

	private async void OnSaveButtonClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(_viewModel.Title))
		{
			await DisplayAlert("Ошибка", "Введите название задачи", "ОК");
			return;
		}
		if (string.IsNullOrEmpty(_viewModel.Description))
		{
			await DisplayAlert("Ошибка", "Введите описание задачи", "ОК");
			return;
		}

		await _viewModel.SaveTodoItemAsync();
		await DisplayAlert("Успех", "Задача успешно сохранена", "ОК");
		await Navigation.PopAsync();
	}

	private async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var action = await DisplayActionSheet("Удалить задачу?", "Отмена", "Удалить");

		if (action == "Удалить")
		{
			await _viewModel.DeleteTodoItemAsync();
			await DisplayAlert("Успех", "Задача успешно удалена", "ОК");
			await Navigation.PopAsync();
		}
	}
}
