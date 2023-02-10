using TodoApp.Models;

namespace TodoApp.View;

public partial class AddTodoItemPage : ContentPage
{
    //������ ��������� ������� ������ ���� 4-20 ������ ����
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
			await DisplayAlert("������", "������� �������� ������", "��");
			return;
		}
		if (string.IsNullOrEmpty(description))
		{
			await DisplayAlert("������", "������� �������� ������", "��");
			return;
		}

		var todoItem = new TodoItem
		{
			Title = title,
			Description = description,
			IsCompleated = isCompleated
		};

		await App.Current.databaseService.CreateTodoItemAsync(todoItem);

		await DisplayAlert("�����", "������ ������� ���������", "��");
		await Navigation.PopAsync();
	}
}

