using TodoApp.Models;

namespace TodoApp.View;

public partial class AddTodoItemPage : ContentPage
{
    //Работу выполнила студент группы ИСиП 4-20 Митина Юлия
    public AddTodoItemPage()
	{
		InitializeComponent();
	}

	private async void OnAddTodoItemButtonClicked(object sender, EventArgs e)
	{
		var title = TitleEntry.Text;
		var description = DescriptionEditor.Text;
		var isCompleated = false;
		

		if (string.IsNullOrEmpty(title))
		{
			await DisplayAlert("Ошибка", "Введите название задачи", "ОК");
			return;
		}
		if (string.IsNullOrEmpty(description))
		{
			await DisplayAlert("Ошибка", "Введите описание задачи", "ОК");
			return;
		}

		var todoItem = new TodoItem
		{
			Title = title,
			Description = description,
			IsCompleated = isCompleated
		};

		await App.Current.databaseService.CreateTodoItemAsync(todoItem);

		await DisplayAlert("Успех", "Задача успешно добавлена", "ОК");
		await Navigation.PopAsync();
	}
}

