using TodoApp.ViewModels;

namespace TodoApp.View;

public partial class TodoItemPage : ContentPage
{
    //������ ��������� ������� ������ ���� 4-20 ������ ����
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
			await DisplayAlert("������", "������� �������� ������", "��");
			return;
		}
		if (string.IsNullOrEmpty(_viewModel.Description))
		{
			await DisplayAlert("������", "������� �������� ������", "��");
			return;
		}

		await _viewModel.SaveTodoItemAsync();
		await DisplayAlert("�����", "������ ������� ���������", "��");
		await Navigation.PopAsync();
	}

	private async void OnDeleteButtonClicked(object sender, EventArgs e)
	{
		var action = await DisplayActionSheet("������� ������?", "������", "�������");

		if (action == "�������")
		{
			await _viewModel.DeleteTodoItemAsync();
			await DisplayAlert("�����", "������ ������� �������", "��");
			await Navigation.PopAsync();
		}
	}
}
